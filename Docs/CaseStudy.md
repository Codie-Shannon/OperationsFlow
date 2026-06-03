# OperationsFlow Case Study

## Summary

OperationsFlow is a semi-live Blazor/.NET business operations prototype built to demonstrate practical business systems development. It tracks operational work, corrective actions, safety/compliance issues, document intake, document reviews, risk items, training compliance, reminders, workload, reports, CSV exports, data quality, and activity traceability.

The project is designed as a portfolio-ready proof of capability for .NET business systems, admin workflow automation, compliance tracking, safety/compliance visibility, and reporting.

OperationsFlow v1.1 adds a focused Safety Overview dashboard for Vanessa/OSHE-style demos. This gives a health, safety, or compliance manager a single place to review open corrective actions, overdue corrective actions, high/critical risks, expired training, document review issues, and recent compliance activity.

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
- Safety/compliance attention items are split across separate registers.
- Data quality issues are hard to spot before reporting.

For a health, safety, or compliance manager, the key issue is often simple:

```text
What needs attention today, who owns it, and can I prove it was followed up?
```

---

## Goal

Build a semi-live prototype that shows how these workflows can be centralised into one internal system.

The goal was to demonstrate:

1. Operational tracking.
2. Safety/compliance follow-up.
3. Corrective action management.
4. Risk, training, and document review visibility.
5. Document/admin intake tracking.
6. Dashboard visibility.
7. Reporting/export capability.
8. Activity traceability.
9. A realistic path toward an enterprise version.

---

## What Was Built

### Core Modules

- Dashboard
- Safety Overview
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

### Safety Overview Workflow

A user can open Safety Overview and immediately see:

- Total attention items
- Open corrective actions
- Overdue corrective actions
- High/critical risks
- Expired training
- Training expiring soon
- Overdue and due-soon document reviews
- Recent safety/compliance activity

This gives the Vanessa/OSHE demo a focused starting point before drilling into the source modules.

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

### Risk to Corrective Action Workflow

A user can:

- Open the Risk Register.
- Review high/critical risks.
- Identify overdue or risky items.
- Generate a corrective action from a risk item.
- Assign the action to an owner.
- Track its priority, status, and due date.
- See the resulting action in Corrective Actions, reports, reminders, and traceability views.

### Training to Corrective Action Workflow

A user can:

- Open Training Compliance.
- Identify expired or expiring training.
- Generate a corrective action from a training issue.
- Track retraining follow-up through Corrective Actions.

### Document Review to Corrective Action Workflow

A user can:

- Open Document Control.
- Identify overdue or due-soon document reviews.
- Generate a corrective action from a document review issue.
- Track the review follow-up through Corrective Actions.

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

### Safety Overview

Shows the safety/compliance items that need attention now:

- Open corrective actions
- Overdue corrective actions
- High/critical risks
- Expired training
- Training expiring soon
- Overdue document reviews
- Documents due soon
- Recent compliance activity

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
- `SafetyOverviewService`
- `ReportService`
- `ReminderService`
- `SettingsService`

### Traceability

Activity logs are created when records are created, edited, reviewed, or updated. Activity is shown in:

- Global Activity Log
- Dashboard Recent Activity
- Safety Overview Recent Compliance Activity, where relevant
- Per-record Activity History

### CSV Export

CSV exports support management reporting and spreadsheet workflows. Data can be opened in Excel, used for meetings, or later fed into Power BI-style reporting.

---

## Business Value

OperationsFlow shows how a business could:

- Reduce missed follow-ups.
- Improve accountability.
- Track compliance work.
- Centralise safety/compliance attention items.
- Track corrective actions from risk, training, and document review issues.
- Centralise incoming document/admin processing.
- Give managers visibility into workload.
- Improve reporting.
- Export data for meetings or analysis.
- Build toward SharePoint/Outlook/Teams/Xero/Cin7 integrations.

---

## Relevance by Audience

### Health & Safety / OSHE

Relevant features:

- Safety Overview
- Corrective actions
- Risk Register
- Training Compliance
- Document Control
- Reminder Centre
- Reports
- Data Quality Report
- Activity Log
- CSV exports

Suggested Vanessa/OSHE demo path:

1. Open Safety Overview.
2. Explain the attention items.
3. Show high/critical risks.
4. Generate a corrective action from a risk.
5. Open Corrective Actions and show ownership, priority, due dates, and status.
6. Show expired/expiring training records.
7. Show document review issues.
8. Open Reminder Centre.
9. Open Data Quality.
10. Open Reports and CSV exports.
11. Open Activity Log or per-record Activity History for traceability.

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
- No automated safety notifications yet.
- No file upload/storage yet.
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
- Safety/compliance notification rules.
- Training expiry reminders.
- Document review approval workflow.
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

It demonstrates business workflow thinking, .NET/Blazor development, persistence, safety/compliance visibility, traceability, reporting, exports, and an enterprise upgrade path.
