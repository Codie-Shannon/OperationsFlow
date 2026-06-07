namespace OperationsFlow.Services.Storage;

public interface IFileStorageService
{
    string ProviderName { get; }

    Task<FileStorageSaveResult> SaveAsync(
        FileStorageSaveRequest request,
        CancellationToken cancellationToken = default);

    Task<Stream?> OpenReadAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default);

    string GetPublicUrl(string storedRelativePath);

    bool IsAllowedFile(string originalFileName, long fileSizeBytes, out string validationMessage);
}