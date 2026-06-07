namespace OperationsFlow.Options;

public class OperationsFlowOptions
{
    public const string SectionName = "OperationsFlow";

    public string EnvironmentName { get; set; } = "Local Demo";
    public bool EnableDemoMode { get; set; } = true;
    public bool EnableDemoDataSeeding { get; set; } = true;
    public bool EnableMicrosoft365Integration { get; set; } = false;
    public bool EnableLocalFileStorage { get; set; } = true;
    public bool EnableRolePermissions { get; set; } = false;
    public bool EnableNotificationPreview { get; set; } = false;
    public bool EnableDryRunSync { get; set; } = true;
}