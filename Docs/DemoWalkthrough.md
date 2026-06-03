# OperationsFlow Demo Walkthrough

This walkthrough is designed for showing the current OperationsFlow prototype. It only references features that exist in the current app.

---

## Short Demo Path

Use this when you only have a few minutes.

1. Open the Dashboard.
2. Show KPIs and Recent Activity.
3. Open Safety Overview.
4. Explain safety/compliance attention items.
5. Open Document Intake.
6. Explain incoming document/admin workflow tracking.
7. Open Reminder Centre.
8. Show overdue and due-soon work.
9. Open Workload.
10. Show assigned work grouped by owner.
11. Open Reports.
12. Show reporting and CSV export options.
13. Open Data Quality.
14. Show system health/data issue checks.

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

OperationsFlow is a semi-live local prototype. Records saved in the app update the dashboard, Safety Overview, reports, reminders, workload views, activity logs, and CSV exports.

---

### 2. Safety Overview

Open Safety Overview.

Show:

- Attention Items total
- Open Corrective Actions
- Overdue Corrective Actions
- High/Critical Risks
- Expired Training
- Training Expiring Soon
- Document Reviews
- Documents Due Soon
- Recent Compliance Activity
- Quick links into Risk Register, Corrective Actions, Training, Documents, and Activity Log

Explain:

Safety Overview is the focused OSHE/compliance dashboard. It brings together the items a safety or compliance manager would want to check first: overdue actions, high/critical risks, training issues, document review issues, and recent activity.

Suggested action:

- Point out one high/critical risk.
- Point out one overdue corrective action.
- Point out one expired/expiring training item.
- Point out one document review issue.
- Use the quick links to move into a source module.

Clarify:

Safety Overview currently uses the same local SQLite/demo data as the rest of the prototype. It is not a production safety system yet, but it demonstrates how compliance attention items can be centralised.

---

### 3. Work Orders

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

### 4. Corrective Actions

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

### 5. Document Intake

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

### 6. Linked Corrective Action Generation

Open one of these modules:

- Risk Register
- Documents
- Training

Show:

- Create Action button
- Corrective Action form pre-filled from the source module

Explain:

This demonstrates a workflow loop: identify an issue, generate an action, assign it, track it, and report on it.

For the Vanessa/OSHE path, the strongest example is:

```text
Risk Register → Create Corrective Action → Corrective Actions → Activity Log
```

---

### 7. Risk Register

Open Risk Register.

Show:

- Risk list
- Search/filtering
- Risk score/level
- High/critical risk items
- Review overdue flags
- Create Corrective Action from risk

Explain:

Risk Register tracks hazards, risk ratings, controls, owners, and review status. It supports the OSHE story by showing how risk follow-up can turn into assigned corrective action work.

Suggested action:

- Pick a high or critical risk.
- Generate a corrective action from it.
- Open Corrective Actions to show the follow-up item.

---

### 8. Training Compliance

Open Training Compliance.

Show:

- Training list
- Search/filtering
- Expired training
- Expiring soon training
- Department/status visibility
- Create Corrective Action from training issue

Explain:

Training Compliance helps identify expired or expiring training records so retraining follow-up can be assigned and tracked.

---

### 9. Document Control

Open Document Control/Documents.

Show:

- Document list
- Owners
- Departments
- Review dates
- Due soon / overdue review flags
- Create Corrective Action from document review

Explain:

Document Control tracks document ownership and review timing. Overdue or due-soon reviews can become corrective actions when they need formal follow-up.

---

### 10. Activity Log

Open Activity Log.

Show:

- Global event list
- Created/Updated/Reviewed events
- Module and record reference
- Created by/date

Explain:

The Activity Log gives record-level traceability. Per-record Activity History shows the same concept scoped to a specific item.

For safety/compliance demos, this supports the question:

```text
Can we show what happened and when it was followed up?
```

---

### 11. Reminder Centre

Open Reminder Centre.

Show:

- Overdue Work Orders
- Overdue Corrective Actions
- Document Reviews
- Training Compliance
- Document Intake Follow-ups

Explain:

Reminder Centre answers: “What needs attention today?”

For Vanessa/OSHE, connect this back to Safety Overview:

```text
Safety Overview gives the compliance snapshot.
Reminder Centre gives the daily follow-up list.
```

---

### 12. Workload

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

For Vanessa/OSHE, explain that corrective actions and follow-up work need clear ownership, not just a list of issues.

---

### 13. Reports

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

For Vanessa/OSHE, highlight:

- Corrective actions by priority
- Risks by level
- Training by department
- Overdue items by owner
- Document reviews

---

### 14. Data Quality

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

For Vanessa/OSHE, explain that weak records can affect compliance confidence. Examples:

- Corrective action has no owner.
- Training record is expired.
- Document review is overdue.
- Critical risk requires monitoring.
- Completed record is missing completed date.

---

### 15. Admin Settings

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

1. Safety Overview
2. High/Critical Risks
3. Risk Register
4. Create Corrective Action from risk
5. Corrective Actions
6. Training Compliance
7. Document Control
8. Reminder Centre
9. Workload
10. Reports
11. CSV exports
12. Data Quality
13. Activity Log
14. Per-record Activity History

Suggested walkthrough:

1. Open Safety Overview and explain the attention items.
2. Show the total attention count.
3. Show open and overdue corrective actions.
4. Show high/critical risks.
5. Show expired or expiring training.
6. Show overdue or due-soon document reviews.
7. Open Risk Register from the quick link.
8. Generate a corrective action from a high/critical risk.
9. Open Corrective Actions and show owner, priority, due date, status, and completed date behaviour.
10. Open Training Compliance and show expired/expiring records.
11. Open Document Control and show document review flags.
12. Open Reminder Centre to show what needs attention now.
13. Open Workload to show ownership pressure.
14. Open Reports and show management/export views.
15. Download one CSV export.
16. Open Data Quality to show cleanup issues before reporting.
17. Open Activity Log or per-record Activity History to show traceability.

Main message:

OperationsFlow helps centralise safety/compliance follow-up work, identify overdue corrective actions, monitor training/document/risk issues, assign ownership, support management reporting, export data, and provide traceability.

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
3. Safety Overview
4. Work Orders CRUD
5. Document Intake CRUD
6. Corrective Action generation from Risk/Document/Training
7. Activity Log and per-record history
8. Reports and CSV export
9. Data Quality
10. Enterprise roadmap

Main message:

OperationsFlow demonstrates practical C#/Blazor business systems development, not just isolated UI screens.
