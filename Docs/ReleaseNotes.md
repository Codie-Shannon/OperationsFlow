# OperationsFlow Release Notes

## Week 3 Production Foundation and Permission Enforcement

### Summary

Week 3 moves OperationsFlow from a polished local workflow prototype into a local production-foundation pilot. The system now includes local SQL-backed authentication, users, roles, permissions, document/evidence handling, storage abstraction, record attachments, evidence-aware reporting, and ReadOnly/Admin permission testing.

### Completed

#### Production Configuration

- Added production-style options/configuration.
- Added storage/Microsoft 365/notification boundaries.
- Added local vs future-provider separation.

#### Storage and Evidence

- Added file storage abstraction.
- Added local file storage provider.
- Added SharePoint provider placeholder.
- Added `DocumentAttachment` metadata model/service.
- Added local Document Library.
- Added record-level attachments.
- Added file counts on workflow registers.
- Added upload/delete activity logging.

#### Data Quality and Reports

- Added missing evidence checks.
- Added evidence coverage report.
- Added missing evidence report.
- Updated Data Quality and Reports for Week 3 evidence workflows.

#### Local SQL Authentication

- Added SQL Server / LocalDB support.
- Added local users, roles, and permissions.
- Added local login page.
- Added logout/session controls.
- Added sessionStorage persistence.
- Added protected navigation.
- Added sidebar user/role display.

#### Permission Enforcement

- Fixed ReadOnly viewer access issue.
- Wrapped create/edit workflow actions with `CanEditWorkflow`.
- Wrapped upload evidence actions with `CanUploadEvidence`.
- Wrapped delete/soft-delete evidence actions with `CanDeleteEvidence`.
- Wrapped CSV/export links with `CanExportData`.
- Wrapped settings/user management boundaries with admin permissions.
- Tested Admin and ReadOnly roles.

### Manual Testing

Tested as Admin:

- workflow create/edit actions visible
- evidence upload/delete actions visible where allowed
- export actions visible where allowed
- admin/user pages available

Tested as ReadOnly:

- can view dashboard/register/detail/report/review pages
- cannot see new/create links
- cannot see edit links/buttons
- cannot upload evidence
- cannot delete evidence
- cannot export CSV
- cannot manage settings/users

### Current Status

Week 3 Production Foundation is complete and ready for final screenshot/documentation pass.

### Known Warning

Build may show an existing nullable warning in `DocumentAttachmentService.cs`; the build still succeeds. This can be cleaned up separately if desired.

### Next Stage

Week 4: Microsoft 365 production implementation.

Planned:

- tenant setup confirmation
- Entra app registration
- OAuth2 sign-in
- external login linking
- SharePoint site/document library
- Graph file upload/open/delete
- production setup guide
- Week 4 screenshots and release notes
