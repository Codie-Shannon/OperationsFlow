# OperationsFlow Demo Walkthrough

This walkthrough is designed for showing the current OperationsFlow prototype.

It supports both live demos and no-speaking demos. The app includes Portfolio Hub, Reviewer Checklist, Demo Guide, Business Value, Prototype Scope, Technical Overview, Deployment Overview, Testing Overview, and Integration Overview pages so a reviewer can understand the project without needing a long spoken explanation.

---

## Short No-Speaking Demo Path

Use this when sending the project for review without voice-over.

1. Open **Portfolio Hub**.
2. Open **Reviewer Checklist**.
3. Open **Demo Guide**.
4. Open **Business Value**.
5. Open **Safety Meeting Pack**.
6. Open **Workload**.
7. Open **Corrective Actions** and edit one record.
8. Open **Reports**.
9. Open **Data Quality**.
10. Open **Technical Overview**.
11. Open **Deployment Overview**.
12. Open **Integration Overview**.

Main message:

> OperationsFlow is more than a static dashboard. It is a connected business workflow prototype with editable records, owner accountability, due dates, reporting views, activity traceability, data quality checks, and a clear production upgrade path.

---

## Short Live Demo Path

Use this when only a few minutes are available.

1. Open Portfolio Hub.
2. Explain that the best review path is built into the app.
3. Open Business Value.
4. Open Safety Meeting Pack.
5. Open Workload.
6. Open Corrective Actions and show create/edit.
7. Open Activity Log.
8. Open Data Quality.
9. Open Prototype Scope and Implementation Plan.

---

## Full Demo Path

### 1. Portfolio Hub

Show:

- Recommended review path.
- One-minute summary.
- Links to key reviewer pages.
- Reviewer Page Map.
- Portfolio Summary.

Explain:

OperationsFlow is a .NET/Blazor business workflow prototype focused on operational follow-up, safety/compliance review, admin/document workflow, reporting, and management visibility.

### 2. Reviewer Checklist

Show:

- Business review.
- Workflow review.
- Record review.
- Management review.
- System health.
- Production thinking.

Explain:

This page tells a reviewer what to click, what to verify, and what the project proves.

### 3. Business Value

Show:

- Core business problem.
- OperationsFlow response.
- Before vs after.
- Business Value Matrix.

Explain:

The value is reduced missed follow-up, clearer ownership, better reporting, and stronger visibility across safety, compliance, admin, and operations.

### 4. Dashboard

Show:

- KPI cards.
- Summary panels.
- Recent activity.
- Links to major modules.

Explain:

The dashboard gives a manager a quick overview of the workflow state.

### 5. Work Orders

Show:

- List/search/filter.
- Create Work Order.
- Edit Work Order.
- Details page.
- Activity history.

Explain:

Work Orders represent operational tasks or work requests that need ownership, due dates, and follow-up.

### 6. Corrective Actions

Show:

- List/search/filter.
- Create Corrective Action.
- Edit Corrective Action.
- Status guidance.
- Completed date behaviour.
- Notes guidance.
- Activity history.

Explain:

Corrective Actions can be created manually or generated from risk, document, and training modules.

### 7. Safety Meeting Pack

Show:

- Attention items.
- High/critical risks.
- Training issues.
- Document review issues.
- Recent activity.
- Recommended follow-up.

Explain:

This page turns multiple record types into a meeting-ready safety/compliance review.

### 8. Document Intake

Show:

- Incoming document list.
- Search/filter.
- Source type.
- Document type.
- Assigned to.
- Target system.
- Priority.
- Status.
- Due date.
- Edit action.

Explain:

Document Intake tracks incoming admin/document work such as emails, PDFs, scanned documents, supplier documents, customer requests, internal forms, and job paperwork.

Clarify:

The current prototype tracks target systems as workflow metadata. It does not currently connect live to SharePoint, Xero, Cin7, WorkflowMax, or email systems.

### 9. Linked Corrective Action Generation

Open one of these modules:

- Risk Register
- Documents
- Training

Show:

- Create Action button.
- Corrective Action form pre-filled from the source module.

