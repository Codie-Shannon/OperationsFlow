# OperationsFlow Case Study

## Summary

OperationsFlow is a semi-live Blazor/.NET business operations prototype built to demonstrate practical business systems development. It tracks operational work, corrective actions, document intake, document reviews, risk items, training compliance, reminders, workload, reports, CSV exports, data quality, and activity traceability.

The project is designed as a portfolio-ready proof of capability for .NET business systems, admin workflow automation, compliance tracking, and reporting.

---

## Problem

Many small businesses rely on disconnected tools for daily operations:

- Email inboxes
- Spreadsheets
- PDF attachments
- Paper forms
- Shared folders
- Manual follow-ups
- Separate registers for risk, training, documents, and corrective actions

This creates common problems:

- Work gets missed or forgotten.
- Owners and responsibilities are unclear.
- Corrective actions are not followed up.
- Document reviews become overdue.
- Training records expire.
- Incoming paperwork gets stuck in email.
- Managers lack a clear workload/reporting view.
- Data quality issues are hard to spot before reporting.

---

## Goal

Build a semi-live prototype that shows how these workflows can be centralised into one internal system.

The goal was to demonstrate:

1. Operational tracking.
2. Compliance follow-up.
3. Document/admin intake tracking.
4. Dashboard visibility.
5. Reporting/export capability.
6. Activity traceability.
7. A realistic path toward an enterprise version.

---

## What Was Built

### Core Modules

- Dashboard
- Work Orders
- Corrective Actions
- Document Control
- Risk Register
- Training Compliance
- Document Intake
- Activity Log
- Reports
- Reminder Centre
- Workload
- Data Quality Report
- Admin Settings starter

---

## Key Workflows

### Work Order Workflow

A user can:

- Create a work order.
- Edit status, priority, owner, due date, and notes.
- View work order details.
- See per-record activity history.
- Have dashboard, reports, reminders, and workload update based on the saved data.

### Corrective Action Workflow

A user can:

- Create a corrective action manually.
- Generate corrective actions from Risk, Document, and Training modules.
- Edit corrective action details.
- Automatically set completed date when completed/closed.
- Log creation, update, and review events.

### Document Intake Workflow

A user can:

- Track incoming documents, PDFs, emails, supplier paperwork, customer requests, internal forms, and job paperwork.
- Assign the item to a person.
- Track the target system, such as SharePoint, Xero, Cin7, WorkflowMax, Email Folder, or Internal System.
- Move the item through statuses such as Received, Saved, Needs Review, Data Checked, Entered, Completed, or Rejected.
- See intake items in Dashboard, Reports, Reminder Centre, Workload, Data Quality, Activity Log, and CSV exports.

---

## Management Visibility

OperationsFlow includes management-style views:

### Dashboard

Shows overall status and recent activity.

### Reminder Centre

Shows what needs attention now:

- Overdue work orders
- Overdue corrective actions
- Document reviews
- Training expiries
- Document intake follow-ups

### Workload

Groups assigned work by owner/person and shows:

- Total assigned
- Work orders
- Corrective actions
- Document intake items
- Overdue count
- High-priority count

### Reports

Provides reporting views for:

- Work Orders by Status
- Corrective Actions by Priority
- Risks by Level
- Training by Department
- Overdue Items by Owner
- Document Reviews
- Document Intake by Status
- Document Intake by Target System
- Document Intake Attention Report

### Data Quality

Identifies system health issues such as:

- Missing owners
- Blank notes
- Overdue work
- Expired training
- High/critical risks
- Documents overdue for review
- Completed records missing completed dates
- Document intake records needing review

---

## Technical Implementation

### Technologies

- .NET 8
- Blazor
- C#
- Entity Framework Core
- SQLite
- Razor Components
- CSS
- Git/GitHub

### Data Layer

The prototype uses SQLite and Entity Framework Core. Demo seed data provides realistic records for testing and portfolio demonstration.

### Services

Current application services include:

- `DashboardService`
- `ActivityLogService`
- `CsvExportService`

A future enterprise refactor would move more page logic into services such as:

- `WorkOrderService`
- `CorrectiveActionService`
- `DocumentIntakeService`
- `ReportService`
- `ReminderService`
- `SettingsService`

### Traceability

Activity logs are created when records are created, edited, reviewed, or updated. Activity is shown in:

- Global Activity Log
- Dashboard Recent Activity
- Per-record Activity History

### CSV Export

CSV exports support management reporting and spreadsheet workflows. Data can be opened in Excel, used for meetings, or later fed into Power BI-style reporting.

---

## Business Value

OperationsFlow shows how a business could:

- Reduce missed follow-ups.
- Improve accountability.
- Track compliance work.
- Centralise incoming document/admin processing.
- Give managers visibility into workload.
- Improve reporting.
- Export data for meetings or analysis.
- Build toward SharePoint/Outlook/Teams/Xero/Cin7 integrations.

---

## Relevance by Audience

### Health & Safety / OSHE

Relevant features:

- Corrective actions
- Risk Register
- Training Compliance
- Document Control
- Reminder Centre
- Reports
- Data Quality Report
- Activity Log
- CSV exports

### Office/Admin Document Workflow

Relevant features:

- Document Intake
- Target system tracking
- Assigned processing
- Incoming PDF/email/document tracking
- Workflow statuses
- Activity traceability
- Workload
- Reports
- CSV exports

### .NET / Business Systems Roles

Relevant features:

- C#
- Blazor
- Entity Framework Core
- SQLite
- CRUD workflows
- Search/filtering
- Reporting
- CSV exports
- Activity logging
- Business process modelling
- Enterprise roadmap planning

---

## Current Limitations

This version is a portfolio/semi-live prototype, not a production enterprise deployment.

Limitations:

- Local SQLite database.
- Demo data.
- No authentication/permissions.
- No live Microsoft 365, SharePoint, Outlook, Teams, Xero, Cin7, or WorkflowMax integrations.
- Some settings are still hardcoded in forms.
- Admin Settings is a starter configuration page.
- No full automated testing.
- No production deployment pipeline.

---

## Future Improvements

- Database-driven settings.
- Full admin settings create/edit.
- Authentication and roles.
- SQL Server/PostgreSQL/Azure SQL.
- EF Core migrations.
- Service-layer refactor.
- File upload and document attachment tracking.
- SharePoint document library integration.
- Outlook email intake.
- Teams/email notifications.
- Xero/Cin7/WorkflowMax integration layer.
- Per-field audit trail.
- API layer.
- Tests and deployment pipeline.

---

## Result

OperationsFlow is a strong portfolio prototype showing the ability to plan, build, and explain a practical internal business system.

It demonstrates business workflow thinking, .NET/Blazor development, persistence, traceability, reporting, exports, and an enterprise upgrade path.
