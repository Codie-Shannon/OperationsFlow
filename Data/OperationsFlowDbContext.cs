using Microsoft.EntityFrameworkCore;
using OperationsFlow.Models;

namespace OperationsFlow.Data;

public class OperationsFlowDbContext : DbContext
{
    public OperationsFlowDbContext(DbContextOptions<OperationsFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
    public DbSet<CorrectiveAction> CorrectiveActions => Set<CorrectiveAction>();
    public DbSet<DocumentRecord> DocumentRecords => Set<DocumentRecord>();
    public DbSet<RiskItem> RiskItems => Set<RiskItem>();
    public DbSet<TrainingRecord> TrainingRecords => Set<TrainingRecord>();
    public DbSet<Site> Sites => Set<Site>();
    public DbSet<Department> Departments => Set<Department>();
}