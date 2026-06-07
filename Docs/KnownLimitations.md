# OperationsFlow Known Limitations

This document lists the current known limitations of OperationsFlow and explains which limitations are intentional prototype boundaries versus future production upgrades.

---

## Prototype Status

OperationsFlow is currently a local portfolio prototype.

It is designed to demonstrate:

- Workflow design.
- C#/Blazor development.
- CRUD screens.
- SQLite persistence.
- Reporting.
- CSV exports.
- Reminders and workload visibility.
- Data quality checks.
- Activity traceability.
- Shared UI component refactoring.
- Reviewer support pages.
- Production planning.
- Microsoft 365 integration direction.

It is not currently intended to be used as a live production ERP or enterprise system.

---

## Current Technical Limitations

### Local Database Only

Current state:

- Uses SQLite.
- Stores demo data locally.
- Suitable for prototype/demo use.

Production requirement:

- SQL Server, Azure SQL, PostgreSQL, or another approved hosted database.
- EF Core migrations.
- Backups.
- Restore process.
- Access control.

---

### Seeded Demo Data

Current state:

- Uses seeded sample records.
- Data is realistic enough for review but not connected to a real company dataset.

Production requirement:

- Real user-created records.
- Migration/import process.
- Data ownership rules.
- Validation and cleanup.

---

### No Authentication Yet

Current state:

- The app does not currently require sign-in.
- User names are demo text, not authenticated identities.

Production requirement:

- Microsoft Entra ID, ASP.NET Core Identity, or another approved identity provider.
- Authenticated user ID on created/updated/reviewed records.
- Role-specific access.

---

### No Role-Based Permissions Yet

Current state:

- The User Roles page explains the future production access model.
- Roles are not enforced yet in the app.

Production requirement:

- Admin role.
- Manager role.
- Safety/compliance reviewer role.
- Action owner role.
- Document processor role.
- Read-only viewer role.
- Page/action restrictions.
- Export restrictions.

Week 3 should add local role/permission foundations before Week 4 production mapping.

---

### No Hosted Deployment Yet

Current state:

- Runs locally.
- Suitable for portfolio review.

Production requirement:

- Hosted app environment.
- Separate development/test/production environments.
- Environment-specific configuration.
- Logging.
- Monitoring.
- Release/rollback process.

---

### No Live Microsoft 365 Integration Yet

Current state:

- Integration Overview explains the path.
- No live SharePoint, Teams, Outlook, Microsoft Lists, or Power BI connection currently exists.

Production requirement:

- SharePoint document links/storage.
- Teams notifications.
- Outlook reminders/emails.
- Microsoft Lists/API sync where useful.
- Excel/Power BI-ready reporting feed.
- Integration error handling.

Week 3 should add schema/dry-run services. Week 4 should connect the live Microsoft 365 implementation.

---

### No Live Xero / Cin7 / WorkflowMax Integration Yet

Current state:

- Document Intake tracks target systems as workflow metadata.
- Target system values are used to show where a document/admin item should end up.

Production requirement:

- Confirm source of truth.
- Use APIs only after business rules are stable.
- Add retry/error logging.
- Avoid unsafe two-way sync until required.

---

### No Production File Storage Yet

Current state:

- Controlled documents and document intake records store metadata.
- The current app does not store/upload real files yet.

Production requirement:

- Local file/document library foundation.
- SharePoint or controlled storage.
- File permissions.
- File links.
- Version/review history.
- Attachments/evidence.

Week 3 should build local file storage and attachment metadata. Week 4 should connect SharePoint document library storage.

---

### No Automated Test Suite Yet

Current state:

- Manual testing is used.
- Testing Overview explains manual and production test requirements.

Production requirement:

- Unit tests.
- Integration tests.
- UI smoke tests.
- Role/security tests.
- Export tests.
- Migration tests.
- CI/CD pipeline checks.

---

### Styling Is Consolidated, Not Fully Modular

Current state:

- The CSS was cleaned and reduced after the Week 2 shared UI refactor.
- The app now uses a more consistent shared styling system.
- CSS is still largely in `wwwroot/app.css`.

Future maintainability option:

- Split CSS into smaller files if the app continues to grow.
- Keep shared design tokens and `of-*` component classes.
- Avoid page-specific duplication.

This is no longer a blocker for the Week 2 review package.

---

### Some Form Options Are Still Hardcoded

Current state:

- Several dropdown options are defined in pages/forms.
- This is acceptable for prototype speed.

Production requirement:

- Database-driven reference lists.
- Admin-managed settings.
- Audit changes to settings/options.
- Role-restricted admin pages.

---

### Admin Settings Is a Starter Page

Current state:

- Admin Settings demonstrates the direction for configurable departments, sites, priorities, statuses, and system options.
- It is not a full production admin console yet.

Production requirement:

- Persist settings in the database.
- Add create/edit/delete settings.
- Add validation.
- Add permissions.
- Add audit logging.

---

## Business Scope Limitations

### Not a Full ERP System

OperationsFlow is not currently a full ERP. It does not include:

- Accounting.
- Inventory.
- Payroll.
- Purchasing.
- Sales orders.
- Manufacturing planning.
- Asset depreciation.
- Customer relationship management.
- Full document management.
- Full HR/training management.

It is best described as an operational follow-up and business workflow prototype.

---

### Not a Production Safety Compliance System Yet

OperationsFlow demonstrates safety/compliance follow-up workflows.

It does not currently replace:

- Certified safety management systems.
- Legal compliance registers.
- Formal audit systems.
- Regulated document control systems.

A production version would need validation, permissions, audit controls, backups, and business sign-off.

---

## What These Limitations Mean

These limitations are not failures of the project. They show honest prototype scope.

The current version proves:

- The workflow model.
- The UI structure.
- The record model.
- The reporting approach.
- The activity traceability concept.
- The data quality concept.
- The shared UI/system cleanup.
- The production upgrade path.

The next version should focus on production foundations.

---

## Limitation Summary

OperationsFlow is ready to be reviewed as a portfolio prototype. It should not be presented as a finished production ERP or live business system.

Best wording:

> OperationsFlow is a working Blazor/.NET business workflow prototype. It demonstrates the structure, workflows, reporting, traceability, UI consistency, and production planning needed for an internal operations/compliance follow-up system. A production rollout would require authentication, role permissions, hosted database storage, backups, testing, deployment, monitoring, file/document storage, and live integrations.
