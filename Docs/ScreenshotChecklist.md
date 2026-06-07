# OperationsFlow Screenshot Checklist

## Purpose

This checklist explains which screenshots should be included in the OperationsFlow review package and what each screenshot demonstrates.

The screenshots are used to show the project visually before a reviewer runs the app. They also help keep the GitHub repository reviewable for Vanessa, Lester, Peter, employers, or technical reviewers.

OperationsFlow is not just a set of pages. The screenshots prove that the project has:

- A clear reviewer starting point.
- Connected workflow modules.
- Editable business records.
- Management reporting views.
- Safety/compliance review pages.
- Admin/document workflow tracking.
- Activity traceability.
- Data quality checks.
- Honest prototype boundaries.
- A realistic production and Microsoft 365 upgrade path.

---

## Current Screenshot Package Status

Current screenshot package target:

- **36 screenshots**
- Screenshots should be named in review order.
- Screenshots should cover the main workflow, safety/compliance pages, admin workflow, reviewer pages, technical pages, and production planning pages.

Because Week 2 included a major UI cleanup, screenshots should be refreshed after the final UI/CSS merge.

---

## README Screenshots

The README should display a small number of high-value screenshots, not all 36.

Recommended README screenshots:

| Screenshot | Why It Is Shown In README |
|---|---|
| `01-portfolio-hub.png` | Shows the reviewer starting point. |
| `10-corrective-actions-list.png` | Shows real workflow records. |
| `12-corrective-action-edit-activity-history.png` | Shows editable records and traceability. |
| `14-safety-meeting-pack.png` | Shows safety/compliance review value. |
| `23-workload.png` | Shows owner accountability and management visibility. |
| `25-data-quality.png` | Shows weak/overdue records being surfaced. |

The full screenshot list belongs in this checklist instead of the README so the README stays readable.

---

## Minimum Sendable Screenshot Pack

| Screenshot | Page / Route | What It Proves | Priority |
|---|---|---|---|
| `01-portfolio-hub.png` | `/portfolio-hub` | The project has a clear reviewer landing page and review path. | Critical |
| `02-reviewer-checklist.png` | `/reviewer-checklist` | A reviewer can understand what to click and what to verify. | Critical |
| `03-demo-guide.png` | `/demo-guide` | The project supports guided review paths. | Critical |
| `04-business-value.png` | `/business-value` | The business problem and value are explained. | Critical |
| `05-dashboard.png` | `/` | The app has a central summary/dashboard. | High |
| `10-corrective-actions-list.png` | `/corrective-actions` | Workflow records can be reviewed, filtered, and managed. | Critical |
| `12-corrective-action-edit-activity-history.png` | Corrective action edit page | Records can be edited with helper guidance and activity history. | Critical |
| `14-safety-meeting-pack.png` | `/safety-meeting-pack` | Safety/compliance records feed a meeting-ready review page. | Critical |
| `23-workload.png` | `/workload` | Owner accountability, overdue work, and pressure are visible. | Critical |
| `24-reports.png` | `/reports` | Management summaries and export concepts are present. | High |
| `25-data-quality.png` | `/data-quality` | Weak, overdue, expired, or incomplete records are surfaced before review. | High |
| `26-activity-log.png` | `/activity-log` | Workflow changes are traceable. | High |
| `28-technical-overview.png` | `/technical-overview` | The technical structure and production direction are explained. | High |
| `32-deployment-overview.png` | `/deployment-overview` | Production deployment requirements are explained. | Medium |
| `34-integration-overview.png` | `/integration-overview` | Microsoft 365 / SharePoint / Teams / Outlook upgrade path is explained. | Medium |

---

## Full Screenshot Package

