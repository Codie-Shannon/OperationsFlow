# OperationsFlow Feature Checklist

## Overview

- [x] Dashboard
- [x] Safety Overview
- [x] Recent Activity
- [x] SQLite persistence
- [x] Seed/demo data
- [x] Grouped navigation
- [x] Portfolio documentation
- [ ] Demo video

---

## Operations

### Work Orders

- [x] Work Orders list
- [x] Search/filter
- [x] Create Work Order
- [x] Edit Work Order
- [x] Work Order details page
- [x] Return-to-details edit flow
- [x] Overdue tracking
- [x] Per-record Activity History
- [x] Dashboard integration
- [x] Reports integration
- [x] CSV export

### Corrective Actions

- [x] Corrective Actions list
- [x] Search/filter
- [x] Create Corrective Action
- [x] Edit Corrective Action
- [x] Completed date automation
- [x] Activity logging
- [x] Per-record Activity History
- [x] Reports integration
- [x] CSV export

---

## Compliance

### Safety Overview

- [x] Focused safety/compliance dashboard
- [x] Attention Items total
- [x] Open Corrective Actions count
- [x] Overdue Corrective Actions count
- [x] High/Critical Risks visibility
- [x] Expired Training visibility
- [x] Training Expiring Soon visibility
- [x] Document Reviews visibility
- [x] Documents Due Soon visibility
- [x] Recent Safety/Compliance Activity
- [x] Critical/High Risks section
- [x] Overdue Corrective Actions section
- [x] Expired/Expiring Training section
- [x] Document Review Issues section
- [x] Quick links into Risk Register, Corrective Actions, Training, Documents, and Activity Log
- [x] Sidebar navigation under Compliance
- [x] README screenshot support through `Docs/Screenshots/safety-overview.png`

### Document Control

- [x] Document list
- [x] Search/filter
- [x] Due soon / overdue review flags
- [x] Create Corrective Action from document review
- [x] Reports integration
- [x] CSV export

### Risk Register

- [x] Risk list
- [x] Search/filter
- [x] Risk score/level display
- [x] Review overdue flags
- [x] Create Corrective Action from risk item
- [x] Reports integration
- [x] CSV export

### Training Compliance

- [x] Training list
- [x] Search/filter
- [x] Expired / expiring soon flags
- [x] Create Corrective Action from training issue
- [x] Reports integration
- [x] CSV export

---

## Admin Workflow

### Document Intake

- [x] Document Intake list
- [x] Search/filter
- [x] Create Intake Record
- [x] Edit Intake Record
- [x] Status workflow
- [x] Target system tracking
- [x] Completed date automation
- [x] Activity logging
- [x] Per-record Activity History
- [x] Dashboard integration
- [x] Reminder Centre integration
- [x] Workload integration
- [x] Reports integration
- [x] Data Quality integration
- [x] CSV export

---

## Management

### Reminder Centre

- [x] Overdue Work Orders
- [x] Overdue Corrective Actions
- [x] Document Review reminders
- [x] Training reminders
- [x] Document Intake follow-ups

### Workload

- [x] Group work by owner/person
- [x] Work Orders included
- [x] Corrective Actions included
- [x] Document Intake included
- [x] Overdue count
- [x] High priority count
- [x] Pressure level

### Reports

- [x] Work Orders by Status
- [x] Corrective Actions by Priority
- [x] Risks by Level
- [x] Training by Department
- [x] Overdue Items by Owner
- [x] Document Review Report
- [x] Document Intake by Status
- [x] Document Intake by Target System
- [x] Document Intake Attention Report
- [x] CSV export options

### Data Quality

- [x] Missing owners
- [x] Blank notes
- [x] Overdue work
- [x] Expired training
- [x] Document review issues
- [x] Risk register issues
- [x] Completed records missing completed dates
- [x] Document Intake review issues

---

## System

### Activity Log

- [x] Global Activity Log
- [x] Created events
- [x] Updated events
- [x] Reviewed events
- [x] Dashboard Recent Activity
- [x] Safety Overview Recent Compliance Activity, where relevant
- [x] Per-record Activity History

### Admin Settings

- [x] Admin Settings starter page
- [x] Sites overview
- [x] Departments overview
- [x] Target Systems overview
- [x] Priority Levels overview
- [x] Workflow Status overview
- [ ] Database-driven settings
- [ ] Editable settings

---

## Vanessa / OSHE Demo Readiness

- [x] Safety Overview available as the first OSHE demo page
- [x] Corrective Actions visible as safety/process improvement work
- [x] Risk Register supports high/critical risk follow-up
- [x] Training Compliance supports expired/expiring training visibility
- [x] Document Control supports overdue/due-soon review visibility
- [x] Corrective Actions can be generated from Risk, Document, and Training modules
- [x] Reminder Centre shows overdue/due-soon follow-up items
- [x] Workload shows ownership pressure
- [x] Reports provide management summaries
- [x] CSV exports support Excel/Power BI-style workflows
- [x] Activity Log supports record-level traceability
- [x] Data Quality highlights weak or risky records before reporting

---

## Enterprise Roadmap

- [ ] EF Core migrations
- [ ] SQL Server/PostgreSQL/Azure SQL
- [ ] Authentication
- [ ] Roles and permissions
- [ ] Service-layer refactor
- [ ] File uploads/attachments
- [ ] SharePoint integration
- [ ] Outlook intake
- [ ] Teams/email notifications
- [ ] Safety/compliance notification rules
- [ ] Training expiry reminders
- [ ] Document review approval workflow
- [ ] Xero/Cin7/WorkflowMax integration
- [ ] API layer
- [ ] Automated tests
- [ ] Production deployment
