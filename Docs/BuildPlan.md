# OperationsFlow Build Plan

## V1 Scope

OperationsFlow v1 is not a full ERP. It is a semi-live business systems demo.

The v1.1 Vanessa/OSHE direction adds a focused Safety Overview so the prototype can be demonstrated as a practical safety/compliance workflow system, not just a generic admin dashboard.

---

## Core Modules

### Executive Overview

Dashboard cards and summary tables.

### Safety Overview

Focused OSHE/compliance dashboard showing:

- Open corrective actions
- Overdue corrective actions
- High/critical risks
- Expired training
- Training expiring soon
- Document reviews overdue or due soon
- Recent safety/compliance activity

### Work Orders

Track operational jobs/tasks.

### Corrective Actions

Track safety/process improvement actions.

### Document Control

Track documents, owners, review dates, and expiry.

### Risk Register

Track hazards, risk ratings, controls, and review status.

### Training Compliance

Track staff training status and expiry.

### Document Intake

Track incoming admin/document workflow items.

---

## Day 1 Goal

- Add EF Core SQLite
- Create first models
- Seed demo data
- Show dashboard counts from database

---

## V1.1 Vanessa / OSHE Goal

- Add Safety Overview page.
- Make Safety Overview the starting point for Vanessa/OSHE demos.
- Show safety/compliance attention items in one view.
- Link Safety Overview to Risk Register, Corrective Actions, Training, Documents, and Activity Log.
- Update README and documentation so the demo path matches the new safety/compliance workflow.
- Keep the prototype honest: local SQLite, demo data, no production auth, no live integrations yet.

---

## Do Not Build Yet

- Login/auth
- Permissions
- Email notifications
- File uploads
- Power BI embedding
- Full ERP features
- Live SharePoint/Outlook/Teams integrations
- Live Xero/Cin7/WorkflowMax integrations
- AI/OCR document extraction
- Production deployment
