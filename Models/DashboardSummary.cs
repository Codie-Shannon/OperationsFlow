namespace OperationsFlow.Models;

public class DashboardSummary
{
    public int TotalWorkOrders { get; set; }
    public int OpenWorkOrders { get; set; }
    public int OverdueWorkOrders { get; set; }

    public int TotalCorrectiveActions { get; set; }
    public int OpenCorrectiveActions { get; set; }
    public int OverdueCorrectiveActions { get; set; }

    public int TotalDocuments { get; set; }
    public int DocumentsDueSoon { get; set; }
    public int OverdueDocumentReviews { get; set; }

    public int TotalRisks { get; set; }
    public int HighOrCriticalRisks { get; set; }

    public int TotalTrainingRecords { get; set; }
    public int ExpiredTrainingRecords { get; set; }
    public int TrainingExpiringSoon { get; set; }

    public decimal TrainingComplianceRate { get; set; }

    public int TotalDocumentIntakeItems { get; set; }
    public int OpenDocumentIntakeItems { get; set; }
    public int DocumentIntakeNeedsReview { get; set; }
    public int OverdueDocumentIntakeItems { get; set; }
    public int DocumentIntakeDueSoon { get; set; }
    public int CompletedDocumentIntakeItems { get; set; }
}