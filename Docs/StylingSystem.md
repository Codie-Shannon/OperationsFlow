# OperationsFlow Styling System

## Purpose

This document replaces the older CSS cleanup plan.

The Week 2 CSS cleanup has been completed enough for the current review package. The app now uses a more consistent shared UI styling system built around reusable Razor components and shared `of-*` CSS classes.

---

## Current Styling Direction

The preferred styling direction is:

```text
Reusable Razor UI components
    +
Shared `of-*` CSS classes
    +
Limited compatibility classes for older sections
```

The stylesheet is still mainly stored in:

```text
wwwroot/app.css
```

This is acceptable for the current prototype. If the app grows further, the CSS can be split into smaller files.

---

## Shared UI Components

The app now uses shared components such as:

- `PageHero`
- `PurposeNote`
- `MetricGrid`
- `MetricCard`
- `InfoPanel`
- `ActionStrip`
- `TableCard`
- `FilterBar`
- `StatusFlow`
- `GuidanceNote`
- `ActivityHistoryPanel`
- `EmptyState`

These components standardise:

- Page headers.
- Purpose notes.
- Metric cards.
- Info panels.
- Filter bars.
- Action strips.
- Tables.
- Empty states.
- Guidance notes.
- Activity history sections.

---

## Preferred CSS Class Families

Preferred shared classes include:

- `of-btn`
- `of-btn-primary`
- `of-btn-secondary`
- `of-badge`
- `of-badge-success`
- `of-badge-warning`
- `of-badge-danger`
- `of-badge-info`
- `of-input`
- `of-select`
- `of-textarea`
- `of-form-grid`
- `of-form-field`
- `of-form-actions`
- `of-review-proof-grid`
- `of-review-proof-card`
- `of-mini-list`
- `of-mini-list-item`
- `of-link-row`
- `of-muted-text`
- `of-activity-table`

---

## What Was Cleaned

The Week 2 cleanup:

- Reduced duplicated CSS.
- Preserved classes still used by Razor pages.
- Kept the shared `of-*` styling system.
- Improved metric card spacing.
- Improved table overflow/readability.
- Improved badge consistency.
- Improved filter/form layouts.
- Improved empty states.
- Improved dense Workload card behaviour.
- Removed the need for a separate CSS cleanup planning document.

---

## Why Some Compatibility Classes Remain

Some older non-`of-*` classes remain intentionally.

Reason:

- Razor pages/components may still reference them.
- Removing them aggressively could cause visual regressions.
- The goal was a safe cleanup, not a risky rewrite.

Examples of compatibility areas:

- Bootstrap/Blazor template classes.
- Older dashboard/module classes.
- Utility classes used by existing pages.
- Navigation/sidebar classes.

---

## Future CSS Structure

If the project grows further, a future CSS split could be:

```text
wwwroot/css/base.css
wwwroot/css/layout.css
wwwroot/css/components/buttons.css
wwwroot/css/components/cards.css
wwwroot/css/components/forms.css
wwwroot/css/components/tables.css
wwwroot/css/components/badges.css
wwwroot/css/pages/dashboard.css
wwwroot/css/pages/operations.css
wwwroot/css/pages/compliance.css
wwwroot/css/pages/management.css
wwwroot/css/pages/reviewer.css
wwwroot/css/responsive.css
```

This is not required for the current Week 2 package.

---

## Styling Rule Going Forward

For new Week 3 work:

1. Prefer existing shared components.
2. Prefer `of-*` classes.
3. Avoid creating page-specific styles unless necessary.
4. Keep new CSS grouped and labelled.
5. Avoid duplicating card/table/form/badge rules.
6. Check Workload, Reports, Data Quality, Reminders, and mobile width after styling changes.

---

## Current Styling Summary

The styling system is now consistent enough for portfolio review and Week 3 production foundation work.

Future styling work should be incremental and tested against:

- `/workload`
- `/reports`
- `/data-quality`
- `/reminders`
- `/work-orders`
- `/corrective-actions`
- `/document-intake`
- `/risk-register`
- `/documents`
- `/training`
