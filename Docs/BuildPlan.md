# OperationsFlow Build Plan

This document summarises the build plan and current state for OperationsFlow.

---

## Current Build State

Week 2 UI cleanup and workflow polish is complete.

Completed/reviewable areas include:

- Dashboard
- Work Orders
- Corrective Actions
- Safety Overview
- Safety Meeting Pack
- Compliance Calendar
- Controlled Documents
- Risk Register
- Training Compliance
- Document Intake
- Reminder Centre
- Workload
- Reports
- CSV exports
- Data Quality
- Activity Log
- Admin Settings starter
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

Week 2 also completed:

- Shared UI component refactor.
- App-wide CSS cleanup.
- Activity history empty-state fix.
- Workload card layout polish.
- Calendar section build fix.
- Final manual route/workflow testing.

---

## Week 2 Lock-In Tasks

Before moving into Week 3:

- [x] `dotnet build` passes.
- [x] Manual page testing completed.
- [x] Core create/edit flows tested.
- [x] Management/evidence pages checked.
- [x] CSS cleanup applied.
- [x] Documentation refreshed.
- [ ] Screenshots refreshed after final UI.
- [ ] README screenshot links confirmed.
- [ ] Week 2 merged to `main`.
- [ ] Week 2 backup branch created.
- [ ] Week 3 branch created from updated `main`.

---

## Week 2 Final Test Checklist

Manual QA checklist before pushing/merging:

- [x] `dotnet build` passes.
- [x] `dotnet run` starts app.
- [x] Dashboard loads.
- [x] Portfolio Hub loads.
- [x] Reviewer Checklist loads.
- [x] Demo Guide loads.
- [x] Business Value loads.
- [x] Work Orders list loads.
- [x] Work Order create/edit/details works.
- [x] Corrective Actions list loads.
- [x] Corrective Action create/edit/details works.
- [x] Risk/Training/Documents can create prefilled corrective actions.
- [x] Document Intake list loads.
- [x] Document Intake create/edit works.
- [x] Safety Overview loads.
- [x] Safety Meeting Pack loads.
- [x] Compliance Calendar loads.
- [x] Documents loads.
- [x] Risk Register loads.
- [x] Training loads.
- [x] Reminders loads.
- [x] Workload loads.
- [x] Reports loads.
- [x] Data Quality loads.
- [x] Activity Log loads.
- [x] Technical Overview loads.
- [x] Data Model loads.
- [x] User Roles loads.
- [x] Audit Overview loads.
- [x] Deployment Overview loads.
- [x] Testing Overview loads.
- [x] Integration Overview loads.
- [x] Prototype Scope loads.
- [x] Implementation Plan loads.
- [x] Admin Settings loads.
- [x] CSV exports work.
- [x] Activity history empty states look correct.
- [x] README/docs are being updated.
- [ ] Screenshots are current enough after final UI cleanup.

---

## Recommended Branch Workflow

From completed `week2-ui-cleanup`:

```bash
git checkout week2-ui-cleanup
dotnet build
git status
git add .
git commit -m "Complete Week 2 UI cleanup and stylesheet consolidation"
git push origin week2-ui-cleanup
```

Merge to main:

```bash
git checkout main
git pull origin main
git merge week2-ui-cleanup
dotnet build
git push origin main
```

After README/screenshots/docs refresh:

```bash
git add .
git commit -m "Update README, screenshots, and docs for Week 2 UI cleanup"
git push origin main
```

Create backup:

```bash
git checkout main
git pull origin main
git branch backup/week2-ui-cleanup-complete
git push origin backup/week2-ui-cleanup-complete
```

Create Week 3 branch:

```bash
git checkout -b week3-production-foundation
git push -u origin week3-production-foundation
```

---

## Week 3 Build Goal

Week 3 is **Production Foundation**.

It should build local working versions of production features using production-shaped architecture.

Week 3 should include:

- Production configuration/options structure.
- File storage interface.
- Local file storage provider.
- SharePoint file storage provider placeholder.
- Document attachment model.
- Local Document Library page.
- Attachment UI for records.
- Role/permission foundation.
- Permission Matrix page.
- Microsoft Lists schema registry.
- M365 Readiness / Production Readiness page.
- Mock/dry-run sync service.
- Notification rule and local notification preview/log.
- README/docs updates for production foundation.

---

## Week 4 Direction

Week 4 is the **full production Microsoft 365 implementation**.

Week 4 should connect:

- Real Microsoft 365 environment.
- Real SharePoint site.
- Real Microsoft Lists.
- Real document library.
- Real file uploads to SharePoint.
- Real list sync.
- Real Teams/Outlook/Power Automate notification path.
- Production configuration and setup documentation.

---

## Current Build Summary

OperationsFlow has moved beyond an early dashboard prototype.

It is now a broad, connected business workflow prototype with working modules, reviewer support pages, management/evidence pages, activity traceability, data quality, exports, shared UI components, cleaned CSS, production planning pages, and a clear next step toward production foundation work.
