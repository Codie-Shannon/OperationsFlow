# OperationsFlow

**OperationsFlow** is a Blazor/.NET 8 business workflow prototype for tracking operational work, corrective actions, document intake, safety/compliance review, risk, training, controlled documents, reminders, workload, reports, CSV exports, data quality, activity history, reviewer guidance, and production planning.

It was built as a focused portfolio project to demonstrate practical business systems development: turning scattered admin, operations, safety/compliance, document, and follow-up work into one connected workflow system.

> **Current status:** Week 2 UI cleanup and workflow polish is complete. OperationsFlow is still a local portfolio prototype using SQLite and seeded demo data, but it now has a consistent shared UI component system, cleaned stylesheet, tested workflow pages, reporting/evidence pages, reviewer pages, and a clear Week 3/Week 4 path toward production foundations and Microsoft 365 implementation.

OperationsFlow is **not yet a production deployment**. It does not currently include real authentication, enforced role permissions, hosted infrastructure, live Microsoft 365 / SharePoint / Teams / Outlook integration, production file storage, automated tests, or production monitoring.

---

## Project Purpose

Many small businesses manage operational follow-up through emails, spreadsheets, PDFs, paper forms, shared folders, and manual reminders.

That makes it hard to answer:

- What needs attention today?
- What work is overdue?
- Who owns each action?
- Which safety/compliance items need review?
- Which training records are expired or due soon?
- Which documents need review?
- Which incoming documents still need processing?
- What changed recently?
- What can be exported for management review?
- What would need to change before this became a production business system?

OperationsFlow shows how those workflows could be centralised into a simple internal business system.

---

## What This Project Demonstrates

OperationsFlow demonstrates ability to:

- Design practical business workflows around real operational problems.
- Build CRUD modules using C#, Blazor, Entity Framework Core, and SQLite.
- Create dashboard KPIs, reports, reminders, CSV exports, workload views, and data quality checks.
- Track activity history globally and per record.
- Model admin/document intake, compliance follow-up, risk, training, controlled documents, and corrective actions.
- Generate source-linked corrective actions from risk, training, and document review records.
- Build and reuse shared Razor UI components across a multi-page business application.
- Consolidate a large stylesheet into a cleaner shared UI styling system.
- Explain prototype scope, business value, production limitations, and Microsoft 365 upgrade direction clearly.

---

## Current Project Metrics

Current prototype includes:

- Blazor/.NET 8 app
- SQLite persistence
- EF Core data layer
- Seeded demo data
- Shared UI component system
- Cleaned app stylesheet
- Dashboard and management overview
- Work Orders workflow
- Corrective Actions workflow
- Document Intake workflow
- Safety Overview
- Safety Meeting Pack
- Compliance Calendar
- Controlled Documents
- Risk Register
- Training Compliance
- Reminder Centre
- Workload review
- Reports page
- CSV export endpoints
- Data Quality page
- Global Activity Log
- Per-record Activity History
- Admin Settings starter
- Portfolio Hub
- Reviewer Checklist
- Demo Guide
- Business Value page
- Prototype Scope page
- Implementation Plan
- Technical Overview
- Data Model overview
- User Roles overview
- Audit Overview
- Deployment Overview
- Testing Overview
- Microsoft 365 / Integration Overview

---

## Screenshots

OperationsFlow includes a screenshot review pack covering the main workflow, safety/compliance pages, admin workflow, reviewer pages, technical pages, and production planning pages.

See the full [Screenshot Checklist](Docs/ScreenshotChecklist.md) for the complete screenshot list and what each image proves.

### Portfolio Hub

![Portfolio Hub](Docs/Screenshots/01-portfolio-hub.png)

### Corrective Actions

![Corrective Actions List](Docs/Screenshots/10-corrective-actions-list.png)

### Corrective Action Edit / Activity History

![Corrective Action Edit Activity History](Docs/Screenshots/12-corrective-action-edit-activity-history.png)

### Safety Meeting Pack

![Safety Meeting Pack](Docs/Screenshots/14-safety-meeting-pack.png)

### Workload

![Workload](Docs/Screenshots/23-workload.png)

### Data Quality

![Data Quality](Docs/Screenshots/25-data-quality.png)

---

## Best Review Path

For someone reviewing the project without a live spoken demo, start here:

1. **Portfolio Hub** — starting point for reviewers.
2. **Reviewer Checklist** — what to click, verify, and assess.
3. **Demo Guide** — guided walkthrough paths.
4. **Business Value** — why the workflow matters.
5. **Corrective Actions** — editable workflow record example.
6. **Safety Meeting Pack** — connected compliance review page.
7. **Workload** — owner-based management visibility.
8. **Reports** — management summaries and export concepts.
9. **Data Quality** — weak record and system health checks.
10. **Activity Log** — workflow traceability.
11. **Technical Overview** — stack, architecture, and production direction.
12. **Deployment Overview** — what would be needed before real rollout.
13. **Integration Overview** — Microsoft 365 / SharePoint / Teams / Outlook direction.

