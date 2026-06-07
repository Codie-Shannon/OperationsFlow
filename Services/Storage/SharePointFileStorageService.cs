using Microsoft.Extensions.Options;
using OperationsFlow.Options;

namespace OperationsFlow.Services.Storage;

public class SharePointFileStorageService : IFileStorageService
{
    private readonly Microsoft365Options microsoft365Options;

    public SharePointFileStorageService(IOptions<Microsoft365Options> microsoft365Options)
    {
        this.microsoft365Options = microsoft365Options.Value;
    }

    public string ProviderName => "SharePoint";

    public Task<FileStorageSaveResult> SaveAsync(
        FileStorageSaveRequest request,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new FileStorageSaveResult
        {
            Success = false,
            OriginalFileName = request.OriginalFileName,
            ContentType = request.ContentType,
            FileSizeBytes = request.FileSizeBytes,
            Provider = ProviderName,
            ErrorMessage = BuildNotImplementedMessage()
        });
    }

    public Task<Stream?> OpenReadAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult<Stream?>(null);
    }

    public Task<bool> DeleteAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(false);
    }

    public string GetPublicUrl(string storedRelativePath)
    {
        return "";
    }

    public bool IsAllowedFile(string originalFileName, long fileSizeBytes, out string validationMessage)
    {
        validationMessage = BuildNotImplementedMessage();
        return false;
    }

    private string BuildNotImplementedMessage()
    {
        var target = string.IsNullOrWhiteSpace(microsoft365Options.DocumentLibraryName)
            ? "SharePoint document library"
            : microsoft365Options.DocumentLibraryName;

        return $"SharePoint file storage is configured for '{target}', but the live provider is scheduled for Week 4 production implementation.";
    }
}