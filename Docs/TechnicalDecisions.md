# OperationsFlow Technical Decisions

## Project Type

### Decision

Build OperationsFlow as a Blazor/.NET 8 application.

### Reason

Blazor fits the project because it supports C#, component-based UI, internal business app patterns, and a clean path from local prototype to hosted production application.

## Database

### Decision

Use EF Core with SQLite/local development support and SQL Server / LocalDB for Week 3 production foundation/auth.

### Reason

SQLite kept the early prototype fast and portable. SQL Server / LocalDB made the local auth/roles/permissions foundation more realistic for internal business systems.

### Trade-off

Production would still need an approved hosted database and deployment environment.

## Local Authentication and Roles

### Decision

Add local SQL-backed users, roles, permissions, login/logout, and sessionStorage login persistence in Week 3.

### Reason

This proves the app can handle role-based internal workflow behaviour before Microsoft OAuth2/Entra ID is connected.

### Trade-off

Local login is not the final production identity layer. Week 4 should add Microsoft OAuth2 and link external identities to local users.

## Permission Enforcement

### Decision

Use a current-user service with explicit permission flags for UI/action visibility.

### Reason

The app needs to demonstrate real role-based behaviour:

- ReadOnly can view only.
- Admin can manage everything.
- Manager/Reviewer/Worker have different operational boundaries.

### Trade-off

Production should also review server-side policy enforcement and security testing.

## File Storage

### Decision

Use `IFileStorageService` with a local provider now and SharePoint provider placeholder for Week 4.

### Reason

This allows the workflow to be built once and the provider swapped later.

### Trade-off

Local files are not production document management. Week 4 should connect SharePoint/Graph.

## Attachment Metadata

### Decision

Store file metadata in `DocumentAttachment` records rather than relying only on physical files.

### Reason

The app needs module/record relationships, evidence flags, controlled document flags, uploaded by/date, notes, provider, and soft-delete state.

## Activity Logging

### Decision

Log workflow and evidence events into Activity Log.

### Reason

Traceability is central to management review, testing evidence, and portfolio proof.

### Trade-off

Production audit logging would need authenticated identities, immutability, retention rules, and possibly Microsoft 365 audit integration.

## CSV Export

### Decision

Provide local CSV exports for review/reporting packs.

### Reason

CSV is simple, reviewable, and useful for Excel/Power BI-style workflows.

### Trade-off

Production reporting may require Power BI, scheduled refresh, export permissions, and approved KPI definitions.

## Shared UI Component System

### Decision

Refactor repeated layouts into shared components.

### Reason

This made the app more maintainable and consistent before adding Week 3/Week 4 production features.

## Microsoft 365 Integration Planning

### Decision

Build the local provider-independent system first, then connect Microsoft 365 in Week 4.

### Reason

This avoids rebuilding workflow pages after tenant setup and keeps the integration work focused on identity/storage providers.

### Future Direction

Week 4 should add:

- Entra app registration
- OAuth2 sign-in
- external login link mapping
- SharePoint document library provider
- Graph upload/open/delete operations
- tenant configuration documentation

## Testing Strategy

### Decision

Use manual role-based testing for Week 3 sign-off.

### Reason

The critical risk was visible action permissions for ReadOnly users. Manual testing confirmed Admin and ReadOnly behaviour across the app.

### Future Direction

Add automated tests later for services, permissions, components, and integration flows.

## Production Boundary

### Decision

Keep the documentation honest: Week 3 is local production foundation; Week 4 is Microsoft 365 pilot configuration/implementation.

### Reason

This is stronger and more credible than pretending a local prototype is fully production deployed.

## Technical Summary

OperationsFlow was built with practical internal systems decisions: Blazor for UI, EF Core for persistence, SQL-backed local auth, role permissions for action visibility, provider-based file storage, document/evidence metadata, activity logging, CSV exports, reusable components, and Microsoft 365 integration readiness.
