using Microsoft.EntityFrameworkCore;
using OperationsFlow.Models;

namespace OperationsFlow.Data;

public class OperationsFlowDbContext : DbContext
{
    public OperationsFlowDbContext(DbContextOptions options) : base(options)
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

    public DbSet<DocumentAttachment> DocumentAttachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DocumentAttachment>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.ModuleName)
                .HasMaxLength(120)
                .IsRequired();

            entity.Property(x => x.RecordReference)
                .HasMaxLength(240);

            entity.Property(x => x.OriginalFileName)
                .HasMaxLength(260)
                .IsRequired();

            entity.Property(x => x.StoredFileName)
                .HasMaxLength(260)
                .IsRequired();

            entity.Property(x => x.StoredRelativePath)
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(x => x.PublicUrl)
                .HasMaxLength(500);

            entity.Property(x => x.ContentType)
                .HasMaxLength(160)
                .IsRequired();

            entity.Property(x => x.StorageProvider)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(x => x.UploadedBy)
                .HasMaxLength(160)
                .IsRequired();

            entity.Property(x => x.Notes)
                .HasMaxLength(2000);

            entity.Property(x => x.Status)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(x => x.DeletedBy)
                .HasMaxLength(160);

            entity.HasIndex(x => x.ModuleName);
            entity.HasIndex(x => x.RecordId);
            entity.HasIndex(x => new { x.ModuleName, x.RecordId });
            entity.HasIndex(x => x.UploadedDate);
            entity.HasIndex(x => x.IsDeleted);
        });
    }
}