Explain:

This demonstrates a workflow loop: identify an issue, generate an action, assign it, track it, and report on it.

### 10. Activity Log

Show:

- Global event list.
- Created/Updated/Reviewed events.
- Module and record reference.
- Created by/date.

Explain:

The Activity Log gives record-level traceability. Per-record Activity History shows the same concept scoped to a specific item.

### 11. Reminder Centre

Show:

- Overdue Work Orders.
- Overdue Corrective Actions.
- Document Reviews.
- Training Compliance.
- Document Intake Follow-ups.

Explain:

Reminder Centre answers: “What needs attention today?”

### 12. Workload

Show:

- Owner/person workload rows.
- Total assigned.
- Work Orders.
- Corrective Actions.
- Document Intake.
- Overdue count.
- High-priority count.
- Pressure level.

Explain:

Workload shows who has work assigned and where pressure is building.

### 13. Reports

Show:

- Work Orders by Status.
- Corrective Actions by Priority.
- Risks by Level.
- Training by Department.
- Overdue Items by Owner.
- Document Reviews.
- Document Intake reports.
- CSV export buttons.

Explain:

Reports turn operational data into management views and exportable data.

### 14. Data Quality

Show:

- Total issues.
- Critical/warning/info issues.
- Missing owners.
- Blank notes.
- Overdue work.
- Expired training.
- Risk/document/intake issues.

Explain:

Data Quality shows where records need cleanup before management reporting.

### 15. Technical Overview

Show:

- Stack.
- Architecture style.
- Module architecture map.
- Technical proof points.
- Production technical upgrade path.

Explain:

This is a Blazor/.NET prototype built around Razor pages, EF Core, SQLite, seeded data, reusable UI patterns, and workflow records.

### 16. Deployment Overview

Show:

- Current hosting.
- Production target.
- Database target.
- Release need.
- Deployment readiness matrix.
- Risk/control map.

Explain:

This page explains what would need to change before the app could be deployed for real users.

### 17. Testing Overview

Show:

- Manual test matrix.
- Workflow test checklist.
- Production test upgrade path.
- Regression risks.

Explain:

Testing is currently manual and suitable for portfolio review. Production would require automated unit tests, integration tests, security/role tests, deployment tests, and CI/CD checks.

### 18. Integration Overview

Show:

- Microsoft 365 workflow map.
- SharePoint document storage.
- Teams/Outlook reminders.
- Excel/Power BI-ready exports.
- Identity/roles.
- Phased integration plan.

Explain:

The project is not live-integrated yet, but it has a realistic Microsoft 365 upgrade path.

---

## Vanessa / OSHE Demo Path

Focus on:

1. Portfolio Hub
2. Business Value
3. Safety Meeting Pack
4. Risk Register
5. Create Corrective Action from risk
6. Corrective Actions
7. Training Compliance
8. Documents
9. Reminder Centre
10. Workload
11. Reports
12. Data Quality
13. Prototype Scope

Main message:

> OperationsFlow helps centralise safety/compliance follow-up work, identify overdue actions, monitor training/document/risk issues, support safety meetings, and improve management visibility.

---

## Lester / Peter Demo Path

Focus on:

1. Portfolio Hub
2. Document Intake
3. Create incoming document record
4. Edit status and target system
5. Per-record Activity History
6. Reminder Centre
7. Workload
8. Reports
9. CSV export
10. Integration Overview
11. Implementation Plan

Main message:

> OperationsFlow shows how document/admin processing can be tracked from receipt through review, entry, completion, reporting, export, and future Microsoft 365 integration.

---

## Job Interview Demo Path

Focus on:

1. Tech stack.
2. Technical Overview.
3. Data Model.
4. Work Orders CRUD.
5. Corrective Actions CRUD.
6. Document Intake CRUD.
7. Activity Log and per-record history.
8. Reports and CSV export.
9. Data Quality.
10. Deployment Overview.
11. Integration Overview.

Main message:

> OperationsFlow demonstrates practical C#/Blazor business systems development, not just isolated UI screens.
