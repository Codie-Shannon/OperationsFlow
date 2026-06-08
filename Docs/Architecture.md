# Architecture

OperationsFlow is a Blazor/.NET 8 workflow system with a local SQL production foundation and a Microsoft 365 pilot integration.

## High-level architecture

```text
Blazor UI
  -> Shared UI components
  -> Login / Microsoft OAuth2 pages
  -> LocalRouteGuard
  -> LocalSessionStorageService
  -> LocalCurrentUserService
  -> LocalAuthService
  -> LocalIdentityService
  -> EF Core / OperationsFlowDbContext
  -> SQL Server LocalDB or SQLite
  -> DocumentAttachmentService
  -> IFileStorageService
       -> LocalFileStorageService
       -> SharePointFileStorageService
            -> Azure.Identity
            -> Microsoft Graph
            -> SharePoint Evidence Library
```

## Identity and authorization

OperationsFlow separates identity from authorization:

- **Local login** authenticates against SQL-backed users and hashed passwords.
- **Microsoft OAuth2 login** authenticates against the Microsoft tenant.
- **ExternalLoginLinks** maps Microsoft identity to a local OperationsFlow user.
- **Local SQL roles/permissions** still decide what the user can do inside the app.

This allows the app to prove Microsoft 365 identity while preserving application-specific permissions such as upload, delete, export, manage users, and manage settings.

## Storage architecture

File storage is provider-based:

- `IFileStorageService`
- `LocalFileStorageService`
- `SharePointFileStorageService`

The workflow pages do not need to know whether files are local or SharePoint-backed. The provider handles upload/delete and returns a storage result that is saved into `DocumentAttachment` records.

## SharePoint evidence model

SharePoint stores the physical evidence file. SQL stores the workflow metadata and reporting links.

SharePoint writeback includes:

- module
- record id
- record reference
- evidence flag
- controlled document flag
- uploaded by display name
- notes

## Audit model

Activity Log records upload/delete/workflow events and now uses the current signed-in user for real document lifecycle actions.

## Deployment boundary

This is a local/pilot architecture. Real production deployment would require formal hosting, secret management, backup/restore, monitoring, retention policy, and least-privilege permission review.
