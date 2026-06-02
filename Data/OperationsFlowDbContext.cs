using Microsoft.EntityFrameworkCore;
using OperationsFlow.Models;

namespace OperationsFlow.Data;

public class OperationsFlowDbContext : DbContext
{
    public OperationsFlowDbContext(DbContextOptions<OperationsFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<CorrectiveAction> CorrectiveActions { get; set; }
    public DbSet<DocumentRecord> DocumentRecords { get; set; }
    public DbSet<RiskItem> RiskItems { get; set; }
    public DbSet<TrainingRecord> TrainingRecords { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ActivityLog> ActivityLogs { get; set; }
    public DbSet<DocumentIntake> DocumentIntakeItems { get; set; }
}