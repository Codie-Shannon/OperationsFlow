using Microsoft.EntityFrameworkCore;
using OperationsFlow.Data;
using OperationsFlow.Models;

namespace OperationsFlow.Services
{
    public class DashboardService
    {
        private readonly OperationsFlowDbContext _db;

        public DashboardService(OperationsFlowDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardSummary> GetDashboardSummaryAsync()
        {
            var workOrders = await _db.WorkOrders.ToListAsync();
            var correctiveActions = await _db.CorrectiveActions.ToListAsync();
            var documents = await _db.DocumentRecords.ToListAsync();
            var risks = await _db.RiskItems.ToListAsync();
            var trainingRecords = await _db.TrainingRecords.ToListAsync();

            var openWorkOrders = workOrders
                .Where(x => !string.Equals(x.Status, "Completed", StringComparison.OrdinalIgnoreCase)
                         && !string.Equals(x.Status, "Closed", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var openCorrectiveActions = correctiveActions
                .Where(x => !string.Equals(x.Status, "Completed", StringComparison.OrdinalIgnoreCase)
                         && !string.Equals(x.Status, "Closed", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var highOrCriticalRisks = risks
                .Where(x => x.RiskLevel == "High" || x.RiskLevel == "Critical")
                .ToList();

            var requiredTrainingRecords = trainingRecords
                .Where(x => x.IsRequired)
                .ToList();

            var compliantTrainingRecords = requiredTrainingRecords
                .Where(x => !x.IsExpired)
                .ToList();

            decimal trainingComplianceRate = 0;

            if (requiredTrainingRecords.Count > 0)
            {
                trainingComplianceRate =
                    (decimal)compliantTrainingRecords.Count / requiredTrainingRecords.Count * 100;
            }

            return new DashboardSummary
            {
                TotalWorkOrders = workOrders.Count,
                OpenWorkOrders = openWorkOrders.Count,
                OverdueWorkOrders = openWorkOrders.Count(x => x.IsOverdue),

                TotalCorrectiveActions = correctiveActions.Count,
                OpenCorrectiveActions = openCorrectiveActions.Count,
                OverdueCorrectiveActions = openCorrectiveActions.Count(x => x.IsOverdue),

                TotalDocuments = documents.Count,
                DocumentsDueSoon = documents.Count(x => x.IsDueSoon),
                OverdueDocumentReviews = documents.Count(x => x.IsReviewOverdue),

                TotalRisks = risks.Count,
                HighOrCriticalRisks = highOrCriticalRisks.Count,

                TotalTrainingRecords = trainingRecords.Count,
                ExpiredTrainingRecords = trainingRecords.Count(x => x.IsExpired),
                TrainingExpiringSoon = trainingRecords.Count(x => x.IsExpiringSoon),
                TrainingComplianceRate = trainingComplianceRate
            };
        }
    }
}