# OperationsFlow Feature Checklist

This checklist summarises the current implemented/reviewable features and the main future production upgrades.

---

## Core App

- [x] Blazor/.NET 8 application
- [x] SQLite local database
- [x] Entity Framework Core data access
- [x] Seeded demo data
- [x] Shared navigation
- [x] Reusable page intro pattern
- [x] Reusable card/table visual style
- [x] Dashboard overview
- [x] Local run/demo workflow
- [ ] Hosted production deployment
- [ ] Authentication
- [ ] Role-based permissions
- [ ] Production database
- [ ] Automated tests

---

## Dashboard

- [x] KPI cards
- [x] Summary panels
- [x] Recent activity feed
- [x] Links to workflow modules
- [x] Shows operations/compliance status
- [ ] User-personalised dashboard
- [ ] Configurable KPI definitions
- [ ] Production analytics feed

---

## Work Orders

- [x] Work order list
- [x] Search/filter
- [x] Create work order
- [x] Edit work order
- [x] Work order details
- [x] Owner field
- [x] Status field
- [x] Priority field
- [x] Due date tracking
- [x] Notes
- [x] Overdue logic
- [x] Per-record activity history
- [x] CSV export
- [ ] Approval workflow
- [ ] File attachments
- [ ] Assignment notifications

---

## Corrective Actions

- [x] Corrective action list
- [x] Search/filter
- [x] Create corrective action
- [x] Edit corrective action
- [x] Owner field
- [x] Source field
- [x] Action type field
- [x] Priority field
- [x] Status field
- [x] Due date field
- [x] Completed date field
- [x] Notes field
- [x] Owner guidance
- [x] Due date guidance
- [x] Notes guidance
- [x] Status flow guidance
- [x] Activity logging
- [x] Per-record activity history
- [x] CSV export
- [x] Corrective action creation from risk records
- [x] Corrective action creation from document review records
- [x] Corrective action creation from training records
- [ ] Approval/sign-off workflow
- [ ] File/evidence attachments
- [ ] Escalation notifications

---

## Document Intake

- [x] Document intake list
- [x] Search/filter
- [x] Create document intake item
- [x] Edit document intake item
- [x] Document name
- [x] Received date
- [x] Received from
- [x] Source type
- [x] Document type
- [x] Assigned to
- [x] Target system
- [x] Priority
- [x] Status
- [x] Due date
- [x] Completed date
- [x] Notes
- [x] Activity logging
- [x] CSV export
- [x] Appears in workload/reminders/reports/data quality
- [ ] Email inbox integration
- [ ] OCR/metadata extraction
- [ ] SharePoint file routing
- [ ] Approval/rejection workflow

---

## Safety / Compliance

- [x] Safety Overview
- [x] Safety Meeting Pack
- [x] Compliance Calendar
- [x] Controlled Documents
- [x] Risk Register
- [x] Training Compliance
- [x] High/critical risk visibility
- [x] Expired training visibility
- [x] Due-soon training visibility
- [x] Document review visibility
- [x] Corrective action generation from compliance records
- [x] Meeting-ready attention items
- [ ] Formal review sign-off
- [ ] Compliance evidence attachments
- [ ] Scheduled meeting pack export

---

## Management Views

- [x] Reminder Centre
- [x] Workload page
- [x] Reports page
- [x] Data Quality page
- [x] Activity Log
- [x] Owner pressure visibility
- [x] Overdue visibility
- [x] Management summary tables
- [x] CSV export links
- [x] Weak record checks
- [ ] Scheduled email reports
- [ ] Power BI feed
- [ ] Configurable reporting periods

---

## Activity / Audit

- [x] Global Activity Log
- [x] Dashboard recent activity
- [x] Per-record Activity History
- [x] Created/updated/reviewed-style records
- [x] Module name
- [x] Record reference
- [x] Created by display text
- [x] Created date
- [ ] Authenticated user ID
- [ ] Field-level before/after values
- [ ] Immutable audit events
- [ ] Export history
- [ ] Admin/security change tracking

---

## CSV Exports

- [x] Work Orders export
- [x] Corrective Actions export
- [x] Risk Register export
- [x] Training export
- [x] Document Reviews export
- [x] Activity Log export
- [x] Document Intake export
- [ ] Export permissions
- [ ] Scheduled exports
- [ ] Approved KPI/report definitions
- [ ] Power BI-ready model/feed

---

## Reviewer / Portfolio Pages

- [x] Portfolio Hub
- [x] Reviewer Checklist
- [x] Demo Guide
- [x] Business Value
- [x] Prototype Scope
- [x] Implementation Plan
- [x] Technical Overview
- [x] Data Model
- [x] User Roles
- [x] Audit Overview
- [x] Deployment Overview
- [x] Testing Overview
- [x] Integration Overview
- [ ] Final release notes page
- [ ] Screenshot checklist page/file

---

## Production Planning Pages

- [x] Prototype boundaries explained
- [x] Production upgrade path explained
- [x] User roles explained
- [x] Audit requirements explained
- [x] Deployment requirements explained
- [x] Testing requirements explained
- [x] Microsoft 365 integration path explained
- [ ] Production architecture implemented
- [ ] Production permissions implemented
- [ ] Production integrations implemented

---

## Documentation

- [x] README
- [x] Case Study
- [x] Architecture
- [x] Demo Walkthrough
- [x] Feature Checklist
- [x] Known Limitations
- [x] Enterprise Upgrade Plan
- [x] Targeted Pitches
- [x] Technical Decisions
- [x] Build Plan
- [ ] Final screenshot pack
- [ ] Release notes

---

## Current Overall State

OperationsFlow is currently a strong local portfolio prototype that demonstrates business workflow thinking, .NET/Blazor development, CRUD workflows, reporting, exports, data quality, activity traceability, reviewer guidance, and production planning.

It is not yet a production deployment, but it has a clear path toward one.
