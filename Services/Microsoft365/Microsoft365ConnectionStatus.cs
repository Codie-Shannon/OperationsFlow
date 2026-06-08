namespace OperationsFlow.Services.Microsoft365;

public class Microsoft365ConnectionStatus
{
    public bool ConfigurationReady { get; set; }
    public bool GraphConnected { get; set; }
    public bool SiteResolved { get; set; }
    public bool DocumentLibraryResolved { get; set; }
    public bool Success { get; set; }

    public string TenantIdStatus { get; set; } = "Not checked";
    public string ClientIdStatus { get; set; } = "Not checked";
    public string ClientSecretStatus { get; set; } = "Not checked";
    public string SharePointSiteStatus { get; set; } = "Not checked";
    public string DocumentLibraryStatus { get; set; } = "Not checked";

    public string? SiteId { get; set; }
    public string? SiteDisplayName { get; set; }
    public string? DriveId { get; set; }
    public string? DriveName { get; set; }
    public string? WebUrl { get; set; }

    public string Message { get; set; } = "";
    public List<string> Checks { get; set; } = new();
    public List<string> Errors { get; set; } = new();

    public static Microsoft365ConnectionStatus NotConfigured(string message)
    {
        return new Microsoft365ConnectionStatus
        {
            ConfigurationReady = false,
            Success = false,
            Message = message,
            TenantIdStatus = "Not configured",
            ClientIdStatus = "Not configured",
            ClientSecretStatus = "Not configured",
            SharePointSiteStatus = "Not configured",
            DocumentLibraryStatus = "Not configured",
            Checks = new List<string>
            {
                "Microsoft 365 configuration is not complete yet."
            }
        };
    }
}