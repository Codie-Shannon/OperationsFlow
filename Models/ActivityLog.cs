namespace OperationsFlow.Models;

public class ActivityLog
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = "";

    public int RecordId { get; set; }

    public string RecordReference { get; set; } = "";

    public string ActionType { get; set; } = "";

    public string Description { get; set; } = "";

    public string CreatedBy { get; set; } = "";

    public DateTime CreatedDate { get; set; }
}