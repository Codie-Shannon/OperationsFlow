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
    .AddInteractiveServerComponents(options =>
    {
        options.DetailedErrors = true;
    });

builder.Services.Configure<OperationsFlowOptions>(
    builder.Configuration.GetSection(OperationsFlowOptions.SectionName));

builder.Services.Configure<FileStorageOptions>(
    builder.Configuration.GetSection(FileStorageOptions.SectionName));

builder.Services.Configure<Microsoft365Options>(
    builder.Configuration.GetSection(Microsoft365Options.SectionName));

builder.Services.Configure<NotificationOptions>(
    builder.Configuration.GetSection(NotificationOptions.SectionName));

var databaseProvider = builder.Configuration["DatabaseProvider"] ?? "Sqlite";

builder.Services.AddDbContext<OperationsFlowDbContext>(options =>
{
    if (databaseProvider.Equals("SqlServer", StringComparison.OrdinalIgnoreCase))
    {
        var sqlServerConnectionString = builder.Configuration.GetConnectionString("OperationsFlowSqlServer")
            ?? "Server=(localdb)\\ProjectModels;Database=OperationsFlowWeek3Auth;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";

        options.UseSqlServer(sqlServerConnectionString);
    }
    else
    {
        var sqliteConnectionString = builder.Configuration.GetConnectionString("OperationsFlowDatabase")
            ?? "Data Source=operationsflow.db";

        options.UseSqlite(sqliteConnectionString);
    }
});

builder.Services.AddScoped<ActivityLogService>();
builder.Services.AddScoped<CsvExportService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<DocumentAttachmentService>();

builder.Services.AddScoped<LocalFileStorageService>();
builder.Services.AddScoped<SharePointFileStorageService>();

builder.Services.AddScoped<DatabaseSchemaService>();
builder.Services.AddScoped<LocalIdentityService>();
builder.Services.AddScoped<LocalCurrentUserService>();
builder.Services.AddScoped<LocalAuthService>();

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

    var databaseSchemaService = scope.ServiceProvider.GetRequiredService<DatabaseSchemaService>();
    var localIdentityService = scope.ServiceProvider.GetRequiredService<LocalIdentityService>();

    db.Database.EnsureCreated();

    await databaseSchemaService.EnsureDocumentAttachmentsTableAsync();

    if (operationsFlowOptions.EnableDemoDataSeeding)
    {
        DemoDataSeeder.Seed(db);
    }

    await localIdentityService.EnsureSeedDataAsync();
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

app.Run();