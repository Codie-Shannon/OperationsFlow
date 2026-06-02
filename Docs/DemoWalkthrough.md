# OperationsFlow Demo Walkthrough

This walkthrough is designed for showing the current OperationsFlow prototype. It only references features that exist in the current app.

---

## Short Demo Path

Use this when you only have a few minutes.

1. Open the Dashboard.
2. Show KPIs and Recent Activity.
3. Open Document Intake.
4. Explain incoming document/admin workflow tracking.
5. Open Reminder Centre.
6. Show overdue and due-soon work.
7. Open Workload.
8. Show assigned work grouped by owner.
9. Open Reports.
10. Show reporting and CSV export options.
11. Open Data Quality.
12. Show system health/data issue checks.

---

## Full Demo Path

### 1. Dashboard

Show:

- KPI cards
- Module summary panels
- Recent Activity
- Document Intake summary, if the integration has been added
- Links to major modules

Explain:

OperationsFlow is a semi-live local prototype. Records saved in the app update the dashboard, reports, reminders, workload views, activity logs, and CSV exports.

---

### 2. Work Orders

Open Work Orders.

Show:

- List/search/filter
- Summary cards
- Edit action
- View/details page
- Per-record Activity History

Suggested action:

- Open a work order details page.
- Show its status, priority, due date, owner, notes, and Activity History.

Explain:

Work Orders represent operational tasks or work requests that need ownership and due-date tracking.

---

### 3. Corrective Actions

Open Corrective Actions.

Show:

- List/search/filter
- Create Corrective Action
- Edit Corrective Action
- Completed date automation
- Activity History on edit page

Explain:

Corrective Actions can be created manually or generated from Risk, Document, and Training modules.

---

### 4. Document Intake

Open Document Intake.

Show:

- Incoming document list
- Search/filter
- Source Type
- Document Type
- Assigned To
- Target System
- Priority
- Status
- Due Date
- Edit action

Suggested action:

- Create a new intake record.
- Edit the status to Needs Review or Completed.
- Show Activity Log or per-record Activity History.

Explain:

Document Intake tracks incoming admin/document work such as emails, PDFs, scanned documents, supplier documents, customer requests, internal forms, and job paperwork.

Clarify:

The current prototype tracks target systems as workflow metadata. It does not currently connect live to SharePoint, Xero, Cin7, WorkflowMax, or email systems.

---

### 5. Linked Corrective Action Generation

Open one of these modules:

- Risk Register
- Documents
- Training

Show:

- Create Action button
- Corrective Action form pre-filled from the source module

Explain:

This demonstrates a workflow loop: identify an issue, generate an action, assign it, track it, and report on it.

---

### 6. Activity Log

Open Activity Log.

Show:

- Global event list
- Created/Updated/Reviewed events
- Module and record reference
- Created by/date

Explain:

The Activity Log gives record-level traceability. Per-record Activity History shows the same concept scoped to a specific item.

---

### 7. Reminder Centre

Open Reminder Centre.

Show:

- Overdue Work Orders
- Overdue Corrective Actions
- Document Reviews
- Training Compliance
- Document Intake Follow-ups

Explain:

Reminder Centre answers: “What needs attention today?”

---

### 8. Workload

Open Workload.

Show:

- Owner/person workload rows
- Total assigned
- Work Orders
- Corrective Actions
- Document Intake
- Overdue count
- High priority count
- Pressure level

Explain:

Workload shows who has work assigned and where pressure is building.

---

### 9. Reports

Open Reports.

Show:

- Work Orders by Status
- Corrective Actions by Priority
- Risks by Level
- Training by Department
- Overdue Items by Owner
- Document Reviews
- Document Intake reports, if integration has been added
- CSV export buttons

Suggested action:

- Click one CSV export.

Explain:

Reports turn operational data into management views and exportable data.

---

### 10. Data Quality

Open Data Quality.

Show:

- Total issues
- Critical/warning/info issues
- Missing owners
- Blank notes
- Overdue work
- Expired training
- Risk/document/intake issues

Explain:

Data Quality Report shows where records need cleanup before management reporting.

---

### 11. Admin Settings

Open Admin Settings.

Show:

- Sites
- Departments
- Target systems
- Priority levels
- Workflow statuses
- Configuration roadmap note

Explain:

Admin Settings is currently a starter/configuration overview. It shows the direction for a future database-driven settings system.

---

## Vanessa / OSHE Demo Path

Focus on:

1. Dashboard
2. Risk Register
3. Create Corrective Action from risk
4. Corrective Actions
5. Training Compliance
6. Document Control
7. Reminder Centre
8. Reports
9. Data Quality

Main message:

OperationsFlow helps centralise safety/compliance follow-up work, identify overdue actions, monitor training/document/risk issues, and support management reporting.

---

## Lester / Peter Demo Path

Focus on:

1. Dashboard
2. Document Intake
3. Create incoming document record
4. Edit status and target system
5. Per-record Activity History
6. Reminder Centre
7. Workload
8. Reports
9. CSV export
10. Admin Settings / roadmap

Main message:

OperationsFlow shows how document/admin processing can be tracked from receipt through review, entry, completion, reporting, and export.

---

## Job Interview Demo Path

Focus on:

1. Tech stack
2. Dashboard
3. Work Orders CRUD
4. Document Intake CRUD
5. Activity Log and per-record history
6. Reports and CSV export
7. Data Quality
8. Enterprise roadmap

Main message:

OperationsFlow demonstrates practical C#/Blazor business systems development, not just isolated UI screens.
