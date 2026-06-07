# OperationsFlow Technical Decisions

This document records key technical decisions made for OperationsFlow and why they were appropriate for the current prototype stage.

---

## Project Type

### Decision

Build OperationsFlow as a Blazor/.NET 8 web application.

### Reason

Blazor and .NET are suitable for internal business systems because they support:

- C# application logic.
- Component-based UI.
- Strong data modelling.
- Entity Framework Core.
- Future authentication/roles.
- Future deployment to internal/cloud hosting.

### Trade-off

Blazor is more structured than a quick static HTML prototype, but it better demonstrates real business application development.

---

## Database

### Decision

Use SQLite for the current prototype.

### Reason

SQLite is simple for local portfolio development:

- No database server required.
- Easy to run locally.
- Works well with EF Core.
- Good enough to demonstrate persistence, CRUD, reports, and exports.

### Trade-off

SQLite is not the final production target. A production version would move to SQL Server, Azure SQL, PostgreSQL, or another hosted database.

---

## Entity Framework Core

### Decision

Use EF Core for data access and persistence.

### Reason

EF Core provides:

- Model-backed records.
- Querying.
- Relationship handling.
- Future migration path.
- Production database portability.

### Trade-off

Some pages currently interact with EF models more directly than a fully layered production system should. Future production work should move more logic into services.

---

## Seeded Demo Data

### Decision

Use seeded demo records.

### Reason

The project needed realistic examples for review without using private business data.

Seeded data allows reviewers to see:

- Overdue records.
- High-priority work.
- Expired training.
- Document review issues.
- Risk items.
- Corrective actions.
- Document intake examples.
- Activity history.

### Trade-off

Seeded data is not the same as live data. Production would require real records, data import, validation, and backups.

---

## CRUD Workflows

### Decision

Build full create/edit workflows for key modules rather than only static dashboards.

### Reason

This demonstrates that OperationsFlow is more than a visual mockup.

Implemented create/edit workflows include:

- Work Orders
- Corrective Actions
- Document Intake

### Trade-off

Building actual workflows takes longer than a static UI, but it better proves practical application development capability.

---

## Activity Logging

### Decision

Add global Activity Log and per-record Activity History.

### Reason

Business workflow systems need traceability. Activity logging helps show:

- What changed.
- When it changed.
- Which module/record changed.
- Whether workflow progress is visible.

### Trade-off

Current activity logging is prototype-level. Production audit logging would need authenticated users, field-level before/after values, immutable events, and retention rules.

---

## CSV Export

### Decision

Add CSV export endpoints.

### Reason

Small businesses often use Excel, email, or management reports even when they have internal systems.

CSV exports demonstrate:

- Reporting usefulness.
- External review capability.
- Spreadsheet compatibility.
- Power BI/Excel-ready direction.

### Trade-off

CSV exports are not a full reporting platform. Production reporting would need approved KPI definitions, scheduled exports, permissions, and possibly Power BI integration.

---

## Reviewer Pages Inside the App

### Decision

Add pages such as Portfolio Hub, Reviewer Checklist, Demo Guide, Business Value, Prototype Scope, Technical Overview, Deployment Overview, Testing Overview, and Integration Overview.

### Reason

The project needs to be understandable without a long spoken explanation.

These pages help reviewers understand:

- What the project is.
- What it proves.
- What to click.
- What is prototype-only.
- What production upgrades would be needed.
- How it maps to business value and Microsoft 365 workflows.

### Trade-off

These pages are not normal end-user ERP screens, but they are valuable for portfolio review and handover.

---

## Shared UI Component System

### Decision

Refactor repeated page structures into shared Razor UI components.

### Reason

The app grew into many pages with repeated headers, panels, metric cards, filter bars, table cards, guidance notes, and empty states.

Shared components reduce duplication and make the app easier to maintain.

Key shared UI components include:

- `PageHero`
- `PurposeNote`
- `MetricGrid`
- `MetricCard`
- `InfoPanel`
- `ActionStrip`
- `TableCard`
- `FilterBar`
- `GuidanceNote`
- `ActivityHistoryPanel`
- `EmptyState`

### Trade-off

Shared components require more care with parameters and named child content, but they make the UI much more consistent.

---

## CSS Strategy

### Decision

Use one main CSS file during rapid build-out, then clean and consolidate it after the shared UI refactor.

### Reason

A single file allowed fast iteration during the first build. After Week 2, the stylesheet was cleaned and reduced so it better supports the shared UI component system.

### Current State

- `wwwroot/app.css` remains the main stylesheet.
- Duplicate/old clutter was reduced.
- Shared `of-*` classes are the preferred styling direction.
- Workload dense card styling was polished into review lanes.

### Trade-off

The CSS is cleaner but still not fully modular. A future production version could split it into base/layout/component/page files if the app continues to grow.

---

## Microsoft 365 Integration Planning

### Decision

Document Microsoft 365 integration as a future path rather than implementing live integration immediately.

### Reason

The current project should prove workflow first. Live integration should come after:

- Workflow rules are stable.
- Ownership/status/due-date logic is confirmed.
- Security requirements are defined.
- Source of truth is agreed.

### Future Direction

Potential integration targets:

- SharePoint document libraries.
- Teams notifications.
- Outlook reminders.
- Microsoft Lists.
- Excel/Power BI-ready exports.
- Microsoft Entra ID authentication.

Week 3 should build local production-shaped providers and schemas. Week 4 should connect the live Microsoft 365 implementation.

---

## Testing Strategy

### Decision

Use manual testing for the current prototype and document the production testing path.

### Reason

The project is still moving quickly and is currently portfolio-focused.

Current testing:

- Build test.
- Run test.
- Navigation click-through.
- Create/edit workflow checks.
- Report/data quality review.
- Visual review.
- CSV export checks.

Future testing:

- Unit tests.
- Integration tests.
- UI smoke tests.
- Role/security tests.
- Export tests.
- Migration tests.
- Deployment tests.

---

## Production Boundary

### Decision

Clearly state that OperationsFlow is not production-ready yet.

### Reason

This keeps the project honest and credible.

Current prototype proves:

- Workflow model.
- UI structure.
- Data model.
- Reporting concept.
- Traceability concept.
- Data quality concept.
- Shared UI/component direction.
- Production upgrade plan.

Production still needs:

- Authentication.
- Roles.
- Hosted database.
- Backups.
- Monitoring.
- Automated tests.
- Deployment pipeline.
- Live integrations.
- Production file/document storage.

---

## Technical Summary

OperationsFlow was built with practical prototype decisions: Blazor for UI, EF Core for persistence, SQLite for local demo data, seeded records for realistic review, activity logging for traceability, CSV exports for management/reporting workflows, shared UI components for maintainability, cleaned CSS for consistency, and reviewer pages for clear portfolio communication.

The technical direction is realistic for a future production internal business system.
