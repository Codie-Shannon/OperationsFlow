# OperationsFlow Architecture

## Overview

OperationsFlow is currently a semi-live Blazor/.NET portfolio prototype using local SQLite data persistence. It is designed to demonstrate practical business workflow tracking, safety/compliance visibility, reporting, CSV exports, reminders, workload visibility, data quality checks, and activity traceability.

This document describes the current implemented architecture and the intended upgrade direction. Anything listed under future architecture is not presented as existing functionality.

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

The current app is mainly a Blazor application with Razor pages/components that read and write data using Entity Framework Core.

Some cross-cutting logic has already been moved into services.

Current implemented services include:

- `DashboardService`
- `ActivityLogService`
- `CsvExportService`

---

## Current Data Storage

The current prototype uses:

- SQLite
- Entity Framework Core
- Demo seed data
- Local database files during development

The app currently behaves like a semi-live local prototype:

```text
Create/Edit record
↓
SQLite data updates
↓
Dashboard/Safety Overview/reports/reminders/workload update
↓
Activity Log records the change
↓
CSV export reflects the saved data
```

---

## Current Main Modules

Current implemented modules include:

- Dashboard
- Safety Overview
- Work Orders
- Corrective Actions
- Document Control
- Risk Register
- Training Compliance
- Document Intake
- Activity Log
- Reminder Centre
- Workload
- Reports
- Data Quality Report
- Admin Settings starter
- Demo Guide page, if added from this package

---

## Safety Overview Architecture

The Safety Overview page is a focused management/compliance view.

Current page:

- `Components/Pages/SafetyOverview.razor`
- Route: `/compliance-dashboard`
- Display name: `Safety Overview`

The page is not a separate production safety engine. It is a Blazor page that aggregates existing prototype data from:

- Corrective Actions
- Risk Register
- Training Compliance
- Document Control
- Activity Log

It is designed to answer a practical OSHE/compliance question:

```text
What safety/compliance items need attention right now?
```

The page shows:

- Total attention items
- Open corrective actions
- Overdue corrective actions
- High/critical risks
- Expired training
- Training expiring soon
- Document reviews overdue or due soon
- Recent safety/compliance activity

This keeps the architecture simple while demonstrating how existing operational records can be reused for focused management dashboards.

---

## Current Activity Logging Flow

Activity logging is currently implemented for key create/edit workflows.

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
- Safety Overview Recent Compliance Activity, where relevant
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

This is implemented as record-level traceability, not a full per-field enterprise audit trail yet.

---

## Current CSV Export Flow

CSV exports are currently implemented through app endpoints and `CsvExportService`.

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

Current implemented CSV export areas include:

- Work Orders
- Corrective Actions
- Risk Register
- Training
- Document Reviews
- Activity Log
- Document Intake

---

## Current Document Intake Workflow

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

These are tracked as workflow metadata only. The app does not currently integrate with those external systems.

---

## Current Admin Settings

The current Admin Settings page is a starter/configuration overview.

It currently demonstrates the configuration direction for:

- Sites
- Departments
- Target systems
- Priority levels
- Workflow statuses
- Source/document type options

At the current prototype stage, not every form is database-driven from Admin Settings. Some option lists are still hardcoded in the relevant pages.

---

## Current Reporting and Management Views

Current implemented management views include:

- Dashboard KPIs
- Safety Overview
- Recent Activity
- Reminder Centre
- Workload page
- Reports page
- Data Quality Report
- Activity Log

These views are generated from the current SQLite data.

---

## Vanessa / OSHE Architecture Notes

For a Vanessa/OSHE-focused demo, the important architecture point is that OperationsFlow uses the same stored records across multiple views:

```text
Corrective Actions
Risk Register
Training Compliance
Document Control
Activity Log
↓
Safety Overview
Reminder Centre
Reports
Data Quality
CSV Exports
```

This demonstrates a practical business-system pattern:

- One record is created once.
- The same record appears in dashboards, reminders, reports, workload, and traceability views.
- Safety/compliance attention items can be surfaced without duplicating data across spreadsheets.

---

## Future Enterprise Architecture Direction

The current app can be evolved toward a cleaner enterprise structure over time.

A future solution may move toward:

```text
Blazor UI
↓
Application Services
↓
Domain / Business Rules
↓
Infrastructure
↓
SQL Server / PostgreSQL / Azure SQL
↓
Authentication / Permissions / Integrations
```

Possible future project structure:

```text
OperationsFlow.Web
OperationsFlow.Application
OperationsFlow.Domain
OperationsFlow.Infrastructure
OperationsFlow.Shared
OperationsFlow.Tests
```

This structure does not exist in the current prototype unless it is added later.

---

## Future Architecture Upgrades

Future upgrades could include:

- Service-layer refactor for all modules
- Request/view models instead of editing EF entities directly in forms
- EF Core migrations
- SQL Server, PostgreSQL, or Azure SQL
- Authentication
- Role-based permissions
- Database-driven settings
- Per-field audit history
- File upload and attachment handling
- SharePoint document storage
- Outlook email intake
- Teams/email notifications
- Safety/compliance notification rules
- Training expiry notifications
- Document review approval workflow
- Xero/Cin7/WorkflowMax integration services
- API layer
- Tests
- Production hosting/deployment pipeline

---

## Current Architecture Summary

OperationsFlow currently proves the business workflow, safety/compliance visibility, reporting, and traceability concept with a working Blazor/SQLite prototype.

It is intentionally not presented as a finished enterprise application yet. The existing architecture is suitable for a portfolio/demo prototype, and the roadmap explains how it can be improved into a more production-ready internal system.
