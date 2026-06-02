using System.Text;
using Microsoft.EntityFrameworkCore;
using OperationsFlow.Data;

namespace OperationsFlow.Services;

public class CsvExportService
{
    private readonly OperationsFlowDbContext _db;

    public CsvExportService(OperationsFlowDbContext db)
    {
        _db = db;
    }

    public async Task<string> ExportWorkOrdersAsync()
    {
        var rows = await _db.WorkOrders
            .AsNoTracking()
            .OrderBy(x => x.WorkOrderNumber)
            .ToListAsync();

        var csv = new StringBuilder();

        csv.AppendLine("Work Order Number,Title,Site,Department,Owner,Type,Priority,Status,Created Date,Due Date,Is Overdue,Notes");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape(item.WorkOrderNumber),
                Escape(item.Title),
                Escape(item.Site),
                Escape(item.Department),
                Escape(item.Owner),
                Escape(item.Type),
                Escape(item.Priority),
                Escape(item.Status),
                Escape(item.CreatedDate.ToString("yyyy-MM-dd")),
                Escape(item.DueDate.ToString("yyyy-MM-dd")),
                Escape(item.IsOverdue ? "Yes" : "No"),
                Escape(item.Notes)
            ));
        }

        return csv.ToString();
    }

    public async Task<string> ExportCorrectiveActionsAsync()
    {
        var rows = await _db.CorrectiveActions
            .AsNoTracking()
            .ToListAsync();

        rows = rows
            .OrderByDescending(x => x.IsOverdue)
            .ThenBy(x => x.DueDate)
            .ToList();

        var csv = new StringBuilder();

        csv.AppendLine("Reference,Title,Source,Site,Department,Owner,Action Type,Priority,Status,Created Date,Due Date,Completed Date,Is Overdue,Notes");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape($"CA-{item.Id}"),
                Escape(item.Title),
                Escape(item.Source),
                Escape(item.Site),
                Escape(item.Department),
                Escape(item.Owner),
                Escape(item.ActionType),
                Escape(item.Priority),
                Escape(item.Status),
                Escape(item.CreatedDate.ToString("yyyy-MM-dd")),
                Escape(item.DueDate.ToString("yyyy-MM-dd")),
                Escape(item.CompletedDate?.ToString("yyyy-MM-dd") ?? ""),
                Escape(item.IsOverdue ? "Yes" : "No"),
                Escape(item.Notes)
            ));
        }

        return csv.ToString();
    }

    public async Task<string> ExportRiskRegisterAsync()
    {
        var rows = await _db.RiskItems
            .AsNoTracking()
            .ToListAsync();

        rows = rows
            .OrderByDescending(x => x.RiskScore)
            .ThenBy(x => x.Title)
            .ToList();

        var csv = new StringBuilder();

        csv.AppendLine("Risk,Hazard,Site,Department,Owner,Likelihood,Consequence,Risk Score,Risk Level,Controls,Status,Review Date,Review Overdue");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape(item.Title),
                Escape(item.Hazard),
                Escape(item.Site),
                Escape(item.Department),
                Escape(item.Owner),
                Escape(item.Likelihood.ToString()),
                Escape(item.Consequence.ToString()),
                Escape(item.RiskScore.ToString()),
                Escape(item.RiskLevel),
                Escape(item.Controls),
                Escape(item.Status),
                Escape(item.ReviewDate.ToString("yyyy-MM-dd")),
                Escape(item.IsReviewOverdue ? "Yes" : "No")
            ));
        }

        return csv.ToString();
    }

    public async Task<string> ExportTrainingAsync()
    {
        var rows = await _db.TrainingRecords
            .AsNoTracking()
            .ToListAsync();

        rows = rows
            .OrderByDescending(x => x.IsExpired)
            .ThenByDescending(x => x.IsExpiringSoon)
            .ThenBy(x => x.Department)
            .ThenBy(x => x.StaffName)
            .ToList();

        var csv = new StringBuilder();

        csv.AppendLine("Staff Name,Training Name,Site,Department,Status,Completed Date,Expiry Date,Required,Expired,Expiring Soon,Notes");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape(item.StaffName),
                Escape(item.TrainingName),
                Escape(item.Site),
                Escape(item.Department),
                Escape(item.Status),
                Escape(item.CompletedDate.ToString("yyyy-MM-dd")),
                Escape(item.ExpiryDate.ToString("yyyy-MM-dd")),
                Escape(item.IsRequired ? "Yes" : "No"),
                Escape(item.IsExpired ? "Yes" : "No"),
                Escape(item.IsExpiringSoon ? "Yes" : "No"),
                Escape(item.Notes)
            ));
        }

        return csv.ToString();
    }

    public async Task<string> ExportDocumentReviewsAsync()
    {
        var rows = await _db.DocumentRecords
            .AsNoTracking()
            .ToListAsync();

        rows = rows
            .OrderByDescending(x => x.IsReviewOverdue)
            .ThenByDescending(x => x.IsDueSoon)
            .ThenBy(x => x.NextReviewDate)
            .ToList();

        var csv = new StringBuilder();

        csv.AppendLine("Document Number,Title,Document Type,Owner,Department,Status,Version,Last Reviewed Date,Next Review Date,Review Overdue,Due Soon,Notes");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape(item.DocumentNumber),
                Escape(item.Title),
                Escape(item.DocumentType),
                Escape(item.Owner),
                Escape(item.Department),
                Escape(item.Status),
                Escape(item.Version),
                Escape(item.LastReviewedDate.ToString("yyyy-MM-dd")),
                Escape(item.NextReviewDate.ToString("yyyy-MM-dd")),
                Escape(item.IsReviewOverdue ? "Yes" : "No"),
                Escape(item.IsDueSoon ? "Yes" : "No"),
                Escape(item.Notes)
            ));
        }

        return csv.ToString();
    }

    public async Task<string> ExportActivityLogAsync()
    {
        var rows = await _db.ActivityLogs
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();

        var csv = new StringBuilder();

        csv.AppendLine("Date,Module,Record Id,Record Reference,Action Type,Description,Created By");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape(item.CreatedDate.ToString("yyyy-MM-dd HH:mm")),
                Escape(item.ModuleName),
                Escape(item.RecordId.ToString()),
                Escape(item.RecordReference),
                Escape(item.ActionType),
                Escape(item.Description),
                Escape(item.CreatedBy)
            ));
        }

        return csv.ToString();
    }

    public async Task<string> ExportDocumentIntakeAsync()
    {
        var rows = await _db.DocumentIntakeItems
            .AsNoTracking()
            .ToListAsync();

        rows = rows
            .OrderByDescending(x => x.IsOverdue)
            .ThenByDescending(x => x.NeedsReview)
            .ThenBy(x => x.DueDate)
            .ThenBy(x => x.DocumentName)
            .ToList();

        var csv = new StringBuilder();

        csv.AppendLine("Reference,Document Name,Received Date,Received From,Source Type,Document Type,Assigned To,Target System,Priority,Status,Due Date,Completed Date,Overdue,Needs Review,Due Soon,Notes");

        foreach (var item in rows)
        {
            csv.AppendLine(string.Join(",",
                Escape($"DI-{item.Id}"),
                Escape(item.DocumentName),
                Escape(item.ReceivedDate.ToString("yyyy-MM-dd")),
                Escape(item.ReceivedFrom),
                Escape(item.SourceType),
                Escape(item.DocumentType),
                Escape(item.AssignedTo),
                Escape(item.TargetSystem),
                Escape(item.Priority),
                Escape(item.Status),
                Escape(item.DueDate.ToString("yyyy-MM-dd")),
                Escape(item.CompletedDate?.ToString("yyyy-MM-dd") ?? ""),
                Escape(item.IsOverdue ? "Yes" : "No"),
                Escape(item.NeedsReview ? "Yes" : "No"),
                Escape(item.IsDueSoon ? "Yes" : "No"),
                Escape(item.Notes)
            ));
        }

        return csv.ToString();
    }

    private static string Escape(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return "";
        }

        var escaped = value.Replace("\"", "\"\"");

        if (escaped.Contains(',') || escaped.Contains('"') || escaped.Contains('\n') || escaped.Contains('\r'))
        {
            return $"\"{escaped}\"";
        }

        return escaped;
    }
}