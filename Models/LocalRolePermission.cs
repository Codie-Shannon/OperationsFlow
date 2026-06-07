namespace OperationsFlow.Models;

public class LocalRolePermission
{
    public int Id { get; set; }

    public int LocalRoleId { get; set; }

    public int LocalPermissionId { get; set; }

    public string AccessLevel { get; set; } = "No";

    public string Notes { get; set; } = string.Empty;
}