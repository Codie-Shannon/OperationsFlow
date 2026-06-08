# OperationsFlow Enterprise Upgrade Plan

## Purpose

This document explains how OperationsFlow can move from the completed local Week 3 production foundation into a Microsoft 365-connected internal business workflow pilot.

## Current Week 3 State

Implemented locally:

- Blazor/.NET 8 app.
- EF Core persistence.
- SQLite/local development support.
- SQL Server / LocalDB production foundation support.
- Local SQL-backed login.
- Local users, roles, and permissions.
- Protected navigation.
- Permission-controlled workflow actions.
- Local file storage abstraction.
- DocumentAttachment metadata.
- Local Document Library.
- Record-level attachments.
- Evidence-aware Data Quality.
- Evidence coverage Reports.
- Activity Log traceability.

Week 3 is no longer just planning. It is a working local version of the production-shaped system.

## Target Production State

A production/pilot version would include:

- hosted application environment
- approved production database
- Microsoft Entra ID authentication
- local/approved app role mapping
- SharePoint document library storage
- Graph API file operations
- tenant-specific admin settings
- backup/retention/monitoring
- formal security review
- approved reporting and audit rules

## Upgrade Phases

### Phase 1 — Completed Local Prototype

Completed:

- workflow pages
- management pages
- data quality
- reports
- activity traceability
- shared UI cleanup

### Phase 2 — Completed Week 3 Production Foundation

Completed:

- local SQL auth
- roles/permissions
- local session behaviour
- file storage abstraction
- document/evidence metadata
- local document library
- permission enforcement

### Phase 3 — Microsoft 365 Tenant Setup

Next:

- confirm Microsoft 365 admin access
- create test users/groups
- create SharePoint site
- create document library
- define folders/metadata
- create Entra app registration
- set redirect URLs
- configure Graph permissions
- record tenant/app/site/library IDs securely outside public repo

### Phase 4 — Microsoft Identity Integration

Add:

- OAuth2 sign-in
- Microsoft account claim capture
- ExternalLoginLink mapping to LocalUser
- local role/permission enforcement stays as authorisation source
- login/logout/session updates
- configured/not-configured admin states

### Phase 5 — SharePoint File Storage Provider

Add:

- Graph client/configuration
- SharePoint upload
- SharePoint open/download links
- soft-delete/archive strategy
- metadata mapping to existing DocumentAttachment model
- provider switching between Local and SharePoint

### Phase 6 — Pilot Hardening

Add:

- setup guide
- deployment notes
- test plan
- screenshots
- known limitations
- backup/retention recommendations
- security review checklist

### Phase 7 — Optional Integrations

Later:

- Power Automate notifications
- Planner/Teams task handoff
- Outlook mailbox intake
- Power BI reporting
- Xero/Cin7/WorkflowMax connector research

## Low-Risk First Production Pilot

A sensible pilot should use:

- one test site
- limited users
- non-sensitive demo/pilot data
- clear permission groups
- SharePoint evidence library
- local SQL/app database
- manager review before expanding

## Production Risks and Controls

| Risk | Impact | Control |
|---|---|---|
| Incorrect access | Users see or change records they should not | Entra auth + role/permission checks |
| Lost files | Evidence unavailable | SharePoint library + retention/backup |
| Weak audit | Changes cannot be reviewed | Activity Log + authenticated user identity |
| Poor data quality | Reports become unreliable | Data Quality checks + required fields |
| Over-automation | Human decision points removed too early | Human-in-the-loop stages |
| Tenant misconfiguration | Login/storage fails | Admin configuration checklist |

## Enterprise Upgrade Summary

OperationsFlow already has the local shape of a production internal workflow system. The next enterprise step is connecting approved Microsoft 365 identity and SharePoint file storage to the existing local workflow foundation.