| # | Screenshot | Page / Route | What It Proves | Audience |
|---|---|---|---|---|
| 01 | `01-portfolio-hub.png` | `/portfolio-hub` | Central starting page for reviewing the project. | Everyone |
| 02 | `02-reviewer-checklist.png` | `/reviewer-checklist` | Guided review path with business, workflow, record, data, and production checks. | Everyone |
| 03 | `03-demo-guide.png` | `/demo-guide` | Business, admin, and technical demo paths are available. | Everyone |
| 04 | `04-business-value.png` | `/business-value` | The project explains the business problem and value clearly. | Vanessa / employers |
| 05 | `05-dashboard.png` | `/` | Main overview and high-level status dashboard. | Everyone |
| 06 | `06-work-orders-list.png` | `/work-orders` | Operational work can be tracked. | Employers / business reviewers |
| 07 | `07-work-order-create.png` | Work order create page | New operational records can be created. | Technical reviewers |
| 08 | `08-work-order-edit.png` | Work order edit page | Operational records can be edited. | Technical reviewers |
| 09 | `09-work-order-details-activity-history.png` | Work order details page | A single work order can be reviewed with traceability. | Employers / technical reviewers |
| 10 | `10-corrective-actions-list.png` | `/corrective-actions` | Corrective/improvement actions can be reviewed. | Vanessa / employers |
| 11 | `11-corrective-action-create.png` | `/corrective-actions/create` | New corrective actions can be created. | Employers / technical reviewers |
| 12 | `12-corrective-action-edit-activity-history.png` | Corrective action edit page | Corrective actions can be updated with helper guidance and activity history. | Everyone |
| 13 | `13-safety-overview.png` | `/compliance-dashboard` | Safety/compliance summary information is visible. | Vanessa |
| 14 | `14-safety-meeting-pack.png` | `/safety-meeting-pack` | Multiple compliance records feed a practical meeting view. | Vanessa |
| 15 | `15-compliance-calendar.png` | `/compliance-calendar` | Overdue, due-soon, and future work can be planned. | Vanessa / management |
| 16 | `16-documents.png` | `/documents` | Controlled document review can be tracked. | Vanessa / business reviewers |
| 17 | `17-risk-register.png` | `/risk-register` | Risk items, controls, owners, and review dates are visible. | Vanessa |
| 18 | `18-training.png` | `/training` | Training compliance and expiry tracking are visible. | Vanessa |
| 19 | `19-document-intake-list.png` | `/document-intake` | Incoming admin/document work can be assigned and tracked. | Lester / Peter |
| 20 | `20-document-intake-create.png` | Document intake create page | New incoming document/admin records can be created. | Lester / Peter / technical reviewers |
| 21 | `21-document-intake-edit.png` | Document intake edit page | Document intake records can be edited with status, owner, target system, due date, and notes. | Lester / Peter |
| 22 | `22-reminders.png` | `/reminders` | Overdue and due-soon work is surfaced. | Management |
| 23 | `23-workload.png` | `/workload` | Assigned work and owner pressure are visible. | Management |
| 24 | `24-reports.png` | `/reports` | Management summaries and export concepts are available. | Management / employers |
| 25 | `25-data-quality.png` | `/data-quality` | Weak records are identified before reporting. | Management / employers |
| 26 | `26-activity-log.png` | `/activity-log` | Record changes and workflow activity are traceable. | Technical / audit reviewers |
| 27 | `27-admin-settings.png` | `/admin-settings` | A future configuration area exists. | Technical reviewers |
| 28 | `28-technical-overview.png` | `/technical-overview` | Stack, modules, architecture, and production path are explained. | Technical reviewers |
| 29 | `29-data-model.png` | `/data-model` | Records, shared fields, relationships, and data quality rules are explained. | Technical reviewers |
| 30 | `30-user-roles.png` | `/user-roles` | Future role/permission model is explained. | Technical / production reviewers |
| 31 | `31-audit-overview.png` | `/audit-overview` | Activity history, traceability, and production audit needs are explained. | Technical / audit reviewers |
| 32 | `32-deployment-overview.png` | `/deployment-overview` | Hosting, database, backups, monitoring, and release planning are explained. | Technical reviewers |
| 33 | `33-testing-overview.png` | `/testing-overview` | Manual QA and future automated testing requirements are explained. | Technical reviewers |
| 34 | `34-integration-overview.png` | `/integration-overview` | Microsoft 365 / SharePoint / Teams / Outlook integration path is explained. | Business / technical reviewers |
| 35 | `35-prototype-scope.png` | `/prototype-scope` | The app is honest about current scope and prototype boundaries. | Everyone |
| 36 | `36-implementation-plan.png` | `/implementation-plan` | The app explains how it could move toward production. | Business / technical reviewers |

---

## Screenshot Folder Structure

Recommended repository structure:

```text
Docs/
  Screenshots/
    01-portfolio-hub.png
    02-reviewer-checklist.png
    ...
    36-implementation-plan.png
```

The README image links assume screenshots are stored in:

```text
Docs/Screenshots/
```

If screenshots are stored somewhere else, update the README image links and this checklist to match.

---

## Vanessa / OSHE Screenshot Pack

| Screenshot | Why It Matters |
|---|---|
| `01-portfolio-hub.png` | Shows where to start. |
| `04-business-value.png` | Explains why the system matters. |
| `10-corrective-actions-list.png` | Shows follow-up actions. |
| `12-corrective-action-edit-activity-history.png` | Shows editable workflow, helper guidance, and traceability. |
| `13-safety-overview.png` | Shows safety/compliance overview. |
| `14-safety-meeting-pack.png` | Shows safety/compliance review value. |
| `15-compliance-calendar.png` | Shows overdue and due-soon compliance planning. |
| `16-documents.png` | Shows document review tracking. |
| `17-risk-register.png` | Shows risk follow-up. |
| `18-training.png` | Shows training expiry/compliance tracking. |
| `22-reminders.png` | Shows due/overdue follow-up. |
| `23-workload.png` | Shows owner accountability. |
| `24-reports.png` | Shows management review/export value. |
| `25-data-quality.png` | Shows weak records and overdue issues. |
| `35-prototype-scope.png` | Shows honest prototype boundaries. |

