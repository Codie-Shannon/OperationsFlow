# OperationsFlow Case Study

## Summary

OperationsFlow is a Blazor/.NET 8 business workflow prototype built to demonstrate practical internal business systems development. It tracks operational work, corrective actions, document intake, controlled documents, risk items, training compliance, reminders, workload, reports, CSV exports, data quality, activity history, reviewer support, and production planning.

The project is designed as a portfolio-ready proof of capability for .NET business systems, admin workflow automation, safety/compliance tracking, reporting, UI refactoring, and production-aware planning.

Week 2 completed a major UI/component and stylesheet cleanup, turning the project into a more consistent, reviewable, and maintainable business workflow prototype.

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
- Changes are hard to trace later.

---

## Goal

Build a working local prototype that shows how these workflows can be centralised into one internal system.

The goal was to demonstrate:

1. Operational tracking.
2. Corrective action follow-up.
3. Safety/compliance review.
4. Document/admin intake tracking.
5. Dashboard visibility.
6. Reporting/export capability.
7. Activity traceability.
8. Data quality checks.
9. Reviewer-ready explanation pages.
10. A realistic path toward a production version.

---

## What Was Built

### Core Workflow Modules

- Dashboard
- Work Orders
- Corrective Actions
- Document Intake
- Controlled Documents
- Risk Register
- Training Compliance
- Safety Overview
- Safety Meeting Pack
- Compliance Calendar

### Management Modules

- Reminder Centre
- Workload
- Reports
- Data Quality
- Activity Log
- Admin Settings starter

### Reviewer / Portfolio Modules

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

### UI / Maintainability Work

- Shared UI component system.
- Reusable page hero, panels, metric cards, filter bars, table cards, guidance notes, and empty states.
- Consolidated app stylesheet.
- Cleaned repeated CSS patterns.
- Workload review lane polish.
- Consistent management/reporting page layout.

---

## Key Workflows

### Work Order Workflow

A user can:

- Create a work order.
- Edit status, priority, owner, due date, and notes.
- View work order details.
- See per-record activity history.
- Have dashboard, reports, reminders, workload, data quality, and CSV exports update based on saved data.

### Corrective Action Workflow

A user can:

- Create a corrective action manually.
- Generate corrective actions from risk, document, and training modules.
- Edit owner, status, priority, source, action type, due date, completed date, and notes.
- Use helper guidance for better follow-up evidence.
- Automatically set completed date when appropriate.
- Log creation, update, and review events.
- Review details and activity history.

### Document Intake Workflow

A user can:

- Track incoming documents, PDFs, emails, supplier paperwork, customer requests, internal forms, and job paperwork.
- Assign the item to a person.
- Track the target system.
- Move the item through statuses.
- Add notes and follow-up evidence.
- See intake items in Dashboard, Reports, Reminder Centre, Workload, Data Quality, Activity Log, and CSV exports.

---

## Management Visibility

OperationsFlow includes management-style views:

### Dashboard

Shows overall status and recent activity.

### Reminder Centre

Shows what needs attention now:

- Overdue work orders.
- Overdue corrective actions.
- Document reviews.
- Training expiries.
- Document intake follow-ups.

### Workload

Groups assigned work by owner/person and shows:

- Total assigned.
- Work orders.
- Corrective actions.
- Document intake items.
- Overdue count.
- High-priority count.
- Pressure level.
- Review lanes for assigned work.

### Reports

Provides reporting views for:

- Work Orders by status.
- Corrective Actions by priority/status.
- Risks by level.
- Training by department.
- Overdue items by owner.
- Document reviews.
- Document Intake by status.
- Document Intake by target system.
- Attention items.
- CSV exports.

### Data Quality

Identifies system health issues such as:

- Missing owners.
- Blank/weak notes.
- Overdue work.
- Expired training.
- High/critical risks.
- Documents overdue for review.
- Completed records missing completed dates.
- Document intake records needing review.

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

The prototype uses SQLite and Entity Framework Core. Seed data provides realistic records for testing and portfolio demonstration.

### Services

Current application services include:

- `DashboardService`
- `ActivityLogService`
- `CsvExportService`

Future production foundation work will add:

- File storage service interfaces/providers.
- Role/permission services.
- Microsoft Lists schema registry.
- Mock/dry-run sync service.
- Notification service boundary.

### Traceability

Activity logs are created when records are created, edited, reviewed, or updated.

Activity is shown in:

- Global Activity Log
- Dashboard Recent Activity
- Per-record Activity History

### CSV Export

CSV exports support management reporting and spreadsheet workflows. Data can be opened in Excel, used for meetings, or later fed into Power BI-style reporting.

---

## Business Value

OperationsFlow shows how a business could:

- Reduce missed follow-up.
- Improve accountability.
- Track safety/compliance work.
- Centralise incoming document/admin processing.
- Give managers visibility into workload.
- Improve reporting.
- Export data for meetings or analysis.
- Find weak records before management review.
- Build toward SharePoint, Outlook, Teams, Microsoft Lists, and reporting integrations.

---

## Relevance by Audience

### Vanessa / OSHE

Relevant features:

- Safety Meeting Pack
- Corrective Actions
- Risk Register
- Training Compliance
- Controlled Documents
- Reminder Centre
- Workload
- Reports
- Data Quality
- Activity Log
- CSV exports
- Business Value
- Prototype Scope

### Lester / Peter

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
- Integration Overview
- Deployment Overview

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
- Data quality rules
- Shared Razor UI components
- CSS cleanup/refactor
- Business process modelling
- Production roadmap planning

---

## Current Limitations

This version is a portfolio prototype, not a production enterprise deployment.

Limitations:

- Local SQLite database.
- Seeded demo data.
- No authentication/permissions.
- No live Microsoft 365, SharePoint, Outlook, Teams, Xero, Cin7, or WorkflowMax integrations.
- Some settings are still hardcoded in forms.
- Admin Settings is a starter configuration page.
- No full automated testing.
- No production deployment pipeline.
- No production file storage yet.

---

## Future Improvements

Week 3 production foundation:

- Production config/options structure.
- File storage interface and local provider.
- Document attachment metadata.
- Local Document Library page.
- Role/permission foundation.
- Microsoft Lists schema registry.
- Mock/dry-run sync.
- Notification rule preview/log.

Week 4 production implementation:

- Real Microsoft 365 tenant/test environment.
- SharePoint site/document library.
- Microsoft Lists.
- Graph/SharePoint integration.
- Real notifications.
- Production deployment configuration.

---

## Result

OperationsFlow is a strong portfolio prototype showing the ability to plan, build, refactor, test, and explain a practical internal business system. It demonstrates business workflow thinking, .NET/Blazor development, persistence, traceability, reporting, exports, data quality checks, reviewer guidance, maintainable UI direction, and a realistic production upgrade path.
