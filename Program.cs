using Microsoft.EntityFrameworkCore;
using OperationsFlow.Components;
using OperationsFlow.Data;
using OperationsFlow.SeedData;
using OperationsFlow.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<OperationsFlowDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("OperationsFlowDatabase")
        ?? "Data Source=operationsflow.db";

    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<ActivityLogService>();
builder.Services.AddScoped<CsvExportService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OperationsFlowDbContext>();
    DemoDataSeeder.Seed(db);
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
        "operationsflow-work-orders.csv"
    );
});

app.MapGet("/exports/corrective-actions.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportCorrectiveActionsAsync();
    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-corrective-actions.csv"
    );
});

app.MapGet("/exports/risk-register.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportRiskRegisterAsync();
    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-risk-register.csv"
    );
});

app.MapGet("/exports/training.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportTrainingAsync();
    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-training.csv"
    );
});

app.MapGet("/exports/document-reviews.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportDocumentReviewsAsync();
    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-document-reviews.csv"
    );
});

app.MapGet("/exports/activity-log.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportActivityLogAsync();
    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-activity-log.csv"
    );
});

app.MapGet("/exports/document-intake.csv", async (CsvExportService csvExportService) =>
{
    var csv = await csvExportService.ExportDocumentIntakeAsync();
    return Results.File(
        Encoding.UTF8.GetBytes(csv),
        "text/csv",
        "operationsflow-document-intake.csv"
    );
});

app.Run();