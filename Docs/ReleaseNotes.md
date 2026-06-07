# OperationsFlow Release Notes

## Week 2 UI Cleanup and Workflow Polish

### Summary

Week 2 completed a major UI, workflow, documentation, and stylesheet cleanup pass for OperationsFlow.

The project moved from a broad working prototype into a more polished, consistent, reviewable business workflow system.

---

## Completed

### Core Workflow Pages

Refactored and tested:

- Work Orders list/create/details/edit.
- Corrective Actions list/create/details/edit.
- Document Intake list/create/edit.
- Risk Register review/action page.
- Training Compliance review/action page.
- Document Control review/action page.

### Management / Evidence Pages

Refactored and tested:

- Reminder Centre.
- Workload.
- Reports.
- Data Quality.
- Activity Log.

### Support / Reviewer Pages

Updated to the shared UI system:

- Portfolio Hub.
- Reviewer Checklist.
- Demo Guide.
- Business Value.
- Technical Overview.
- Data Model.
- User Roles.
- Audit Overview.
- Deployment Overview.
- Testing Overview.
- Integration Overview.
- Prototype Scope.
- Implementation Plan.
- Admin Settings.
- Safety Overview.
- Safety Meeting Pack.
- Compliance Calendar.

### Shared UI Components

Used across the app:

- PageHero
- PurposeNote
- MetricGrid
- MetricCard
- InfoPanel
- ActionStrip
- TableCard
- FilterBar
- GuidanceNote
- ActivityHistoryPanel
- EmptyState

### Fixes

Fixed:

- Activity history empty-state rendering.
- Duplicate/old activity history component confusion.
- Calendar section build errors.
- Corrective Action source-linked query prefill.
- Corrective Action return URL behaviour.
- Workload card layout density.
- Large duplicated stylesheet patterns.

### CSS Cleanup

Completed:

- Cleaned and reduced the large `app.css` file.
- Preserved shared `of-*` UI component classes.
- Removed obvious duplicated/old clutter.
- Polished dense workload card layout into review lanes.
- Improved table/card/badge/form/filter consistency.

---

## Manual Testing

Manual tests completed:

- Build check.
- App run check.
- Main route click-through.
- Create/edit flows.
- Activity history checks.
- Source-linked corrective actions.
- CSV export links.
- Reports/Data Quality/Activity Log.
- Workload/Reminders.
- Static/support pages.

---

## Current Status

```text
Week 2 UI cleanup: Complete
Manual testing: Complete
Build: Passing
Core workflows: Working
CSS cleanup: Complete enough for Week 2
Documentation: Updated
Screenshots: Refresh after final UI merge
```

---

## Next Stage

Week 3: Production Foundation.

Planned work:

- Production configuration/options.
- File storage interface.
- Local file storage provider.
- Document attachment model.
- Local Document Library.
- Role/permission foundation.
- Microsoft Lists schema registry.
- M365 readiness/dry-run sync.
- Notification rules and preview/log.

Week 4: Full production Microsoft 365 implementation.
