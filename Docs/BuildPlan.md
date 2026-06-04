# OperationsFlow Build Plan

This document summarises the build plan and current state for OperationsFlow.

---

## Current Build Goal

The current sprint goal is to make OperationsFlow sendable and reviewable for Vanessa, Lester, Peter, employers, and technical reviewers.

The project needs to show:

- Working business workflow screens.
- Editable records.
- Reporting and exports.
- Data quality checks.
- Activity traceability.
- Safety/compliance review value.
- Document/admin intake value.
- Reviewer guidance.
- Honest prototype boundaries.
- Realistic production upgrade path.

---

## Current Build State

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

---

## Final Packaging Blocks

### Block 28 — Documentation Refresh

Goal:

Update README and Docs folder to match the current build.

Tasks:

- Update README.
- Update Architecture.
- Update Case Study.
- Update Demo Walkthrough.
- Update Feature Checklist.
- Update Known Limitations.
- Update Enterprise Upgrade Plan.
- Update Targeted Pitches.
- Update Technical Decisions.
- Update Build Plan.

Status:

- In progress / packaging stage.

---

### Block 29 — Screenshot and Demo Checklist

Goal:

Create a screenshot/review checklist for final presentation.

Recommended screenshots:

- Portfolio Hub
- Reviewer Checklist
- Business Value
- Dashboard
- Safety Meeting Pack
- Corrective Actions list
- Corrective Action edit page
- Document Intake
- Workload
- Reports
- Data Quality
- Activity Log
- Technical Overview
- Deployment Overview
- Integration Overview

Recommended demo check:

- App builds.
- App runs.
- Navigation works.
- Key pages load.
- Create/edit workflows work.
- Reports load.
- CSV exports work.
- Data Quality loads.
- Activity history loads.
- Reviewer path is understandable.

---

### Block 30 — CSS Cleanup / Refactor Plan

Goal:

Reduce risk from large CSS file and make future maintenance easier.

Recommended work:

- Identify repeated card/table/badge classes.
- Extract shared page layout classes.
- Move page-specific styles into grouped sections or files.
- Remove unused duplicate styles.
- Keep existing UI stable during cleanup.
- Avoid major redesign during packaging.

Important:

CSS cleanup should be careful and incremental because visual polish is already working.

---

### Block 31 — Final Release Package

Goal:

Prepare the final review package.

Tasks:

- Final build check.
- Final run check.
- Final navigation check.
- Final screenshot update.
- Final README/docs check.
- Commit docs and screenshots.
- Push branch.
- Prepare short message for Vanessa/Lester/Peter.

---

## Recommended Final Branch Workflow

Use the `vanessa-safety-overview` branch for the current review package.

Suggested commit messages:

```bash
git add .
git commit -m "Update documentation for current OperationsFlow review package"
git push origin vanessa-safety-overview
```

For screenshots:

```bash
git add Screenshots Docs README.md
git commit -m "Add final review screenshots and demo checklist"
git push origin vanessa-safety-overview
```

For CSS cleanup:

```bash
git add wwwroot
git commit -m "Clean up shared page styling"
git push origin vanessa-safety-overview
```

For final package:

```bash
git add .
git commit -m "Prepare OperationsFlow review package"
git push origin vanessa-safety-overview
```

---

## Five-Day Packaging Plan

### Day 1

- Finish reviewer/system pages.
- Update docs.
- Confirm build and navigation.

### Day 2

- Screenshot package.
- README polish.
- Demo/reviewer checklist.
- Fix obvious layout issues.

### Day 3

- CSS cleanup pass.
- Confirm pages still look stable.
- Run full manual test checklist.

### Day 4

- Package for Vanessa/Lester/Peter.
- Prepare messages.
- Review final repo branch.

### Day 5

- Buffer day.
- Fix issues found during review.
- Final push and send.

---

## Manual QA Checklist

Before sending:

- [ ] `dotnet build` passes.
- [ ] `dotnet run` starts app.
- [ ] Dashboard loads.
- [ ] Portfolio Hub loads.
- [ ] Reviewer Checklist loads.
- [ ] Demo Guide loads.
- [ ] Business Value loads.
- [ ] Corrective Actions list loads.
- [ ] Corrective Action create/edit works.
- [ ] Document Intake list loads.
- [ ] Document Intake create/edit works.
- [ ] Safety Meeting Pack loads.
- [ ] Workload loads.
- [ ] Reports loads.
- [ ] Data Quality loads.
- [ ] Activity Log loads.
- [ ] Technical Overview loads.
- [ ] Deployment Overview loads.
- [ ] Integration Overview loads.
- [ ] CSV exports work.
- [ ] README matches current app.
- [ ] Docs match current app.
- [ ] Screenshots are current enough.

---

## Current Build Summary

OperationsFlow has moved beyond an early dashboard prototype. It is now a broad, connected business workflow prototype with working modules, reviewer support pages, production planning pages, and documentation.

The remaining work is mainly packaging, polish, documentation, screenshots, and careful cleanup.
