# OperationsFlow

**OperationsFlow** is a Blazor/.NET 8 business workflow prototype for tracking operational work, corrective actions, document intake, safety/compliance review, risk, training, controlled documents, reminders, workload, reports, CSV exports, data quality, activity history, and production planning.

It was built as a focused portfolio project to demonstrate practical business systems development: turning scattered admin, operations, safety/compliance, document, and follow-up work into one connected workflow system.

> **Current status:** OperationsFlow is a local portfolio prototype using SQLite and seeded demo data. It demonstrates workflow design, record editing, reporting, exports, reminders, workload visibility, activity traceability, data quality checks, reviewer guidance, production planning, testing awareness, deployment planning, and Microsoft 365 integration direction. It is not yet a production deployment and does not currently include real authentication, role permissions, hosted infrastructure, live SharePoint/Teams/Outlook integration, production file storage, or automated test coverage.

---

## Week 1 Review Walkthrough

A short silent walkthrough video is available for reviewers who want a quick overview of the Week 1 review package.

[Watch the Week 1 Review Walkthrough](https://youtu.be/Ng0jTAEdqKs)

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
- Explain a prototype clearly for business reviewers, technical reviewers, and future production planning.
- Separate current prototype functionality from future production requirements.
- Plan a realistic Microsoft 365 upgrade path using SharePoint, Teams, Outlook, identity, reporting exports, and integrations.

---

## Current Project Metrics

Current prototype includes:

- Blazor/.NET 8 app
- SQLite persistence
- EF Core data layer
- Seeded demo data
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

OperationsFlow includes a 36-image screenshot review pack covering the main workflow, safety/compliance pages, admin workflow, reviewer pages, and production planning pages.

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

1. **Week 1 Review Walkthrough** — short silent video overview.
2. **Portfolio Hub** — starting point for reviewers.
3. **Reviewer Checklist** — what to click, verify, and assess.
4. **Demo Guide** — guided walkthrough paths.
5. **Business Value** — why the workflow matters.
6. **Corrective Actions** — editable workflow record example.
7. **Safety Meeting Pack** — connected compliance review page.
8. **Workload** — owner-based management visibility.
9. **Reports** — management summaries and export concepts.
10. **Data Quality** — weak record and system health checks.
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
- Dashboard/report integration.
- CSV export.

### Corrective Actions

- List, search, and filter.
- Create corrective action.
- Edit corrective action.
- Owner, priority, status, due date, completed date, and notes.
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

Risk items, document reviews, and training issues can generate corrective actions.

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