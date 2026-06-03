# Technical Decisions

This document explains key technical and product decisions in the current OperationsFlow prototype.

---

## Why Blazor?

Blazor was chosen because the project is intended to demonstrate C#/.NET business system development.

Benefits for this prototype:

- C# can be used across the UI and backend logic.
- Razor components support fast module/page creation.
- It fits internal business application scenarios.
- It pairs well with Entity Framework Core.
- It is relevant to .NET business systems and application support roles.

---

## Why SQLite?

SQLite was chosen for the current prototype because:

- It is lightweight.
- It works locally without server setup.
- It supports real persistence.
- It is simple for portfolio/demo use.
- It allows create/edit/report/export workflows to behave semi-live.

Current limitation:

SQLite is suitable for this prototype, but a production version would likely use SQL Server, PostgreSQL, or Azure SQL.

---

## Why Entity Framework Core?

Entity Framework Core was used because:

- It is standard in many .NET business apps.
- It provides clean data access for C# models.
- It works with SQLite for local demo development.
- It can later support migrations and production database providers.

Current limitation:

The prototype uses early-stage schema handling. A production version would use proper EF Core migrations.

---

## Why Safety Overview?

Safety Overview was added because the Vanessa/OSHE demo needed a focused compliance starting point.

The existing app already tracked relevant records across:

- Corrective Actions
- Risk Register
- Training Compliance
- Document Control
- Activity Log

Instead of creating a separate safety system, Safety Overview aggregates those existing records into one management view.

It answers:

```text
What safety/compliance items need attention right now?
```

Current implemented Safety Overview areas include:

- Attention Items total
- Open Corrective Actions
- Overdue Corrective Actions
- High/Critical Risks
- Expired Training
- Training Expiring Soon
- Document Reviews
- Documents Due Soon
- Recent Safety/Compliance Activity
- Quick links into the relevant compliance modules

This was added as a focused dashboard rather than a separate data module. That keeps the prototype simple while demonstrating how operational records can be reused for OSHE/compliance review.

Current limitation:

Safety Overview currently uses local SQLite/demo data. It does not yet include configurable compliance rules, role-based views, automated notifications, or production audit controls.

Future upgrade:

- `SafetyOverviewService`
- Configurable attention thresholds
- Role-based compliance views
- Automated overdue corrective action notifications
- Training expiry notifications
- Document review reminders
- Power BI-ready compliance reporting
- Audit-grade user history

---

## Why Activity Log?

Activity Log was added to show traceability.

Current implemented activity features:

- Global Activity Log
- Dashboard Recent Activity
- Safety Overview Recent Compliance Activity, where relevant
- Per-record Activity History
- Created/Updated/Reviewed style events

Current limitation:

The current Activity Log is record-level traceability, not a full per-field enterprise audit trail.

Future enterprise upgrade:

- Field name
- Old value
- New value
- User ID
- Timestamp
- Source module/page

---

## Why CSV Export?

CSV export was added because many businesses still rely on Excel, email, and reporting files.

Current implemented exports include:

- Work Orders
- Corrective Actions
- Risk Register
- Training
- Document Reviews
- Activity Log
- Document Intake

Benefits:

- Simple management reporting.
- Excel-friendly output.
- Power BI-friendly direction.
- Practical business workflow credibility.
- Useful safety/compliance export path for corrective actions, risks, training, and document reviews.

---

## Why Document Intake?

Document Intake was added because many businesses process incoming admin documents through emails, PDFs, scans, supplier documents, and job paperwork.

Current implemented Document Intake features:

- List/search/filter
- Create/edit
- Source type
- Document type
- Assigned person
- Target system
- Priority
- Status
- Due date
- Completed date
- Activity logging
- Reports/export/reminder/workload integration

Current limitation:

Document Intake currently tracks metadata and workflow status. It does not yet upload, store, OCR, or automatically read actual files.

Future upgrade:

- File uploads
- SharePoint document library connection
- Outlook email intake
- OCR/AI extraction
- Attachment preview/download

---

## Why Reminder Centre?

Reminder Centre was added because business systems need a daily focus view.

It answers:

```text
What needs attention today?
```

Current implemented reminder areas:

- Overdue Work Orders
- Overdue Corrective Actions
- Document Reviews
- Training Compliance
- Document Intake Follow-ups

For Vanessa/OSHE demos, Reminder Centre supports Safety Overview by showing the daily follow-up list after the high-level safety/compliance snapshot.

---

## Why Workload Page?

Workload was added to show management visibility.

It answers:

```text
Who has what assigned?
Who has overdue work?
Who has high-priority work?
```

Current implemented workload inputs:

- Work Orders
- Corrective Actions
- Document Intake

For safety/compliance work, this helps show that corrective actions need ownership, not just status tracking.

---

## Why Data Quality Report?

Data Quality was added to demonstrate business analyst/system health thinking.

It checks for issues such as:

- Missing owners
- Blank notes
- Overdue items
- Expired training
- High/critical risks
- Document review issues
- Completed records missing completed dates
- Document Intake records needing review

This shows that the app is not only storing data, but also helping identify weak or risky records.

For Vanessa/OSHE demos, Data Quality supports compliance confidence by highlighting records that should be cleaned up before management reporting.

---

## Why Admin Settings Starter?

Admin Settings was added to show configuration direction.

Current state:

- Settings overview page
- Sites
- Departments
- Target systems
- Priority levels
- Workflow status groups

Current limitation:

Some form dropdowns are still hardcoded. Admin Settings is not fully database-driven yet.

Future upgrade:

- `SystemOption` database table
- Editable settings UI
- Active/inactive settings
- Sort orders
- Forms pulling dropdown values from the database
- Configurable compliance thresholds/statuses

---

## Why Not Authentication Yet?

Authentication was not included in the current prototype to keep the scope controlled.

Current goal:

- Demonstrate workflows.
- Demonstrate safety/compliance visibility.
- Demonstrate reporting.
- Demonstrate data persistence.
- Demonstrate traceability.
- Demonstrate enterprise direction.

Future production upgrade:

- ASP.NET Core Identity or Microsoft Entra ID
- Roles and permissions
- User-specific workload
- Real `CreatedBy` values
- Audit trail tied to authenticated users
- Safety/compliance manager views

---

## Why Not Real Integrations Yet?

Real integrations were intentionally kept out of the current prototype.

Not currently implemented:

- SharePoint integration
- Outlook email intake
- Teams notifications
- Xero integration
- Cin7 integration
- WorkflowMax integration

Current prototype value:

- Demonstrates the workflow structure.
- Tracks target systems as metadata.
- Shows where integrations would connect later.
- Shows how safety/compliance records could be reported and exported before full integration work.

Future upgrade:

Create integration services such as:

- `IEmailIntakeService`
- `ISharePointDocumentService`
- `INotificationService`
- `IAccountingExportService`
- `IInventoryExportService`
- `IComplianceNotificationService`

---

## Summary

The current technical decisions prioritise:

- Rapid portfolio proof.
- Practical business workflow demonstration.
- Safety/compliance visibility.
- Real local persistence.
- Traceability.
- Reporting/export capability.
- Clear enterprise upgrade path.

The current app is not presented as production-ready, but it is intentionally structured as a strong base for a future internal business system.
