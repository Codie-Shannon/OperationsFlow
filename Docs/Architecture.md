# OperationsFlow Architecture

## Overview

OperationsFlow is a Blazor/.NET 8 portfolio prototype using local SQLite data persistence. It demonstrates practical business workflow tracking, reporting, CSV exports, reminders, workload visibility, data quality checks, activity traceability, and production planning.

The project is intentionally honest about scope. It is a working local prototype, not a finished production ERP or hosted enterprise system.

---

## Current Implemented Architecture

```text
Blazor UI
↓
Razor Components / Pages
↓
Application Services
↓
Entity Framework Core
↓
SQLite Database
```

Current implemented services include:

- `DashboardService`
- `ActivityLogService`
- `CsvExportService`

The app currently behaves like this:

```text
Create/Edit record
↓
SQLite data updates
↓
Dashboard/reports/reminders/workload update
↓
Activity Log records the change
↓
CSV export reflects the saved data
```

---

## Current Main Modules

Implemented/reviewable modules include:

- Dashboard
- Work Orders
- Corrective Actions
- Safety Overview
- Safety Meeting Pack
- Compliance Calendar
- Controlled Documents
- Risk Register
- Training Compliance
- Document Intake
- Reminder Centre
- Workload
- Reports
- Data Quality
- Activity Log
- Admin Settings starter

Reviewer/support pages include:

- Portfolio Hub
- Reviewer Checklist
- Demo Guide
- Business Value
- Prototype Scope
- Implementation Plan
- Technical Overview
- Data Model
- User Roles
- Audit Overview
- Deployment Overview
- Testing Overview
- Integration Overview

---

## Data Storage

Current prototype storage:

- SQLite
- Entity Framework Core
- Seeded demo data
- Local database files during development

This supports real create/edit/save/report behaviour for portfolio review.

Future production storage would move to:

- SQL Server
- Azure SQL
- PostgreSQL
- Another approved hosted database

Production storage would also require:

- EF Core migrations
- Backup/restore procedures
- Access control
- Environment-specific connection strings
- Monitoring

---

## Activity Logging Flow

Current activity logging is record-level traceability.

```text
User creates or edits a record
↓
Page saves changes through EF Core
↓
ActivityLogService creates an ActivityLog record
↓
Activity appears in:
- Global Activity Log
- Dashboard Recent Activity
- Per-record Activity History
```

Current Activity Log fields include:

- Module name
- Record ID
- Record reference
- Action type
- Description
- Created by
- Created date

Future production audit logging would add:

- Authenticated user ID
- Field name
- Old value
- New value
- Event type
- Source page/action
- Export history
- Admin/security events

---

## CSV Export Flow

CSV exports are implemented through app endpoints and `CsvExportService`.

```text
User clicks export link
↓
Endpoint calls CsvExportService
↓
Service reads records from SQLite through EF Core
↓
CSV string is generated
↓
Browser downloads CSV file
```

Current export areas include:

- Work Orders
- Corrective Actions
- Risk Register
- Training
- Document Reviews
- Activity Log
- Document Intake

---

## Document Intake Workflow

The current Document Intake module tracks incoming admin/document processing records.

Implemented fields include:

- Document name
- Received date
- Received from
- Source type
- Document type
- Assigned to
- Target system
- Status
- Priority
- Due date
- Completed date
- Notes

Current target system values include demo options such as:

- SharePoint
- Xero
- Cin7
- WorkflowMax
- Email Folder
- Internal System

These are tracked as workflow metadata only. The app does not currently integrate live with those external systems.

---

## Reporting and Management Views

Current management views include:

- Dashboard KPIs
- Recent Activity
- Reminder Centre
- Workload
- Reports
- Data Quality
- Activity Log
- Safety Meeting Pack
- Compliance Calendar

These views reuse the same workflow records to show owner pressure, overdue work, attention items, weak records, management summaries, and review evidence.

---

## Production Architecture Direction

A future production version may move toward:

```text
OperationsFlow.Web
OperationsFlow.Application
OperationsFlow.Domain
OperationsFlow.Infrastructure
OperationsFlow.Shared
OperationsFlow.Tests
```

Target flow:

```text
Blazor UI
↓
Application Services
↓
Domain / Business Rules
↓
Infrastructure
↓
SQL Server / Azure SQL / PostgreSQL
↓
Authentication / Permissions / Integrations
```

---

## Future Architecture Upgrades

Future upgrades could include:

- Service-layer refactor for all modules.
- Request/view models instead of editing EF entities directly in forms.
- EF Core migrations.
- SQL Server, PostgreSQL, or Azure SQL.
- Authentication.
- Role-based permissions.
- Database-driven settings.
- Per-field audit history.
- File upload and attachment handling.
- SharePoint document storage.
- Outlook email intake.
- Teams/email notifications.
- Microsoft Lists or API sync.
- Power BI/Excel-ready reporting.
- Tests.
- Production hosting/deployment pipeline.

---

## Current Architecture Summary

OperationsFlow currently proves the business workflow and reporting concept with a working Blazor/SQLite prototype.

It is suitable as a portfolio/demo prototype and is structured around a realistic path toward a production internal business workflow system.
