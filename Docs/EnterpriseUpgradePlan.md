# OperationsFlow Enterprise Upgrade Plan

## Purpose

This document explains how OperationsFlow could move from the current local Blazor/SQLite portfolio prototype into a production-ready internal business workflow system.

The current project already demonstrates workflow design, reporting, exports, reminders, workload visibility, data quality, activity traceability, reviewer support, shared UI structure, and production planning.

---

## Current Prototype State

Current state:

- Local Blazor/.NET 8 app.
- SQLite database.
- Seeded demo data.
- Manual build/run testing.
- Shared UI component system.
- Cleaned consolidated stylesheet.
- No real authentication.
- No enforced role-based permissions.
- No live Microsoft 365 integration.
- No production document storage.
- No hosted deployment.
- No automated test suite.

The prototype is suitable for portfolio review and business process demonstration.

---

## Target Production State

A production version would include:

- Hosted application environment.
- Production database.
- Secure authentication.
- Role-based access control.
- Controlled document storage.
- Notification rules.
- Reporting/export governance.
- Audit logging.
- Backups and restore testing.
- Automated tests.
- Deployment pipeline.
- Monitoring and support.
- Microsoft 365 / SharePoint / Teams / Outlook integration where appropriate.

---

## Recommended Upgrade Phases

### Phase 1 — Stabilise the Prototype

Goal: make the local system cleaner, easier to maintain, and safer to expand.

Completed in Week 2:

- Shared UI component system.
- Consistent page layout.
- Core workflow page refactor.
- Management/evidence page refactor.
- Support/static page refactor.
- CSS cleanup and consolidation.
- Workload review lane polish.
- Final manual page testing.
- Documentation refresh.

Outcome:

A polished portfolio/demo package ready for Vanessa, Lester, Peter, employers, and technical reviewers.

---

### Phase 2 — Production Foundation Layer

Goal: build local working versions of production features with production-shaped architecture.

Recommended Week 3 tasks:

- Add production configuration structure.
- Add `IFileStorageService`.
- Add `LocalFileStorageService`.
- Add `SharePointFileStorageService` placeholder.
- Add `DocumentAttachment` model.
- Add local Document Library page.
- Add file upload/list/download locally.
- Add role/permission models and services.
- Add Permission Matrix page.
- Add Microsoft Lists schema registry.
- Add M365 Readiness / Production Readiness page.
- Add mock/dry-run sync service.
- Add notification rules and local notification preview/log.

Outcome:

The app still runs locally, but the shape of the production system is already in place.

---

### Phase 3 — Production Database

Goal: move from local SQLite/demo data to production-capable storage.

Options:

- SQL Server
- Azure SQL
- PostgreSQL
- Another approved hosted database

Tasks:

- Add EF Core migrations.
- Add environment-specific connection strings.
- Add production seed/reference data strategy.
- Add backup and restore procedures.
- Add data migration approach.
- Confirm indexes for report/search pages.

Outcome:

The system can store real business workflow data safely.

---

### Phase 4 — Authentication and Roles

Goal: ensure users only see and edit what they are allowed to.

Possible approaches:

- Microsoft Entra ID
- ASP.NET Core Identity
- Another approved identity provider

Roles:

- Administrator
- Manager
- Safety / Compliance Reviewer
- Action Owner
- Document Processor
- Viewer

Tasks:

- Add sign-in.
- Add user identity to created/updated records.
- Add page/action permissions.
- Restrict admin settings.
- Restrict exports.
- Restrict sensitive record areas.
- Add role review documentation.

Outcome:

A production user model with accountability and least-privilege access.

---

### Phase 5 — Audit and Traceability

Goal: strengthen activity logging for production accountability.

Current prototype:

- Global Activity Log.
- Per-record Activity History.
- Created/updated/reviewed-style events.

Production additions:

- Authenticated user IDs.
- Before/after values.
- Field-level changes.
- Export history.
- Admin setting changes.
- Role changes.
- Login/security events where appropriate.
- Retention rules.

Outcome:

Managers and auditors can see who changed what, when, and why.

---

### Phase 6 — Document and Microsoft 365 Integration

Goal: connect workflow records to the business tools people already use.

Potential integrations:

- SharePoint document libraries.
- Microsoft Lists.
- Teams notifications.
- Outlook reminders/emails.
- Excel/Power BI-ready exports.
- APIs for job/accounting/ERP systems.

Recommended order:

1. Local file/document foundation.
2. SharePoint document library provider.
3. Microsoft Lists schema creation/sync.
4. Teams/Outlook notifications.
5. Authentication/roles.
6. API or scheduled sync.
7. Two-way integration only after workflow rules are stable.

Outcome:

OperationsFlow becomes an internal workflow hub rather than another isolated system.

---

### Phase 7 — Testing and Deployment

Goal: make releases repeatable and safe.

Testing additions:

- Unit tests for business rules.
- Integration tests for database reads/writes.
- UI smoke tests for important pages.
- Role/security tests.
- Export tests.
- Data quality rule tests.
- Migration tests.

Deployment additions:

- Build pipeline.
- Staging environment.
- Production environment.
- Release notes.
- Rollback plan.
- Monitoring.
- Logging.
- Support process.

Outcome:

The system can be updated safely without breaking core workflows.

---

## Low-Risk First Production Pilot

The safest first production pilot would be one workflow area, not the full system.

Recommended pilot:

**Safety / Compliance Follow-Up**

Why:

- It has clear business value.
- Records are easy to understand.
- Corrective actions, risks, training, documents, reminders, workload, reports, and data quality all support the same review process.
- It can be tested with a small user group before wider rollout.

Pilot scope:

- Corrective Actions
- Safety Meeting Pack
- Risk Register
- Training Compliance
- Controlled Documents
- Reminder Centre
- Workload
- Reports
- Data Quality
- Activity Log

Pilot users:

- 1 manager
- 1 safety/compliance reviewer
- 1 admin/document processor
- 2–5 action owners

Pilot review cadence:

- Weekly safety/compliance review.
- Weekly workload review.
- Monthly management report.

---

## Production Risks and Controls

| Risk | Example Problem | Control |
|---|---|---|
| Data loss | Records deleted or corrupted | Backups and restore tests |
| Bad release | Navigation, saving, or reporting breaks | Test/staging/release checks |
| Unauthorised access | Users see records they should not see | Authentication and role permissions |
| Notification noise | Too many reminders are sent | Confirm owner/status/due-date rules first |
| Bad data | Missing owners or weak notes distort reports | Data quality checks and validation |
| Failed sync | Integration silently fails | Logging, retries, and support ownership |
| Poor adoption | Users do not trust the system | Small pilot, training, and phased rollout |

---

## Enterprise Upgrade Summary

OperationsFlow should not jump straight from prototype to full ERP replacement.

The best path is:

1. Polish the prototype.
2. Add production foundation services locally.
3. Move to production storage.
4. Add authentication and roles.
5. Strengthen audit logging.
6. Add Microsoft 365 integrations.
7. Add tests, deployment, monitoring, and support.
8. Pilot with one workflow before expanding.

This keeps the project realistic and low-risk while preserving the value already demonstrated in the prototype.
