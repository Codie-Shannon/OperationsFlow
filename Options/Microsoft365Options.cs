namespace OperationsFlow.Options;

public class Microsoft365Options
{
    public const string SectionName = "Microsoft365";

    public string TenantId { get; set; } = "";
    public string ClientId { get; set; } = "";
    public string ClientSecret { get; set; } = "";
    public string SharePointHostName { get; set; } = "";
    public string SharePointSitePath { get; set; } = "";
    public string SharePointSiteId { get; set; } = "";
    public string DocumentLibraryId { get; set; } = "";
    public string DocumentLibraryName { get; set; } = "OperationsFlow Documents";
    public string ListPrefix { get; set; } = "OperationsFlow";
    public bool EnableRealSync { get; set; } = false;
    public bool EnableDryRunOnly { get; set; } = true;

    public bool HasBasicGraphConfig =>
        !string.IsNullOrWhiteSpace(TenantId) &&
        !string.IsNullOrWhiteSpace(ClientId) &&
        !string.IsNullOrWhiteSpace(ClientSecret);

    public bool HasSharePointTarget =>
        !string.IsNullOrWhiteSpace(SharePointSiteId) ||
        (!string.IsNullOrWhiteSpace(SharePointHostName) && !string.IsNullOrWhiteSpace(SharePointSitePath));
}