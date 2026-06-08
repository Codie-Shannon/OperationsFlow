using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using OperationsFlow.Options;

namespace OperationsFlow.Services.Storage;

public class SharePointFileStorageService : IFileStorageService
{
    private readonly Microsoft365Options microsoft365Options;
    private readonly FileStorageOptions fileStorageOptions;

    public SharePointFileStorageService(
        IOptions<Microsoft365Options> microsoft365Options,
        IOptions<FileStorageOptions> fileStorageOptions)
    {
        this.microsoft365Options = microsoft365Options.Value;
        this.fileStorageOptions = fileStorageOptions.Value;
    }

    public string ProviderName => "SharePoint";

    public async Task<FileStorageSaveResult> SaveAsync(
        FileStorageSaveRequest request,
        CancellationToken cancellationToken = default)
    {
        if (!IsAllowedFile(request.OriginalFileName, request.FileSizeBytes, out var validationMessage))
        {
            return Failed(request, validationMessage);
        }

        if (!microsoft365Options.HasBasicGraphConfig)
        {
            return Failed(request, "Microsoft 365 Graph configuration is incomplete.");
        }

        if (!microsoft365Options.HasSharePointTarget)
        {
            return Failed(request, "SharePoint site target is not configured.");
        }

        if (!microsoft365Options.HasDocumentLibraryTarget)
        {
            return Failed(request, "SharePoint document library target is not configured.");
        }

        try
        {
            var graphClient = CreateGraphClient();

            var site = await ResolveSiteAsync(graphClient, cancellationToken);

            if (site == null || string.IsNullOrWhiteSpace(site.Id))
            {
                return Failed(request, "SharePoint site could not be resolved.");
            }

            var drive = await ResolveDriveAsync(graphClient, site.Id, cancellationToken);

            if (drive == null || string.IsNullOrWhiteSpace(drive.Id))
            {
                return Failed(request, $"Document library '{microsoft365Options.DocumentLibraryName}' could not be resolved.");
            }

            var storedFileName = BuildStoredFileName(request.OriginalFileName);
            var folderPath = BuildFolderPath(request.ModuleName, request.RecordReference, request.RecordId);
            var itemPath = string.IsNullOrWhiteSpace(folderPath)
                ? storedFileName
                : $"{folderPath}/{storedFileName}";

            if (request.FileStream.CanSeek)
            {
                request.FileStream.Position = 0;
            }

            var uploadedItem = await graphClient
                .Drives[drive.Id]
                .Root
                .ItemWithPath(itemPath)
                .Content
                .PutAsync(request.FileStream, cancellationToken: cancellationToken);

            if (uploadedItem == null || string.IsNullOrWhiteSpace(uploadedItem.Id))
            {
                return Failed(request, "SharePoint upload completed without returning a file item.");
            }

            await WriteMetadataAsync(
                drive.Id,
                uploadedItem.Id,
                request,
                cancellationToken);

            return new FileStorageSaveResult
            {
                Success = true,
                OriginalFileName = request.OriginalFileName,
                StoredFileName = storedFileName,
                StoredRelativePath = itemPath,
                PublicUrl = uploadedItem.WebUrl ?? "",
                ContentType = request.ContentType,
                FileSizeBytes = request.FileSizeBytes,
                Provider = ProviderName,
                ExternalItemId = uploadedItem.Id,
                ExternalDriveId = drive.Id,
                ExternalSiteId = site.Id,
                ExternalWebUrl = uploadedItem.WebUrl ?? ""
            };
        }
        catch (Exception ex)
        {
            return Failed(request, $"SharePoint upload failed: {ex.Message}");
        }
    }

