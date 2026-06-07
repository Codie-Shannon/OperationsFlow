namespace OperationsFlow.Models;

public class LocalUserRole
{
    public int Id { get; set; }

    public int LocalUserId { get; set; }

    public int LocalRoleId { get; set; }

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    public string AssignedBy { get; set; } = "System";

    public string Notes { get; set; } = string.Empty;
}