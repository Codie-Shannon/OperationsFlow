namespace OperationsFlow.Services.Storage;

public class FileStorageSaveRequest
{
    public Stream FileStream { get; set; } = Stream.Null;

    public string OriginalFileName { get; set; } = "";

    public string ContentType { get; set; } = "application/octet-stream";

    public long FileSizeBytes { get; set; }

    public string ModuleName { get; set; } = "General";

    public int? RecordId { get; set; }

    public string RecordReference { get; set; } = "";

    public string UploadedBy { get; set; } = "Demo User";

    public string Notes { get; set; } = "";

    public bool IsEvidence { get; set; }

    public bool IsControlledDocument { get; set; }
}