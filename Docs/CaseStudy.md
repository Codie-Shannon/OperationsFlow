# Case Study

## Problem

Operational work often spreads across emails, documents, spreadsheets, Teams messages, SharePoint files, and informal follow-ups. That makes it hard to see ownership, missing evidence, overdue work, and compliance pressure.

## Solution

OperationsFlow centralizes key operational workflows:

- Work Orders
- Corrective Actions
- Document Intake
- Document Library
- Risk Register
- Training
- Reports
- Data Quality
- Activity Log

The Week 4 version adds Microsoft 365 integration so evidence can be stored in SharePoint while the app keeps local workflow metadata and permissions.

## Implementation path

### Week 3 foundation

Built the local production-shaped foundation: SQL-backed users, local roles, permissions, evidence records, reports, data quality, and local storage abstraction.

### Week 4 pilot

Connected the foundation to Microsoft 365:

- Microsoft OAuth2 sign-in.
- Microsoft account to local user mapping.
- Microsoft Graph connection.
- SharePoint evidence upload.
- Metadata writeback.
- Delete lifecycle.
- Current-user activity logging.

## Result

OperationsFlow now demonstrates a realistic internal business system with identity, authorization, evidence storage, workflow traceability, and review-ready reporting.

## Honest scope

This is production pilot-ready for a single-tenant Microsoft 365 environment. Full production rollout still needs hosting, formal security hardening, backup/restore, monitoring, and retention policies.
