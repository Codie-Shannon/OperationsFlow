namespace OperationsFlow.Models;

public class DocumentIntake
{
    public int Id { get; set; }

    public string DocumentName { get; set; } = "";

    public DateTime ReceivedDate { get; set; }

    public string ReceivedFrom { get; set; } = "";

    public string SourceType { get; set; } = "";

    public string DocumentType { get; set; } = "";

    public string AssignedTo { get; set; } = "";

    public string TargetSystem { get; set; } = "";

    public string Status { get; set; } = "";

    public string Priority { get; set; } = "";

    public DateTime DueDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string Notes { get; set; } = "";

    public bool IsCompleted =>
        string.Equals(Status, "Completed", StringComparison.OrdinalIgnoreCase)
        || string.Equals(Status, "Rejected", StringComparison.OrdinalIgnoreCase);

    public bool IsOverdue =>
        !IsCompleted && DueDate.Date < DateTime.Today;

    public bool NeedsReview =>
        string.Equals(Status, "Needs Review", StringComparison.OrdinalIgnoreCase);

    public bool IsDueSoon =>
        !IsCompleted
        && DueDate.Date >= DateTime.Today
        && DueDate.Date <= DateTime.Today.AddDays(7);
}