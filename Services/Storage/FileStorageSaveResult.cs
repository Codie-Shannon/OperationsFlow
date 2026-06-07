namespace OperationsFlow.Services.Storage;

public class FileStorageSaveResult
{
    public bool Success { get; set; }
    public string OriginalFileName { get; set; } = "";
    public string StoredFileName { get; set; } = "";
    public string StoredRelativePath { get; set; } = "";
    public string PublicUrl { get; set; } = "";
    public string ContentType { get; set; } = "";
    public long FileSizeBytes { get; set; }
    public string Provider { get; set; } = "";
    public string ErrorMessage { get; set; } = "";
}