---

## Core Features

### Dashboard

- KPI cards.
- Summary panels.
- Recent activity feed.
- Links into main workflow modules.

### Work Orders

- List, search, and filter.
- Create work order.
- Edit work order.
- View work order details.
- Per-record activity history.
- Overdue tracking.
- Dashboard/report/reminder/workload integration.
- CSV export.

### Corrective Actions

- List, search, and filter.
- Create corrective action.
- Edit corrective action.
- Details/review page.
- Owner, source, action type, priority, status, due date, completed date, and notes.
- Status guidance.
- Completed date behaviour.
- Activity logging.
- Per-record activity history.
- Corrective actions can be generated from risk, document, and training modules.

### Document Intake

Tracks incoming admin/document work such as:

- Emails
- PDFs
- Scanned documents
- Supplier documents
- Customer requests
- Internal forms
- Job paperwork

Fields include:

- Document name
- Received date
- Received from
- Source type
- Document type
- Assigned to
- Target system
- Priority
- Status
- Due date
- Completed date
- Notes

Target systems are tracked as workflow metadata only. The current app does not live-integrate with those systems yet.

### Compliance Modules

- Safety Overview
- Safety Meeting Pack
- Compliance Calendar
- Controlled Documents
- Risk Register
- Training Compliance

Risk items, document reviews, and training issues can generate prefilled corrective actions.

### Management Views

- Reminder Centre
- Workload
- Reports
- Data Quality
- Activity Log
- Admin Settings starter

### Reviewer / Portfolio Pages

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

These pages make the project reviewable without needing a spoken demo.

---

## Tech Stack

- .NET 8
- Blazor
- C#
- Entity Framework Core
- SQLite
- Razor Components
- HTML/CSS
- CSV export endpoints
- Git/GitHub

---

## Architecture

Current prototype structure:

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

Key services currently include:

- `DashboardService`
- `ActivityLogService`
- `CsvExportService`

Week 3 will add production-foundation services such as file storage, roles/permissions, Microsoft 365 schema mapping, dry-run sync, and notification boundaries.

---

## Current Limitations

OperationsFlow is currently a strong local portfolio prototype, not a live production system.

Current limitations:

- Local SQLite database.
- Seeded demo data.
- No real authentication.
- No enforced role permissions.
- No production hosted environment.
- No production file storage or document library.
- No live Microsoft 365 / SharePoint / Teams / Outlook integration.
- No production backup/restore process.
- No automated test suite.
- No CI/CD deployment pipeline.

See [Known Limitations](Docs/KnownLimitations.md) for details.

---

## Week 2 Completion

Week 2 completed:

- Shared UI component system.
- Workflow module refactors.
- Management/evidence page refactors.
- Static/support page refactors.
- Activity history empty state fix.
- Calendar section build fix.
- App-wide stylesheet cleanup.
- Workload review lane polish.
- Final manual page testing.

See [Release Notes](Docs/ReleaseNotes.md) and [Release Package](Docs/ReleasePackage.md).

---

## Week 3 / Week 4 Direction

### Week 3 — Production Foundation

Week 3 will build local working versions of production foundations:

- Production configuration/options structure.
- File storage interface and local file storage provider.
- Document attachment model.
- Local Document Library page.
- Role/permission foundation.
- Microsoft Lists schema registry.
- Microsoft 365 readiness/dry-run checks.
- Notification rules and local notification preview/log.

### Week 4 — Production Microsoft 365 Implementation

Week 4 will connect the production implementation:

- Real Microsoft 365 environment.
- Real SharePoint site and document library.
- Real Microsoft Lists.
- Real file uploads to SharePoint.
- Real sync flows.
- Real Teams/Outlook/Power Automate notification path.
- Production configuration and deployment documentation.

---

## Run Locally

```bash
dotnet restore
dotnet build
dotnet run
```

Then open the local URL shown in the terminal.

---

## Documentation

Key documentation:

- [Case Study](Docs/CaseStudy.md)
- [Architecture](Docs/Architecture.md)
- [Build Plan](Docs/BuildPlan.md)
- [Demo Walkthrough](Docs/DemoWalkthrough.md)
- [Feature Checklist](Docs/FeatureChecklist.md)
- [Known Limitations](Docs/KnownLimitations.md)
- [Release Package](Docs/ReleasePackage.md)
- [Release Notes](Docs/ReleaseNotes.md)
- [Screenshot Checklist](Docs/ScreenshotChecklist.md)
- [Styling System](Docs/StylingSystem.md)
- [Targeted Pitches](Docs/TargetedPitches.md)
- [Technical Decisions](Docs/TechnicalDecisions.md)

---

## Summary

OperationsFlow is a portfolio-ready Blazor/.NET business workflow prototype showing operational follow-up, safety/compliance review, document/admin workflow, reporting, data quality, activity traceability, and a realistic production path toward Microsoft 365.

