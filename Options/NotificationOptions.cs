namespace OperationsFlow.Options;

public class NotificationOptions
{
    public const string SectionName = "Notifications";

    public string Provider { get; set; } = "LocalPreview";
    public bool EnableLocalNotificationLog { get; set; } = true;
    public bool EnableTeamsNotifications { get; set; } = false;
    public bool EnableOutlookEmailNotifications { get; set; } = false;
    public string DefaultRecipient { get; set; } = "";
    public string TeamsWebhookUrl { get; set; } = "";
    public string WeeklySummaryDay { get; set; } = "Monday";
    public string WeeklySummaryTime { get; set; } = "08:30";

    public bool IsLocalPreview =>
        string.Equals(Provider, "LocalPreview", StringComparison.OrdinalIgnoreCase);

    public bool IsTeamsProvider =>
        string.Equals(Provider, "Teams", StringComparison.OrdinalIgnoreCase);

    public bool IsOutlookProvider =>
        string.Equals(Provider, "Outlook", StringComparison.OrdinalIgnoreCase);
}