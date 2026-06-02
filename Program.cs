using Microsoft.EntityFrameworkCore;
using OperationsFlow.Components;
using OperationsFlow.Data;
using OperationsFlow.SeedData;
using OperationsFlow.Services;

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

app.Run();