---

## Lester / Peter Screenshot Pack

| Screenshot | Why It Matters |
|---|---|
| `01-portfolio-hub.png` | Shows where to start. |
| `03-demo-guide.png` | Shows admin/document review path. |
| `19-document-intake-list.png` | Shows incoming document/admin work tracking. |
| `20-document-intake-create.png` | Shows new document intake record creation. |
| `21-document-intake-edit.png` | Shows status, owner, target system, due date, and notes. |
| `22-reminders.png` | Shows follow-up visibility. |
| `23-workload.png` | Shows assigned admin/document work. |
| `24-reports.png` | Shows reporting/export concepts. |
| `26-activity-log.png` | Shows traceability. |
| `34-integration-overview.png` | Shows future Microsoft 365 / SharePoint / Outlook direction. |
| `36-implementation-plan.png` | Shows production rollout thinking. |

---

## Employer / Technical Screenshot Pack

| Screenshot | Why It Matters |
|---|---|
| `01-portfolio-hub.png` | Shows the project is packaged for review. |
| `02-reviewer-checklist.png` | Shows handover/review thinking. |
| `03-demo-guide.png` | Shows a guided demo path. |
| `06-work-orders-list.png` | Shows operational records. |
| `07-work-order-create.png` | Shows create workflow. |
| `08-work-order-edit.png` | Shows edit workflow. |
| `09-work-order-details-activity-history.png` | Shows per-record activity history. |
| `10-corrective-actions-list.png` | Shows corrective action workflow. |
| `11-corrective-action-create.png` | Shows corrective action creation. |
| `12-corrective-action-edit-activity-history.png` | Shows editable records and traceability. |
| `24-reports.png` | Shows reporting/export thinking. |
| `25-data-quality.png` | Shows business rules and validation thinking. |
| `26-activity-log.png` | Shows traceability. |
| `28-technical-overview.png` | Shows stack and architecture. |
| `29-data-model.png` | Shows record modelling and shared workflow fields. |
| `30-user-roles.png` | Shows production security awareness. |
| `31-audit-overview.png` | Shows audit/event history awareness. |
| `32-deployment-overview.png` | Shows production deployment awareness. |
| `33-testing-overview.png` | Shows QA awareness. |
| `34-integration-overview.png` | Shows Microsoft 365/integration awareness. |
| `35-prototype-scope.png` | Shows honest scope boundaries. |
| `36-implementation-plan.png` | Shows rollout planning. |

---

## Screenshot Quality Rules

Before uploading screenshots, check:

- The page is not halfway loaded.
- The browser is zoomed consistently.
- The sidebar is visible.
- The page title is visible.
- Important cards/tables are visible.
- No broken layout, clipped text, or accidental scrollbars are obvious.
- The screenshot is named clearly.
- Screenshots are up to date with the current branch.
- Screenshots match the current README and docs.

---

## Screenshot Review Checklist

Before marking the screenshot package as ready, confirm:

- [ ] The screenshots folder exists in the repository.
- [ ] Screenshots are stored in `Docs/Screenshots/`.
- [ ] Screenshots are named clearly from `01` to `36`.
- [ ] Portfolio Hub screenshot is included.
- [ ] Reviewer Checklist screenshot is included.
- [ ] Demo Guide screenshot is included.
- [ ] Business Value screenshot is included.
- [ ] Dashboard screenshot is included.
- [ ] Work Orders screenshots are included.
- [ ] Corrective Actions screenshots are included.
- [ ] Corrective Action edit/activity history screenshot is included.
- [ ] Safety/compliance screenshots are included.
- [ ] Document Intake screenshots are included.
- [ ] Reminders screenshot is included.
- [ ] Workload screenshot is included.
- [ ] Reports screenshot is included.
- [ ] Data Quality screenshot is included.
- [ ] Activity Log screenshot is included.
- [ ] Technical Overview screenshot is included.
- [ ] Data Model screenshot is included.
- [ ] User Roles screenshot is included.
- [ ] Audit Overview screenshot is included.
- [ ] Deployment Overview screenshot is included.
- [ ] Testing Overview screenshot is included.
- [ ] Integration Overview screenshot is included.
- [ ] Prototype Scope screenshot is included.
- [ ] Implementation Plan screenshot is included.
- [ ] README embeds the top 6 screenshots.
- [ ] README links to this screenshot checklist.
- [ ] Screenshots match the current branch.
- [ ] No screenshots show broken layout or old page names.
- [ ] The screenshot pack can be understood without a spoken explanation.

---

## What This Proves

A strong screenshot package proves that OperationsFlow is:

- Reviewable without a live call.
- Packaged like a serious portfolio project.
- Supported by documentation and evidence.
- Built around real workflow thinking.
- Clear enough for business and technical reviewers.
- Honest about prototype scope and production requirements.
