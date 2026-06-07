namespace OperationsFlow.Options;

public class FileStorageOptions
{
    public const string SectionName = "FileStorage";

    public string Provider { get; set; } = "Local";
    public string LocalRootPath { get; set; } = "wwwroot/uploads";
    public string PublicRequestPath { get; set; } = "/uploads";
    public int MaxFileSizeMb { get; set; } = 25;
    public List<string> AllowedExtensions { get; set; } = new()
    {
        ".pdf",
        ".docx",
        ".xlsx",
        ".png",
        ".jpg",
        ".jpeg",
        ".txt",
        ".csv"
    };

    public bool IsLocalProvider =>
        string.Equals(Provider, "Local", StringComparison.OrdinalIgnoreCase);

    public bool IsSharePointProvider =>
        string.Equals(Provider, "SharePoint", StringComparison.OrdinalIgnoreCase);
}