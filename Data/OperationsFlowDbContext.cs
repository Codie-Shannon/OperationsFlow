using Microsoft.EntityFrameworkCore;
using OperationsFlow.Models;

namespace OperationsFlow.Data;

public class OperationsFlowDbContext : DbContext
{
    public OperationsFlowDbContext(DbContextOptions<OperationsFlowDbContext> options) : base(options)
    {
    }

    public DbSet<WorkOrder> WorkOrders { get; set; }

    public DbSet<CorrectiveAction> CorrectiveActions { get; set; }

    public DbSet<DocumentIntake> DocumentIntakeItems { get; set; }

    public DbSet<DocumentRecord> DocumentRecords { get; set; }

    public DbSet<RiskItem> RiskItems { get; set; }

    public DbSet<TrainingRecord> TrainingRecords { get; set; }

    public DbSet<Site> Sites { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<ActivityLog> ActivityLogs { get; set; }

    public DbSet<DocumentAttachment> DocumentAttachments { get; set; }

    public DbSet<LocalUser> LocalUsers { get; set; }

    public DbSet<LocalRole> LocalRoles { get; set; }

    public DbSet<LocalUserRole> LocalUserRoles { get; set; }

    public DbSet<LocalPermission> LocalPermissions { get; set; }

    public DbSet<LocalRolePermission> LocalRolePermissions { get; set; }

    public DbSet<ExternalLoginLink> ExternalLoginLinks { get; set; }

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

        modelBuilder.Entity<LocalUser>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.UserName)
                .HasMaxLength(120)
                .IsRequired();

            entity.Property(x => x.DisplayName)
                .HasMaxLength(160)
                .IsRequired();

            entity.Property(x => x.Email)
                .HasMaxLength(240)
                .IsRequired();

            entity.Property(x => x.Department)
                .HasMaxLength(160);

            entity.Property(x => x.JobTitle)
                .HasMaxLength(160);

            entity.Property(x => x.Notes)
                .HasMaxLength(1000);

            entity.HasIndex(x => x.UserName)
                .IsUnique();

            entity.HasIndex(x => x.Email);
        });

        modelBuilder.Entity<LocalRole>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(x => x.DisplayName)
                .HasMaxLength(120)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.Property(x => x.BadgeTone)
                .HasMaxLength(40);

            entity.HasIndex(x => x.Name)
                .IsUnique();
        });

        modelBuilder.Entity<LocalUserRole>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.AssignedBy)
                .HasMaxLength(160);

            entity.Property(x => x.Notes)
                .HasMaxLength(1000);

            entity.HasIndex(x => new { x.LocalUserId, x.LocalRoleId })
                .IsUnique();
        });

        modelBuilder.Entity<LocalPermission>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Key)
                .HasMaxLength(120)
                .IsRequired();

            entity.Property(x => x.DisplayName)
                .HasMaxLength(160)
                .IsRequired();

            entity.Property(x => x.Category)
                .HasMaxLength(120);

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.HasIndex(x => x.Key)
                .IsUnique();
        });

        modelBuilder.Entity<LocalRolePermission>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.AccessLevel)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(x => x.Notes)
                .HasMaxLength(1000);

            entity.HasIndex(x => new { x.LocalRoleId, x.LocalPermissionId })
                .IsUnique();
        });

        modelBuilder.Entity<ExternalLoginLink>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Provider)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(x => x.ProviderUserId)
                .HasMaxLength(240)
                .IsRequired();

            entity.Property(x => x.ProviderEmail)
                .HasMaxLength(240);

            entity.Property(x => x.ProviderDisplayName)
                .HasMaxLength(160);

            entity.Property(x => x.Notes)
                .HasMaxLength(1000);

            entity.HasIndex(x => new { x.Provider, x.ProviderUserId });

            entity.HasIndex(x => new { x.LocalUserId, x.Provider })
                .IsUnique();
        });
    }
}