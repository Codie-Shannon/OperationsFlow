using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OperationsFlow.Components;
using OperationsFlow.Data;
using OperationsFlow.Options;
using OperationsFlow.SeedData;
using OperationsFlow.Services;
using OperationsFlow.Services.Storage;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<OperationsFlowOptions>(
    builder.Configuration.GetSection(OperationsFlowOptions.SectionName));

builder.Services.Configure<FileStorageOptions>(
    builder.Configuration.GetSection(FileStorageOptions.SectionName));

builder.Services.Configure<Microsoft365Options>(
    builder.Configuration.GetSection(Microsoft365Options.SectionName));

builder.Services.Configure<NotificationOptions>(
    builder.Configuration.GetSection(NotificationOptions.SectionName));

builder.Services.AddDbContext<OperationsFlowDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("OperationsFlowDatabase")
        ?? "Data Source=operationsflow.db";

    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<ActivityLogService>();
builder.Services.AddScoped<CsvExportService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<DocumentAttachmentService>();

builder.Services.AddScoped<LocalFileStorageService>();
builder.Services.AddScoped<SharePointFileStorageService>();

builder.Services.AddScoped<IFileStorageService>(serviceProvider =>
{
    var options = serviceProvider
        .GetRequiredService<IOptions<FileStorageOptions>>()
        .Value;

    if (options.IsSharePointProvider)
    {
        return serviceProvider.GetRequiredService<SharePointFileStorageService>();
    }

    return serviceProvider.GetRequiredService<LocalFileStorageService>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OperationsFlowDbContext>();
    var operationsFlowOptions = scope.ServiceProvider
        .GetRequiredService<IOptions<OperationsFlowOptions>>()
        .Value;

    db.Database.EnsureCreated();
    EnsureDocumentAttachmentsTable(db);

    if (operationsFlowOptions.EnableDemoDataSeeding)
    {
        DemoDataSeeder.Seed(db);
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/exports/work-orders.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportWorkOrdersAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-work-orders.csv");
});

app.MapGet("/exports/corrective-actions.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportCorrectiveActionsAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-corrective-actions.csv");
});

app.MapGet("/exports/risk-register.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportRiskRegisterAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-risk-register.csv");
});

app.MapGet("/exports/training.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportTrainingAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-training.csv");
});

app.MapGet("/exports/document-reviews.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportDocumentReviewsAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-document-reviews.csv");
});

app.MapGet("/exports/activity-log.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportActivityLogAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-activity-log.csv");
});

app.MapGet("/exports/document-intake.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportDocumentIntakeAsync();

    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-document-intake.csv");
});

static void EnsureDocumentAttachmentsTable(OperationsFlowDbContext db)
{
    db.Database.ExecuteSqlRaw("""
        CREATE TABLE IF NOT EXISTS "DocumentAttachments" (
            "Id" INTEGER NOT NULL CONSTRAINT "PK_DocumentAttachments" PRIMARY KEY AUTOINCREMENT,
            "ModuleName" TEXT NOT NULL,
            "RecordId" INTEGER NULL,
            "RecordReference" TEXT NOT NULL,
            "OriginalFileName" TEXT NOT NULL,
            "StoredFileName" TEXT NOT NULL,
            "StoredRelativePath" TEXT NOT NULL,
            "PublicUrl" TEXT NOT NULL,
            "ContentType" TEXT NOT NULL,
            "FileSizeBytes" INTEGER NOT NULL,
            "StorageProvider" TEXT NOT NULL,
            "UploadedBy" TEXT NOT NULL,
            "UploadedDate" TEXT NOT NULL,
            "Notes" TEXT NOT NULL,
            "Status" TEXT NOT NULL,
            "IsEvidence" INTEGER NOT NULL,
            "IsControlledDocument" INTEGER NOT NULL,
            "IsDeleted" INTEGER NOT NULL,
            "DeletedDate" TEXT NULL,
            "DeletedBy" TEXT NOT NULL
        );
    """);

    db.Database.ExecuteSqlRaw("""
        CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_ModuleName"
        ON "DocumentAttachments" ("ModuleName");
    """);

    db.Database.ExecuteSqlRaw("""
        CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_RecordId"
        ON "DocumentAttachments" ("RecordId");
    """);

    db.Database.ExecuteSqlRaw("""
        CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_ModuleName_RecordId"
        ON "DocumentAttachments" ("ModuleName", "RecordId");
    """);

    db.Database.ExecuteSqlRaw("""
        CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_UploadedDate"
        ON "DocumentAttachments" ("UploadedDate");
    """);

    db.Database.ExecuteSqlRaw("""
        CREATE INDEX IF NOT EXISTS "IX_DocumentAttachments_IsDeleted"
        ON "DocumentAttachments" ("IsDeleted");
    """);
}

app.Run();