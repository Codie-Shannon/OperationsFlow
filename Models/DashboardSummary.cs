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
}