# Release Notes

## Week 4 Microsoft 365 Pilot Implementation

OperationsFlow now has a working single-tenant Microsoft 365 pilot path.

### Completed

- Microsoft 365 configuration foundation.
- Microsoft Graph connection test.
- SharePoint site and document library resolution.
- SharePoint-backed evidence upload provider.
- Folder mapping by module and record reference.
- SharePoint metadata writeback:
  - OperationsFlowModule
  - OperationsFlowRecordId
  - OperationsFlowRecordRef
  - IsEvidence
  - IsControlledDocument
  - UploadedByDisplayName
  - OperationsFlowNotes
- SharePoint delete lifecycle from OperationsFlow.
- Document Library direct upload parity with record-level upload.
- Current-user upload/delete activity logging.
- Microsoft OAuth2 sign-in.
- Microsoft tenant account to local OperationsFlow user mapping.
- Local SQL roles/permissions retained as the authorization source.
- Sidebar status showing Local login vs Microsoft-linked.
- Updated screenshots and documentation.

### Positioning

OperationsFlow is now production pilot-ready for a single-tenant Microsoft 365 environment. It is not yet a fully hardened enterprise SaaS platform.

### Remaining hardening

- Rotate any exposed development client secrets.
- Move secrets to user-secrets, environment variables, or a managed secret store.
- Review Graph permissions and reduce where practical.
- Add hosted deployment, backup/restore, monitoring, and retention policy.
- Add formal automated test coverage.
