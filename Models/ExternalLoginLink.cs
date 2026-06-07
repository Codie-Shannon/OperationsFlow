namespace OperationsFlow.Models;

public class ExternalLoginLink
{
    public int Id { get; set; }

    public int LocalUserId { get; set; }

    public string Provider { get; set; } = string.Empty;

    public string ProviderUserId { get; set; } = string.Empty;

    public string ProviderEmail { get; set; } = string.Empty;

    public string ProviderDisplayName { get; set; } = string.Empty;

    public bool IsLinked { get; set; } = true;

    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;

    public DateTime? LastLoginAt { get; set; }

    public string Notes { get; set; } = string.Empty;
}