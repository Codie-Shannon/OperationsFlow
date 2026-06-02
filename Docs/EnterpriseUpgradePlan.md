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
- Supervisor
- Worker
- Viewer

Examples:

- Admin can edit settings.
- Manager can view reports.
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

---

## Phase 7 - File Storage and Attachments

Goal: make Document Intake handle real files.

Future features:

- Upload file
- Link file to intake record
- Store file metadata
- Preview/download attachment
- Mark attachment type
- Track storage location

Possible storage options:

- Local storage for development
- Azure Blob Storage
- SharePoint document library

---

## Phase 8 - Microsoft 365 Integration

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
- Reports exported to Power BI.

---

## Phase 9 - Business System Integrations

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

## Phase 10 - API Layer and Testing

Goal: prepare for production maintainability.

Add:

- Web API endpoints
- DTOs/request models
- Validation layer
- Unit tests
- Integration tests
- Seed/test data helpers
- Error logging
- CI/CD pipeline

---

## Phase 11 - Deployment

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
Audit + Attachments
↓
Integrations
↓
API + Tests
↓
Deployment
```

This allows the current project to remain useful as a portfolio demo while also providing a realistic path toward a full internal business system.
