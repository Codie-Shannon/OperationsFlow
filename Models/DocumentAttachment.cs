namespace OperationsFlow.Models;

public class DocumentAttachment
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = "General";

    public int? RecordId { get; set; }

    public string RecordReference { get; set; } = "";

    public string OriginalFileName { get; set; } = "";

    public string StoredFileName { get; set; } = "";

    public string StoredRelativePath { get; set; } = "";

    public string PublicUrl { get; set; } = "";

    public string ContentType { get; set; } = "application/octet-stream";

    public long FileSizeBytes { get; set; }

    public string StorageProvider { get; set; } = "Local";

    public string UploadedBy { get; set; } = "Demo User";

    public DateTime UploadedDate { get; set; } = DateTime.Now;

    public string Notes { get; set; } = "";

    public string Status { get; set; } = "Active";

    public bool IsEvidence { get; set; } = false;

    public bool IsControlledDocument { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    public DateTime? DeletedDate { get; set; }

    public string DeletedBy { get; set; } = "";

    public string FileSizeDisplay
    {
        get
        {
            if (FileSizeBytes < 1024)
            {
                return $"{FileSizeBytes} B";
            }

            if (FileSizeBytes < 1024 * 1024)
            {
                return $"{FileSizeBytes / 1024.0:0.0} KB";
            }

            return $"{FileSizeBytes / 1024.0 / 1024.0:0.0} MB";
        }
    }

    public string DisplayModuleName =>
        string.IsNullOrWhiteSpace(ModuleName) ? "General" : ModuleName;

    public string DisplayRecordReference
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(RecordReference))
            {
                return RecordReference;
            }

            if (RecordId.HasValue)
            {
                return $"{DisplayModuleName} #{RecordId.Value}";
            }

            return "Unlinked";
        }
    }

    public bool HasRecordLink => RecordId.HasValue;

    public bool IsImage =>
        ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
        OriginalFileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
        OriginalFileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
        OriginalFileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase);

    public bool IsPdf =>
        ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase) ||
        OriginalFileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase);
}