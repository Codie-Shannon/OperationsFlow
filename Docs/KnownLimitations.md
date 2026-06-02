# Known Limitations

OperationsFlow is currently a portfolio/semi-live prototype. It is designed to demonstrate business workflow thinking, Blazor/.NET development, SQLite persistence, reporting, exports, activity history, reminders, workload, and enterprise direction.

It is not yet a production enterprise deployment.

## Current Technical Limitations

- Uses local SQLite rather than SQL Server, PostgreSQL, or Azure SQL.
- Uses demo seed data.
- Database schema changes are handled in prototype mode.
- EF Core migrations are not fully implemented yet.
- No automated test suite yet.
- No production logging/error monitoring.
- No hosted deployment pipeline.

## Security / User Limitations

- No authentication.
- No user accounts.
- No role-based permissions.
- No Microsoft Entra ID / Azure AD integration.
- Current `CreatedBy` values are demo-style rather than real authenticated users.

## Integration Limitations

No live integrations yet with:

- SharePoint
- Outlook
- Teams
- Xero
- Cin7
- WorkflowMax
- Power BI
- Azure Blob Storage

The current CSV export and Document Intake workflows are designed to demonstrate the direction before live integration work.

## Admin Settings Limitations

- Admin Settings is currently a starter/configuration overview page.
- Some dropdown values are still hardcoded in forms.
- Settings are not yet fully database-driven.
- Settings are not yet editable through the UI.

## Document Intake Limitations

- No real file upload/storage yet.
- No automatic email/PDF intake yet.
- No OCR or AI extraction yet.
- No SharePoint document library connection yet.
- Document records track workflow metadata, not actual file content.

## Reporting Limitations

- Reports are app-based prototype reports.
- No Power BI embedding yet.
- CSV export is available, but scheduled reporting and automated distribution are not implemented.

## Production Upgrade Path

To become production-ready, OperationsFlow would need:

- Production database.
- EF Core migrations.
- Authentication.
- Role permissions.
- Database-driven admin settings.
- Proper audit trail.
- Error handling/logging.
- Tests.
- Deployment pipeline.
- Real integrations.
- File storage and document security.
