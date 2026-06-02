namespace OperationsFlow.Models;

public class CorrectiveAction
{
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public string Source { get; set; } = "";

    public string Site { get; set; } = "";
    public string Department { get; set; } = "";
    public string Owner { get; set; } = "";

    public string ActionType { get; set; } = "";
    public string Priority { get; set; } = "";
    public string Status { get; set; } = "";

    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }

    public string Notes { get; set; } = "";

    public bool IsOverdue => Status != "Completed" && DueDate.Date < DateTime.Today;
}