namespace OperationsFlow.Models;

public class DocumentRecord
{
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public string DocumentNumber { get; set; } = "";
    public string DocumentType { get; set; } = "";

    public string Owner { get; set; } = "";
    public string Department { get; set; } = "";
    public string Status { get; set; } = "";

    public string Version { get; set; } = "";

    public DateTime LastReviewedDate { get; set; }
    public DateTime NextReviewDate { get; set; }

    public string Notes { get; set; } = "";

    public bool IsReviewOverdue => NextReviewDate.Date < DateTime.Today;
    public bool IsDueSoon => NextReviewDate.Date >= DateTime.Today && NextReviewDate.Date <= DateTime.Today.AddDays(30);
}