using Microsoft.Extensions.Options;
using OperationsFlow.Options;

namespace OperationsFlow.Services.Storage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment environment;
    private readonly FileStorageOptions options;

    public LocalFileStorageService(
        IWebHostEnvironment environment,
        IOptions<FileStorageOptions> options)
    {
        this.environment = environment;
        this.options = options.Value;
    }

    public string ProviderName => "Local";

    public async Task<FileStorageSaveResult> SaveAsync(
        FileStorageSaveRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request.FileStream == Stream.Null)
        {
            return Failed(request, "No file stream was provided.");
        }

        if (string.IsNullOrWhiteSpace(request.OriginalFileName))
        {
            return Failed(request, "No original file name was provided.");
        }

        if (!IsAllowedFile(request.OriginalFileName, request.FileSizeBytes, out var validationMessage))
        {
            return Failed(request, validationMessage);
        }

        var safeModuleName = SanitizeFolderName(request.ModuleName);
        var recordFolder = request.RecordId.HasValue
            ? request.RecordId.Value.ToString()
            : "unlinked";

        var extension = Path.GetExtension(request.OriginalFileName).ToLowerInvariant();
        var storedFileName = BuildStoredFileName(extension);
        var relativeFolder = Path.Combine(safeModuleName, recordFolder);
        var storedRelativePath = Path.Combine(relativeFolder, storedFileName).Replace("\\", "/");

        var rootPath = GetRootPath();
        var targetFolder = Path.Combine(rootPath, relativeFolder);
        var targetPath = Path.Combine(targetFolder, storedFileName);

        Directory.CreateDirectory(targetFolder);

        await using (var output = File.Create(targetPath))
        {
            await request.FileStream.CopyToAsync(output, cancellationToken);
        }

        return new FileStorageSaveResult
        {
            Success = true,
            OriginalFileName = request.OriginalFileName,
            StoredFileName = storedFileName,
            StoredRelativePath = storedRelativePath,
            PublicUrl = GetPublicUrl(storedRelativePath),
            ContentType = string.IsNullOrWhiteSpace(request.ContentType)
                ? "application/octet-stream"
                : request.ContentType,
            FileSizeBytes = request.FileSizeBytes,
            Provider = ProviderName
        };
    }

    public Task<Stream?> OpenReadAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(storedRelativePath))
        {
            return Task.FromResult<Stream?>(null);
        }

        var safeRelativePath = NormalizeRelativePath(storedRelativePath);
        var fullPath = Path.Combine(GetRootPath(), safeRelativePath);

        if (!File.Exists(fullPath))
        {
            return Task.FromResult<Stream?>(null);
        }

        Stream stream = File.OpenRead(fullPath);
        return Task.FromResult<Stream?>(stream);
    }

    public Task<bool> DeleteAsync(
        string storedRelativePath,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(storedRelativePath))
        {
            return Task.FromResult(false);
        }

        var safeRelativePath = NormalizeRelativePath(storedRelativePath);
        var fullPath = Path.Combine(GetRootPath(), safeRelativePath);

        if (!File.Exists(fullPath))
        {
            return Task.FromResult(false);
        }

        File.Delete(fullPath);
        return Task.FromResult(true);
    }

    public string GetPublicUrl(string storedRelativePath)
    {
        if (string.IsNullOrWhiteSpace(storedRelativePath))
        {
            return "";
        }

        var publicRoot = string.IsNullOrWhiteSpace(options.PublicRequestPath)
            ? "/uploads"
            : options.PublicRequestPath.TrimEnd('/');

        var safeRelativePath = NormalizeRelativePath(storedRelativePath)
            .Replace("\\", "/")
            .TrimStart('/');

        return $"{publicRoot}/{safeRelativePath}";
    }

    public bool IsAllowedFile(string originalFileName, long fileSizeBytes, out string validationMessage)
    {
        validationMessage = "";

        if (string.IsNullOrWhiteSpace(originalFileName))
        {
            validationMessage = "File name is required.";
            return false;
        }

        var extension = Path.GetExtension(originalFileName).ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(extension))
        {
            validationMessage = "File must have an extension.";
            return false;
        }

        var allowedExtensions = options.AllowedExtensions
            .Select(x => x.ToLowerInvariant())
            .ToHashSet();

        if (!allowedExtensions.Contains(extension))
        {
            validationMessage = $"File type '{extension}' is not allowed.";
            return false;
        }

        var maxBytes = options.MaxFileSizeMb * 1024L * 1024L;

        if (fileSizeBytes <= 0)
        {
            validationMessage = "File is empty.";
            return false;
        }

        if (fileSizeBytes > maxBytes)
        {
            validationMessage = $"File is too large. Maximum allowed size is {options.MaxFileSizeMb} MB.";
            return false;
        }

        return true;
    }

    private string GetRootPath()
    {
        var configuredRoot = string.IsNullOrWhiteSpace(options.LocalRootPath)
            ? "wwwroot/uploads"
            : options.LocalRootPath;

        if (Path.IsPathRooted(configuredRoot))
        {
            return configuredRoot;
        }

        return Path.Combine(environment.ContentRootPath, configuredRoot);
    }

    private static string BuildStoredFileName(string extension)
    {
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        var uniqueId = Guid.NewGuid().ToString("N")[..12];

        return $"{timestamp}-{uniqueId}{extension}";
    }

    private static string SanitizeFolderName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "General";
        }

        var invalidChars = Path.GetInvalidFileNameChars();
        var cleaned = new string(value
            .Select(ch => invalidChars.Contains(ch) ? '-' : ch)
            .ToArray());

        cleaned = cleaned
            .Replace(" ", "-")
            .Replace("_", "-")
            .Trim('-');

        return string.IsNullOrWhiteSpace(cleaned)
            ? "General"
            : cleaned;
    }

    private static string NormalizeRelativePath(string relativePath)
    {
        var cleaned = relativePath
            .Replace("\\", "/")
            .TrimStart('/');

        while (cleaned.Contains("..", StringComparison.Ordinal))
        {
            cleaned = cleaned.Replace("..", "", StringComparison.Ordinal);
        }

        return cleaned;
    }

    private FileStorageSaveResult Failed(FileStorageSaveRequest request, string message)
    {
        return new FileStorageSaveResult
        {
            Success = false,
            OriginalFileName = request.OriginalFileName,
            ContentType = request.ContentType,
            FileSizeBytes = request.FileSizeBytes,
            Provider = ProviderName,
            ErrorMessage = message
        };
    }
}