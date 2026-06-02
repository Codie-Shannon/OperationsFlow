using OperationsFlow.Data;
using OperationsFlow.Models;

namespace OperationsFlow.Services;

public class ActivityLogService
{
    private readonly OperationsFlowDbContext _db;

    public ActivityLogService(OperationsFlowDbContext db)
    {
        _db = db;
    }

    public async Task LogAsync(
        string moduleName,
        int recordId,
        string recordReference,
        string actionType,
        string description,
        string createdBy = "Demo User")
    {
        var activityLog = new ActivityLog
        {
            ModuleName = moduleName,
            RecordId = recordId,
            RecordReference = recordReference,
            ActionType = actionType,
            Description = description,
            CreatedBy = createdBy,
            CreatedDate = DateTime.Now
        };

        _db.ActivityLogs.Add(activityLog);
        await _db.SaveChangesAsync();
    }
}