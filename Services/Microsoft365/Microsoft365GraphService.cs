using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using OperationsFlow.Options;

namespace OperationsFlow.Services.Microsoft365;

public class Microsoft365GraphService
{
    private readonly Microsoft365Options microsoft365Options;

    public Microsoft365GraphService(IOptions<Microsoft365Options> microsoft365Options)
    {
        this.microsoft365Options = microsoft365Options.Value;
    }

    public async Task<Microsoft365ConnectionStatus> TestConnectionAsync(CancellationToken cancellationToken = default)
    {
        var status = new Microsoft365ConnectionStatus();

        try
        {
            ApplyConfigurationChecks(status);

            if (!status.ConfigurationReady)
            {
                status.Message = "Microsoft 365 configuration is incomplete.";
                return status;
            }

            var graphClient = CreateGraphClient();

            status.Checks.Add("Graph client created from Tenant ID, Client ID, and client secret.");

            var (hostName, sitePath) = GetSharePointHostAndPath();

            status.Checks.Add($"Resolving SharePoint site: {hostName}:{sitePath}");

            var siteLookupKey = $"{hostName}:{sitePath}";

            var site = await graphClient
                .Sites[siteLookupKey]
                .GetAsync(cancellationToken: cancellationToken);

            if (site == null || string.IsNullOrWhiteSpace(site.Id))
            {
                status.SiteResolved = false;
                status.SharePointSiteStatus = "Not found";
                status.Errors.Add("Graph returned no SharePoint site for the configured site URL.");
                status.Message = "SharePoint site could not be resolved.";
                return status;
            }

            status.GraphConnected = true;
            status.SiteResolved = true;
            status.SharePointSiteStatus = "Resolved";
            status.SiteId = site.Id;
            status.SiteDisplayName = site.DisplayName ?? "";
            status.WebUrl = site.WebUrl ?? "";

            status.Checks.Add($"SharePoint site resolved: {status.SiteDisplayName} ({status.SiteId})");

            var drivesResponse = await graphClient
                .Sites[site.Id]
                .Drives
                .GetAsync(cancellationToken: cancellationToken);

            var matchingDrive = drivesResponse?
                .Value?
                .FirstOrDefault(drive =>
                    string.Equals(
                        drive.Name,
                        microsoft365Options.DocumentLibraryName,
                        StringComparison.OrdinalIgnoreCase));

            if (matchingDrive == null || string.IsNullOrWhiteSpace(matchingDrive.Id))
            {
                status.DocumentLibraryResolved = false;
                status.DocumentLibraryStatus = "Not found";
                status.Errors.Add($"Document library '{microsoft365Options.DocumentLibraryName}' was not found on the configured SharePoint site.");

                var availableLibraries = drivesResponse?
                    .Value?
                    .Where(drive => !string.IsNullOrWhiteSpace(drive.Name))
                    .Select(drive => drive.Name)
                    .OrderBy(name => name)
                    .ToList() ?? new List<string>();

                if (availableLibraries.Any())
                {
                    status.Checks.Add($"Available document libraries: {string.Join(", ", availableLibraries)}");
                }

                status.Message = "SharePoint site was resolved, but the document library could not be found.";
                return status;
            }

            status.DocumentLibraryResolved = true;
            status.DocumentLibraryStatus = "Resolved";
            status.DriveId = matchingDrive.Id;
            status.DriveName = matchingDrive.Name ?? "";

            status.Checks.Add($"Document library resolved: {status.DriveName} ({status.DriveId})");

            status.Success = true;
            status.Message = "Microsoft Graph connection, SharePoint site resolution, and document library resolution succeeded.";

            return status;
        }
        catch (Exception ex)
        {
            status.Success = false;
            status.Errors.Add(ex.Message);
            status.Message = "Microsoft 365 connection test failed. Check tenant/app registration values and Graph permissions.";

            return status;
        }
    }

    private void ApplyConfigurationChecks(Microsoft365ConnectionStatus status)
    {
        status.TenantIdStatus = microsoft365Options.HasTenantId ? "Configured" : "Missing";
        status.ClientIdStatus = microsoft365Options.HasClientId ? "Configured" : "Missing";
        status.ClientSecretStatus = microsoft365Options.HasClientSecret ? "Configured privately" : "Missing";
        status.SharePointSiteStatus = microsoft365Options.HasSharePointTarget ? "Configured" : "Missing";
        status.DocumentLibraryStatus = microsoft365Options.HasDocumentLibraryTarget ? "Configured" : "Missing";

        status.ConfigurationReady =
            microsoft365Options.Enabled &&
            microsoft365Options.HasBasicGraphConfig &&
            microsoft365Options.HasSharePointTarget &&
            microsoft365Options.HasDocumentLibraryTarget;

        if (!microsoft365Options.Enabled)
        {
            status.Errors.Add("Microsoft365:Enabled is false.");
        }

        if (!microsoft365Options.HasTenantId)
        {
            status.Errors.Add("Microsoft365:TenantId is missing.");
        }

        if (!microsoft365Options.HasClientId)
        {
            status.Errors.Add("Microsoft365:ClientId is missing.");
        }

        if (!microsoft365Options.HasClientSecret)
        {
            status.Errors.Add("Microsoft365:ClientSecret is missing.");
        }

        if (!microsoft365Options.HasSharePointTarget)
        {
            status.Errors.Add("Microsoft 365 SharePoint target is missing. Set SharePointSiteUrl or SharePointHostName + SharePointSitePath.");
        }

        if (!microsoft365Options.HasDocumentLibraryTarget)
        {
            status.Errors.Add("Microsoft 365 document library target is missing.");
        }

        if (status.ConfigurationReady)
        {
            status.Checks.Add("Microsoft 365 configuration is complete enough for a Graph connection test.");
        }
    }

    private GraphServiceClient CreateGraphClient()
    {
        var credential = new ClientSecretCredential(
            microsoft365Options.TenantId,
            microsoft365Options.ClientId,
            microsoft365Options.ClientSecret);

        var scopes = new[] { "https://graph.microsoft.com/.default" };

        return new GraphServiceClient(credential, scopes);
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
}