    public Task<Stream?> OpenReadAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default)
    {
        // Week 4 pilot opens SharePoint-backed files through their SharePoint web URL.
        // Direct stream download can be added later if needed.
        return Task.FromResult<Stream?>(null);
    }

    public Task<bool> DeleteAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default)
    {
        // OperationsFlow currently soft-deletes attachment metadata.
        // Physical SharePoint delete can be added later as an admin/hard-delete action.
        return Task.FromResult(false);
    }

    public string GetPublicUrl(string storedRelativePath)
    {
        return "";
    }

    public bool IsAllowedFile(string originalFileName, long fileSizeBytes, out string validationMessage)
    {
        validationMessage = "";

        if (string.IsNullOrWhiteSpace(originalFileName))
        {
            validationMessage = "File name is required.";
            return false;
        }

        if (fileSizeBytes <= 0)
        {
            validationMessage = "File is empty.";
            return false;
        }

        var maxBytes = fileStorageOptions.MaxFileSizeMb * 1024L * 1024L;

        if (fileSizeBytes > maxBytes)
        {
            validationMessage = $"File exceeds the configured {fileStorageOptions.MaxFileSizeMb} MB limit.";
            return false;
        }

        var extension = Path.GetExtension(originalFileName);

        if (!fileStorageOptions.AllowedExtensions.Any(x =>
                string.Equals(x, extension, StringComparison.OrdinalIgnoreCase)))
        {
            validationMessage = $"File type '{extension}' is not allowed.";
            return false;
        }

        if (!microsoft365Options.Enabled)
        {
            validationMessage = "Microsoft 365 integration is disabled.";
            return false;
        }

        if (!microsoft365Options.HasBasicGraphConfig)
        {
            validationMessage = "Microsoft 365 Tenant ID, Client ID, or Client Secret is missing.";
            return false;
        }

        if (!microsoft365Options.HasSharePointTarget)
        {
            validationMessage = "SharePoint site target is missing.";
            return false;
        }

        if (!microsoft365Options.HasDocumentLibraryTarget)
        {
            validationMessage = "SharePoint document library target is missing.";
            return false;
        }

        return true;
    }

    private GraphServiceClient CreateGraphClient()
    {
        var credential = CreateCredential();

        var scopes = new[] { "https://graph.microsoft.com/.default" };

        return new GraphServiceClient(credential, scopes);
    }

    private ClientSecretCredential CreateCredential()
    {
        return new ClientSecretCredential(
            microsoft365Options.TenantId,
            microsoft365Options.ClientId,
            microsoft365Options.ClientSecret);
    }

    private async Task<Site?> ResolveSiteAsync(
        GraphServiceClient graphClient,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(microsoft365Options.SharePointSiteId))
        {
            return await graphClient
                .Sites[microsoft365Options.SharePointSiteId]
                .GetAsync(cancellationToken: cancellationToken);
        }

        var (hostName, sitePath) = GetSharePointHostAndPath();
        var siteLookupKey = $"{hostName}:{sitePath}";

        return await graphClient
            .Sites[siteLookupKey]
            .GetAsync(cancellationToken: cancellationToken);
    }

    private async Task<Drive?> ResolveDriveAsync(
        GraphServiceClient graphClient,
        string siteId,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(microsoft365Options.DocumentLibraryId))
        {
            return await graphClient
                .Drives[microsoft365Options.DocumentLibraryId]
                .GetAsync(cancellationToken: cancellationToken);
        }

        var drivesResponse = await graphClient
            .Sites[siteId]
            .Drives
            .GetAsync(cancellationToken: cancellationToken);

        return drivesResponse?
            .Value?
            .FirstOrDefault(drive =>
                string.Equals(
                    drive.Name,
                    microsoft365Options.DocumentLibraryName,
                    StringComparison.OrdinalIgnoreCase));
    }

    private async Task WriteMetadataAsync(
        string driveId,
        string driveItemId,
        FileStorageSaveRequest request,
        CancellationToken cancellationToken)
    {
        var credential = CreateCredential();

        var token = await credential.GetTokenAsync(
            new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" }),
            cancellationToken);

        var metadata = new Dictionary<string, object?>
        {
            ["OperationsFlowModule"] = NormalizeModuleName(request.ModuleName),
            ["OperationsFlowRecordId"] = request.RecordId ?? 0,
            ["OperationsFlowRecordRef"] = BuildRecordReference(request.RecordReference, request.RecordId),
            ["IsEvidence"] = request.IsEvidence,
            ["IsControlledDocument"] = request.IsControlledDocument,
            ["UploadedByDisplayName"] = string.IsNullOrWhiteSpace(request.UploadedBy)
                ? "Demo User"
                : request.UploadedBy,
            ["OperationsFlowNotes"] = request.Notes ?? ""
        };

        var json = JsonSerializer.Serialize(metadata);

        using var httpClient = new HttpClient();
        using var httpRequest = new HttpRequestMessage(
            HttpMethod.Patch,
            $"https://graph.microsoft.com/v1.0/drives/{Uri.EscapeDataString(driveId)}/items/{Uri.EscapeDataString(driveItemId)}/listItem/fields");

        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
        httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await httpClient.SendAsync(httpRequest, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

            throw new InvalidOperationException(
                $"SharePoint metadata writeback failed ({(int)response.StatusCode} {response.ReasonPhrase}): {responseBody}");
        }
    }

    private (string HostName, string SitePath) GetSharePointHostAndPath()
    {
        if (!string.IsNullOrWhiteSpace(microsoft365Options.SharePointSiteUrl))
        {
            var uri = new Uri(microsoft365Options.SharePointSiteUrl);

            return (uri.Host, NormalizeSitePath(uri.AbsolutePath));
        }

        if (!string.IsNullOrWhiteSpace(microsoft365Options.SharePointHostName) &&
            !string.IsNullOrWhiteSpace(microsoft365Options.SharePointSitePath))
        {
            return (
                microsoft365Options.SharePointHostName.Trim(),
                NormalizeSitePath(microsoft365Options.SharePointSitePath));
        }

        throw new InvalidOperationException("SharePoint site target is not configured.");
    }

    private static string NormalizeSitePath(string sitePath)
    {
        if (string.IsNullOrWhiteSpace(sitePath))
        {
            return "";
        }

        return sitePath.StartsWith("/")
            ? sitePath
            : $"/{sitePath}";
    }

    private static string BuildFolderPath(string moduleName, string recordReference, int? recordId)
    {
        var moduleFolder = NormalizeModuleFolder(moduleName);
        var referenceFolder = SanitizePathSegment(BuildRecordReference(recordReference, recordId));

        return string.IsNullOrWhiteSpace(referenceFolder)
            ? moduleFolder
            : $"{moduleFolder}/{referenceFolder}";
    }

    private static string NormalizeModuleFolder(string moduleName)
    {
        var normalized = NormalizeModuleName(moduleName);

        return normalized switch
        {
            "Work Orders" => "Work Orders",
            "Corrective Actions" => "Corrective Actions",
            "Document Intake" => "Document Intake",
            _ => "General"
        };
    }

    private static string NormalizeModuleName(string moduleName)
    {
        return string.IsNullOrWhiteSpace(moduleName)
            ? "General"
            : moduleName.Trim();
    }

    private static string BuildRecordReference(string recordReference, int? recordId)
    {
        if (!string.IsNullOrWhiteSpace(recordReference))
        {
            return recordReference.Trim();
        }

        return recordId.HasValue
            ? $"Record-{recordId.Value}"
            : "Unlinked";
    }

    private static string BuildStoredFileName(string originalFileName)
    {
        var extension = Path.GetExtension(originalFileName);
        var baseName = Path.GetFileNameWithoutExtension(originalFileName);

        baseName = SanitizePathSegment(baseName);

        if (string.IsNullOrWhiteSpace(baseName))
        {
            baseName = "file";
        }

        var stamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");

        return $"{stamp}-{baseName}{extension}";
    }

    private static string SanitizePathSegment(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "";
        }

        var invalidCharacters = Path.GetInvalidFileNameChars()
            .Concat(new[] { '#', '%', '&', '{', '}', '\\', '<', '>', '*', '?', '/', '$', '!', '\'', '"', ':', '@', '+', '`', '|', '=' })
            .Distinct()
            .ToArray();

        var cleaned = new string(value
            .Trim()
            .Select(ch => invalidCharacters.Contains(ch) ? '-' : ch)
            .ToArray());

        while (cleaned.Contains("--", StringComparison.Ordinal))
        {
            cleaned = cleaned.Replace("--", "-", StringComparison.Ordinal);
        }

        return cleaned.Trim('-', ' ');
    }

    private FileStorageSaveResult Failed(FileStorageSaveRequest request, string errorMessage)
    {
        return new FileStorageSaveResult
        {
            Success = false,
            OriginalFileName = request.OriginalFileName,
            ContentType = request.ContentType,
            FileSizeBytes = request.FileSizeBytes,
            Provider = ProviderName,
            ErrorMessage = errorMessage
        };
    }
}