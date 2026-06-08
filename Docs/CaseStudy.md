# OperationsFlow Case Study

## Summary

OperationsFlow is a practical business workflow system prototype built with .NET 8, Blazor, EF Core, local SQL authentication, role permissions, document evidence handling, reports, data quality checks, and Microsoft 365 production-readiness.

The project shows how operational requests, corrective actions, document intake, risk follow-up, training compliance, document review, evidence files, and management reporting can be connected into one internal workflow system.

## Problem

Workplace operational follow-up often gets scattered across:

- email inboxes
- paper notes
- verbal updates
- spreadsheet trackers
- unstructured document folders
- disconnected systems
- manual reporting packs

That creates problems:

- unclear ownership
- missed due dates
- weak evidence trails
- duplicated admin work
- management cannot easily see pressure points
- automation is difficult because the workflow is not structured

## Goal

Build a working local prototype that proves the workflow shape before connecting live Microsoft 365 services.

The system should:

- capture work consistently
- assign ownership
- track status and due dates
- attach evidence
- log activity
- surface overdue/missing evidence issues
- support reporting and review
- enforce local role permissions
- provide a clear Microsoft 365 production path

## What Was Built

### Core Workflow Modules

- Work Orders
- Corrective Actions
- Document Intake
- Risk Register
- Training Compliance
- Document Control

### Management Modules

- Dashboard
- Workload
- Reminders
- Reports
- Data Quality
- Activity Log

### Evidence Modules

- Local Document Library
- Record-level attachments
- Attachment metadata
- File counts on workflow registers
- Missing evidence checks
- Evidence coverage reporting

### Authentication / Permissions

- Local SQL users
- Local roles
- Local permissions
- Login/logout
- Session-based local sign-in
- Protected navigation
- Action-level permission enforcement

### Reviewer / Portfolio Modules

- Reviewer Checklist
- Demo Guide
- Business Value
- Technical Overview
- Integration Overview
- Prototype Scope
- Implementation Plan
- User Roles
- Admin Settings

## Key Workflows

### Work Order Workflow

```text
Create work order -> assign owner -> track status/due date -> attach evidence -> log activity -> show in workload/reminders/reports/data quality
```

### Corrective Action Workflow

```text
Issue/risk/training/document review -> create source-linked action -> assign owner/priority -> track follow-up -> attach close-out evidence -> log history
```

### Document Intake Workflow

```text
Incoming document -> intake record -> owner/target system/status -> details page -> attach source documents -> show in library/reports/data quality
```

### Permission Workflow

```text
User logs in -> local SQL roles load -> permissions exposed through CurrentUserService -> UI hides actions not allowed for role
```

## Management Visibility

OperationsFlow gives managers/reviewers:

- open work count
- overdue items
- high/critical risks
- training compliance rate
- document intake pressure
- missing evidence rows
- evidence coverage by module
- activity traceability
- CSV export package when permitted

## Technical Implementation

### Technologies

- .NET 8
- Blazor
- C#
- Entity Framework Core
- SQLite/local development support
- SQL Server / LocalDB production foundation
- local file storage
- Microsoft 365 / SharePoint / Graph path for Week 4

### Data Layer

The app uses EF Core models/services for workflow records, activity logs, attachments, local users, roles, and permissions.

### Services

- activity logging
- CSV export package
- dashboard/reporting queries
- document attachment metadata
- file storage abstraction
- local identity/auth/session services
- local current user permissions
- database schema safety service

### Traceability

Create/edit/upload/delete/review actions produce visible Activity Log records and/or record-level history.

### Permissions

Week 3 includes action-level permission enforcement:

- workflow create/edit -> `CanEditWorkflow`
- evidence upload -> `CanUploadEvidence`
- evidence delete -> `CanDeleteEvidence`
- CSV/export links -> `CanExportData`
- settings/admin -> `CanManageSettings`
- users/roles -> `CanManageUsers`

## Business Value

OperationsFlow demonstrates:

- less reliance on memory/manual follow-up
- clearer ownership
- stronger evidence trail
- better management visibility
- structured workflow before automation
- safer rollout path from local pilot to Microsoft 365 production

## Relevance by Audience

### Vanessa / OSHE

Relevant to safety, compliance, training, document review, corrective actions, evidence, and management reporting.

### Lester / Peter

Relevant to M365/AI/process review because it shows task-based workflow capture, human-in-the-loop decisions, document/PDF intake thinking, SharePoint-ready evidence storage, and structured automation planning.

### AIE / Workflow Automation

Relevant to SharePoint/Power Automate job setup style workflows, INFO mailbox intake, Planner/Playbook task mapping, and human review stages.

### JV / Business Systems

Relevant to local SQL-backed business systems, login/users/roles, workflow records, evidence handling, and future OAuth2 linking.

## Current Limitations

- Not hosted as production.
- Microsoft Entra OAuth2 is not connected yet.
- SharePoint/Graph file storage is not connected yet.
- No production Xero/Cin7/WorkflowMax integration yet.
- Automated test suite is not complete.
- Production retention, backup, monitoring, and security review are future work.

## Future Improvements

### Week 4

- Microsoft 365 tenant configuration.
- Entra app registration.
- OAuth2 sign-in.
- External login links to local users.
- SharePoint document library provider.
- Graph upload/open/delete.
- Production setup guide.

### Later

- Power BI reporting.
- Power Automate notifications.
- Planner/Teams task sync.
- Xero/Cin7/WorkflowMax connector research.
- Automated tests.
- Hosted deployment.

## Result

OperationsFlow is now a strong portfolio/business-systems proof project: not just a UI demo, but a local SQL-backed workflow system with evidence, permissions, reporting, and a clear Microsoft 365 implementation path.
