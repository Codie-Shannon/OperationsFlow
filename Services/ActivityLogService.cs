using OperationsFlow.Data;
using OperationsFlow.Models;

namespace OperationsFlow.Services;

public class ActivityLogService
{
    private readonly OperationsFlowDbContext db;

    public ActivityLogService(OperationsFlowDbContext db)
    {
        this.db = db;
    }

    public async Task LogAsync(
        string moduleName,
        int recordId,
        string recordReference,
        string actionType,
        string description,
        string createdBy = "System")
    {
        var activityLog = new ActivityLog
        {
            ModuleName = string.IsNullOrWhiteSpace(moduleName) ? "Unknown" : moduleName,
            RecordId = recordId,
            RecordReference = recordReference ?? "",
            ActionType = string.IsNullOrWhiteSpace(actionType) ? "Activity" : actionType,
            Description = description ?? "",
            CreatedBy = string.IsNullOrWhiteSpace(createdBy) ? "System" : createdBy,
            CreatedDate = DateTime.Now
        };

        db.ActivityLogs.Add(activityLog);

        await db.SaveChangesAsync();
    }
}