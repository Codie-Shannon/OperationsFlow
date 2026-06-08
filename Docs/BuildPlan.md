# OperationsFlow Build Plan

## Current Build State

Current branch/state at the end of Week 3:

```text
Week 3 Production Foundation: complete after permission enforcement
Next stage: Week 4 Microsoft 365 production implementation
```

Completed Week 3 work includes local SQL authentication, roles/permissions, session login/logout, file storage abstraction, local document library, attachments, evidence checks, reports, and permission-controlled workflow actions.

## Completed Week 3 Blocks

### Block 1 — Production Configuration Foundation

- Added production-style options/configuration.
- Added local/demo feature switches.
- Added Microsoft 365, storage, notification, and operations options.

### Block 2 — File Storage Abstraction

- Added `IFileStorageService`.
- Added local file provider.
- Added SharePoint provider placeholder for Week 4.

### Block 3 — DocumentAttachment Model/Service

- Added file metadata model.
- Added attachment service.
- Added schema safety for local demo state.

### Block 4 — Document Library

- Added local document library page.
- Added upload/list/open/download/soft-delete behaviour.
- Added activity logging for upload/delete.

### Block 5 — Record Attachments

- Added reusable `RecordAttachments` component.
- Connected attachments to Work Orders and Corrective Actions.

### Block 6 — Document Intake Details

- Added document intake details route.
- Connected Document Intake to attachments and file counts.

### Block 7 — Evidence-Aware Data Quality and Reports

- Added missing-evidence checks.
- Added evidence coverage reporting.
- Updated reviewer/business pages for evidence workflows.

### Block 8 — SharePoint Readiness Documentation

- Explained local provider, metadata model, and Week 4 SharePoint path.

### Block 9 — Local SQL Authentication and Roles

- Added SQL Server / LocalDB support.
- Added local SQL users, roles, permissions.
- Added login/logout/session behaviour.
- Added protected navigation and sidebar user status.

### Block 10 — Permission Enforcement and Final Week 3 Sign-Off

- Fixed ReadOnly viewer bug.
- Wrapped create/edit workflow actions with workflow edit permission.
- Wrapped upload actions with upload evidence permission.
- Wrapped delete actions with delete evidence permission.
- Wrapped CSV/export links with export permission.
- Wrapped admin/user actions with settings/user management permissions.
- Tested Admin and ReadOnly behaviour.

## Current Test Requirement

Before creating the Week 4 branch, confirm:

```text
Admin can create/edit/upload/delete/export/administer.
ReadOnly can view but cannot create/edit/upload/delete/export/administer.
```

## Recommended Branch Workflow

After final Week 3 commit:

```bash
git checkout week3-production-foundation
git pull
git status
```

Optional backup:

```bash
git branch backup/week3-production-foundation-complete
git push origin backup/week3-production-foundation-complete
```

Create Week 4 branch:

```bash
git checkout -b week4-production-implementation
git push -u origin week4-production-implementation
```

## Week 4 Build Goal

Week 4 is the full Microsoft 365 production implementation path.

It should connect the existing Week 3 system to:

- Microsoft 365 tenant
- Entra app registration
- OAuth2 sign-in
- external login linking
- SharePoint site/document library
- Microsoft Graph file upload/open/delete
- configured/not-configured admin states
- production pilot documentation

## Week 4 Build Order

1. Confirm tenant/admin access.
2. Create test users and groups.
3. Create SharePoint site/document library.
4. Create Entra app registration.
5. Set redirect URLs.
6. Add Graph permissions.
7. Add Microsoft auth options/configuration.
8. Implement OAuth2 sign-in.
9. Link external Microsoft accounts to local users.
10. Implement SharePoint file storage provider.
11. Test upload/open/delete through SharePoint.
12. Update Admin Settings, docs, screenshots, and release notes.

## Current Build Summary

Week 3 proves the local internal business system foundation. Week 4 should connect Microsoft 365 services into that foundation without rebuilding the app structure.
