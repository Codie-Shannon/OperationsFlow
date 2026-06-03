# Enterprise Upgrade Plan

This document explains how the current OperationsFlow portfolio prototype could evolve into a more enterprise-ready internal business system.

The current app is a semi-live local prototype. The steps below are future upgrades and should not be read as existing functionality unless already implemented elsewhere in the project.

---

## Phase 1 - Stabilise the Portfolio Version

Goal: keep the current version clean, demoable, and understandable.

Tasks:

- Add final screenshots.
- Keep README updated.
- Keep case study and roadmap clear.
- Confirm Safety Overview counts and quick links.
- Confirm Vanessa/OSHE demo path starts with Safety Overview.
- Confirm all CSV exports.
- Confirm dashboard/report/reminder/workload counts.
- Confirm activity logging.
- Confirm data quality page.
- Keep known limitations honest.

---

## Phase 2 - Service Layer Refactor

Goal: reduce direct business logic in Razor pages.

Current direction already started with:

- `DashboardService`
- `ActivityLogService`
- `CsvExportService`

Future services:

- `WorkOrderService`
- `CorrectiveActionService`
- `DocumentIntakeService`
- `SafetyOverviewService`
- `ReportService`
- `ReminderService`
- `WorkloadService`
- `SettingsService`
- `DemoDataService`

Target structure:

```text
Page
↓
Service
↓
DbContext
```

Benefits:

- Easier testing.
- Easier future API layer.
- Cleaner pages.
- Reusable business logic.
- Better enterprise architecture.
- Easier to maintain safety/compliance aggregation rules.

---

## Phase 3 - Database-Driven Settings

Goal: replace hardcoded option lists with database-managed settings.

Add a model such as:

```csharp
public class SystemOption
{
    public int Id { get; set; }
    public string GroupName { get; set; } = "";
    public string Value { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
}
```

Potential option groups:

- Priority
- WorkOrderStatus
- CorrectiveActionStatus
- DocumentIntakeStatus
- TargetSystem
- DocumentType
- SourceType
- Department
- Site
- RiskLevel
- TrainingStatus
- DocumentReviewStatus

Admin Settings would eventually allow users to create/edit/deactivate settings.

---

## Phase 4 - EF Core Migrations and Production Database

Goal: move from prototype database handling to production-style schema management.

Tasks:

- Add EF Core migrations.
- Stop relying on deleting local database files for schema changes.
- Support SQL Server, PostgreSQL, or Azure SQL.
- Add connection string configuration.
- Add development/test/production environment settings.

---

## Phase 5 - Authentication and Roles

Goal: introduce real users and permissions.

Possible options:

- ASP.NET Core Identity
- Microsoft Entra ID / Azure AD

Potential roles:

- Admin
- Manager
- Safety Manager
- Compliance Manager
- Supervisor
- Worker
- Viewer

Examples:

- Admin can edit settings.
- Manager can view reports.
- Safety Manager can review corrective actions, risks, training, and document review issues.
- Compliance Manager can review audit/activity history and export reports.
- Supervisor can assign work.
- Worker can update assigned tasks.
- Viewer can read only.

---

## Phase 6 - Improved Audit Trail

Goal: expand current Activity Log into more detailed audit history.

Current implemented activity logging is record-level.

Future audit fields:

- Record type
- Record ID
- Field name
- Old value
- New value
- Changed by user ID
- Changed date/time
- Source page/action
- Optional IP/device metadata if required

This would support a stronger compliance/audit story.

For safety/compliance workflows, audit history could show:

- Corrective action status changes
- Risk review changes
- Training compliance updates
- Document review completion
- Owner/priority/due date changes
- Export/report generation events, if required

---

## Phase 7 - Safety and Compliance Workflow Upgrades

Goal: evolve Safety Overview from a prototype dashboard into a stronger OSHE/compliance workspace.

Future features:

- Role-based safety/compliance views.
- Configurable attention thresholds.
- Automated overdue corrective action notifications.
- Scheduled training expiry reminders.
- Document review reminders.
- Document review approval workflow.
- Corrective action escalation rules.
- Risk review scheduling.
- Compliance calendar view.
- Safety meeting export pack.
- Power BI-ready reporting feed.
- Audit-grade activity history with real user IDs.

These are roadmap items only. The current prototype demonstrates the workflow direction using local SQLite/demo data.

---

## Phase 8 - File Storage and Attachments

Goal: make Document Intake and Document Control handle real files.

Future features:

- Upload file
- Link file to intake record
- Link file to document review record
- Store file metadata
- Preview/download attachment
- Mark attachment type
- Track storage location
- Document version attachment history

Possible storage options:

- Local storage for development
- Azure Blob Storage
- SharePoint document library

---

## Phase 9 - Microsoft 365 Integration

Goal: connect OperationsFlow to Microsoft 365 workflows.

Possible integrations:

- Outlook email intake
- SharePoint document libraries
- Teams notifications
- Microsoft Lists
- Power BI export/feed
- Entra ID authentication

Examples:

- Incoming Outlook email creates Document Intake record.
- Uploaded file stored in SharePoint.
- Overdue corrective action sends Teams notification.
- Training expiring soon sends reminder.
- Document review due soon sends reminder.
- Reports exported to Power BI.

---

## Phase 10 - Business System Integrations

Goal: connect Document Intake and workflow records to external systems.

Possible systems:

- Xero
- Cin7
- WorkflowMax-style job tracking
- Internal business databases

Possible architecture:

- Integration queue
- Export status
- Sync status
- Failed sync review
- Retry mechanism
- Manual override

---

## Phase 11 - API Layer and Testing

Goal: prepare for production maintainability.

Add:

- Web API endpoints
- DTOs/request models
- Validation layer
- Unit tests
- Integration tests
- Safety/compliance calculation tests
- Export tests
- Seed/test data helpers
- Error logging
- CI/CD pipeline

---

## Phase 12 - Deployment

Goal: make OperationsFlow deployable.

Possible deployment targets:

- Azure App Service
- IIS
- Docker
- Internal company server

Required production concerns:

- Secure connection strings
- HTTPS
- Backup strategy
- Error logging
- User access management
- Database migrations
- Monitoring

---

## Enterprise Summary

The current OperationsFlow prototype already demonstrates the workflow and business value.

The enterprise upgrade path is:

```text
Portfolio Prototype
↓
Service Layer
↓
Database-Driven Settings
↓
Production Database + Migrations
↓
Authentication + Roles
↓
Audit + Safety/Compliance Workflow
↓
Attachments
↓
Integrations
↓
API + Tests
↓
Deployment
```

This allows the current project to remain useful as a portfolio demo while also providing a realistic path toward a full internal business system.
