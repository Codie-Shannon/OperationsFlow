namespace OperationsFlow.Options;

public class Microsoft365Options
{
    public const string SectionName = "Microsoft365";

    public bool Enabled { get; set; } = false;

    public string TenantId { get; set; } = "";
    public string ClientId { get; set; } = "";
    public string ClientSecret { get; set; } = "";

    public string RedirectUri { get; set; } = "https://localhost:5001/signin-oidc";

    public string SharePointSiteUrl { get; set; } = "";
    public string SharePointHostName { get; set; } = "";
    public string SharePointSitePath { get; set; } = "";
    public string SharePointSiteId { get; set; } = "";

    public string DocumentLibraryId { get; set; } = "";
    public string DocumentLibraryName { get; set; } = "OperationsFlow Evidence";

    public string ListPrefix { get; set; } = "OperationsFlow";

    public bool UseMicrosoftLogin { get; set; } = false;
    public bool UseSharePointStorage { get; set; } = false;

    public bool EnableRealSync { get; set; } = false;
    public bool EnableDryRunOnly { get; set; } = true;

    public bool HasTenantId =>
        !string.IsNullOrWhiteSpace(TenantId);

    public bool HasClientId =>
        !string.IsNullOrWhiteSpace(ClientId);

    public bool HasClientSecret =>
        !string.IsNullOrWhiteSpace(ClientSecret);

    public bool HasBasicGraphConfig =>
        HasTenantId &&
        HasClientId &&
        HasClientSecret;

    public bool HasRedirectUri =>
        !string.IsNullOrWhiteSpace(RedirectUri);

    public bool HasSharePointSiteUrl =>
        !string.IsNullOrWhiteSpace(SharePointSiteUrl);

    public bool HasSharePointTarget =>
        !string.IsNullOrWhiteSpace(SharePointSiteId) ||
        !string.IsNullOrWhiteSpace(SharePointSiteUrl) ||
        (!string.IsNullOrWhiteSpace(SharePointHostName) && !string.IsNullOrWhiteSpace(SharePointSitePath));

    public bool HasDocumentLibraryTarget =>
        !string.IsNullOrWhiteSpace(DocumentLibraryId) ||
        !string.IsNullOrWhiteSpace(DocumentLibraryName);

    public bool IsGraphReady =>
        Enabled &&
        HasBasicGraphConfig &&
        HasRedirectUri;

    public bool IsSharePointReady =>
        Enabled &&
        HasBasicGraphConfig &&
        HasSharePointTarget &&
        HasDocumentLibraryTarget;

    public bool IsMicrosoftLoginReady =>
        Enabled &&
        UseMicrosoftLogin &&
        HasBasicGraphConfig &&
        HasRedirectUri;

    public bool IsSharePointStorageReady =>
        Enabled &&
        UseSharePointStorage &&
        HasBasicGraphConfig &&
        HasSharePointTarget &&
        HasDocumentLibraryTarget;

    public string SafeSharePointTargetDisplay
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(SharePointSiteUrl))
            {
                return SharePointSiteUrl;
            }

            if (!string.IsNullOrWhiteSpace(SharePointSiteId))
            {
                return $"Site ID: {SharePointSiteId}";
            }

            if (!string.IsNullOrWhiteSpace(SharePointHostName) && !string.IsNullOrWhiteSpace(SharePointSitePath))
            {
                return $"{SharePointHostName}:{SharePointSitePath}";
            }

            return "Not configured";
        }
    }

    public string SafeLibraryTargetDisplay =>
        !string.IsNullOrWhiteSpace(DocumentLibraryName)
            ? DocumentLibraryName
            : !string.IsNullOrWhiteSpace(DocumentLibraryId)
                ? $"Library ID: {DocumentLibraryId}"
                : "Not configured";
}