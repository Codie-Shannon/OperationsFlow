# OperationsFlow Architecture

## Overview

OperationsFlow is a Blazor/.NET 8 internal workflow system prototype with a completed Week 3 production foundation. It demonstrates practical workflow capture, management reporting, evidence handling, local SQL authentication, role/action permissions, data quality checks, and a Microsoft 365 / SharePoint-ready storage and identity path.

The project is intentionally honest about scope. It is a working local pilot/prototype with production-shaped architecture. It is not yet a hosted production deployment.

## Current Implemented Architecture

```text
Blazor UI
  -> Shared UI components
  -> Workflow pages
  -> Local authentication and session services
  -> Local current user/permission service
  -> EF Core services
  -> SQLite or SQL Server/LocalDB
  -> Workflow tables
  -> LocalUser / LocalRole / LocalPermission / LocalRolePermission
  -> DocumentAttachment metadata
  -> IFileStorageService
      -> LocalFileStorageService
      -> SharePointFileStorageService placeholder
```

## Core Architectural Decisions

- Keep workflow pages provider-independent.
- Store workflow records locally through EF Core.
- Store user/role/permission state in local SQL.
- Use a current-user service to expose permission flags to pages/components.
- Use a storage interface so local files can be replaced with SharePoint storage in Week 4.
- Store attachment metadata separately from physical files.
- Use Activity Log as the visible traceability layer.
- Keep Microsoft 365 integration as the Week 4 provider/identity layer rather than rebuilding the UI.

## Authentication and Permissions

Week 3 implements local SQL-backed authentication.

Implemented:

- login page as app landing page
- logout page/control
- local session persistence using browser `sessionStorage`
- protected routes/navigation
- sidebar signed-in user card
- local users, roles, and permissions
- permission helper properties such as workflow edit, upload evidence, delete evidence, export data, manage settings, and manage users
- ReadOnly view-only enforcement across key pages
- Admin action testing

Current authorisation boundary:

```text
LocalUser -> LocalRole -> LocalRolePermission -> LocalPermission
```

ReadOnly users can view pages, reports, data quality, and activity information, but cannot create, edit, upload, delete, export, or manage users/settings.

## Data Storage

Supported/implemented local development storage:

- SQLite for simple local demo/development scenarios.
- SQL Server / LocalDB for the local auth and production foundation path.

Future production targets:

- SQL Server
- Azure SQL
- PostgreSQL if required by hosting/environment

## File and Evidence Storage

Current Week 3 provider:

```text
LocalFileStorageService -> wwwroot/uploads or configured local upload path
```

Metadata is stored in `DocumentAttachment` records:

- module name
- record id/reference
- original file name
- stored file name/path
- public/open URL
- content type
- file size
- storage provider
- uploaded by/date
- notes
- evidence flag
- controlled document flag
- soft delete fields

Week 4 provider:

```text
SharePointFileStorageService -> Microsoft Graph -> SharePoint document library
```

The page/component workflow should stay the same while the provider changes.

## Activity Logging Flow

```text
Create/edit/upload/delete/review action
  -> service/page writes ActivityLog record
  -> record detail pages show local history
  -> Activity Log page shows global traceability
  -> Reports/Data Quality can reference review/evidence state
```

Production audit work would add immutable rules, identity claims, retention policy, and potentially Microsoft 365 audit/history mapping.

## Shared UI Architecture

The app uses a shared UI component system to keep pages consistent:

- PageHero
- PurposeNote
- MetricGrid
- MetricCard
- InfoPanel
- TableCard
- FilterBar
- EmptyState
- GuidanceNote
- ActionStrip
- ActivityHistoryPanel
- RecordAttachments

This reduces repeated markup and keeps future Week 4 pages visually consistent.

## Current Main Modules

- Dashboard
- Work Orders
- Corrective Actions
- Document Intake
- Document Library
- Risk Register
- Training Compliance
- Document Control
- Reminders
- Workload
- Reports
- Data Quality
- Activity Log
- User Roles
- Admin Settings
- Reviewer/Business/Technical overview pages

## Week 4 Production Architecture

Week 4 should add live Microsoft 365 providers and configuration:

```text
Microsoft Entra ID / OAuth2
  -> external identity claim
  -> ExternalLoginLink
  -> LocalUser
  -> Local SQL roles/permissions

SharePoint / Graph
  -> SharePoint document library
  -> upload/open/delete file operations
  -> DocumentAttachment metadata still stored in OperationsFlow
```

The design goal is to replace/extend providers, not rewrite the workflow pages.

## Architecture Summary

OperationsFlow now proves both the workflow concept and the local production foundation. It is ready for Week 4 Microsoft 365 tenant configuration, OAuth2 sign-in, SharePoint document storage, and pilot deployment preparation.
