# OperationsFlow Demo Walkthrough

## Demo Goal

Show that OperationsFlow is a practical internal workflow system, not just a static dashboard. The demo should prove workflow capture, evidence handling, reporting, data quality, activity traceability, and local role-permission enforcement.

## Short No-Speaking Demo Path

1. Login page.
2. Dashboard signed in as Admin.
3. Work Orders list.
4. Work Order details with attachments.
5. Corrective Actions list.
6. Document Intake details with attachments.
7. Document Library.
8. Data Quality missing evidence.
9. Reports evidence coverage.
10. User Roles permission matrix.
11. ReadOnly view-only test screenshot.
12. Integration Overview / Implementation Plan for Week 4.

## Short Live Demo Path

### 1. Login

Show local SQL-backed login and explain that Week 3 uses local users/roles while Week 4 will link Microsoft OAuth2 identities.

### 2. Dashboard

Show the signed-in state and local SQL-backed business workflow status.

### 3. Work Orders

Show operational records, status, due date, file count, details link, and Admin create/edit actions.

### 4. ReadOnly Test

Login as ReadOnly and show:

- can view Work Orders
- cannot see `+ New Work Order`
- cannot see Edit links
- cannot upload/delete evidence
- cannot export CSV

### 5. Corrective Actions

Show owned actions and source-linked follow-up thinking.

### 6. Risk / Training / Documents

Show Create Action links as source-linked workflow entry points for permitted users.

### 7. Document Intake

Show incoming document processing records and detail page.

### 8. Record Attachments

Show how Work Orders, Corrective Actions, and Document Intake can have linked evidence files.

### 9. Document Library

Show cross-module file review, metadata, provider, and soft-delete boundary. Explain that local storage swaps to SharePoint in Week 4.

### 10. Data Quality

Show missing evidence rows and data quality checks.

### 11. Reports

Show management action rows, evidence coverage, and missing evidence report. Export links should only appear for users with export permission.

### 12. Activity Log

Show global traceability. Explain that production could map this to authenticated user identity and Microsoft 365 history/audit concepts.

### 13. User Roles

Show local SQL roles/permissions and explain ReadOnly/Admin behaviour.

### 14. Admin Settings

Show local/Week 3 configuration boundary and Week 4 Microsoft 365 configuration path.

### 15. Integration Overview / Implementation Plan

Show that Week 4 has a real path: tenant, Entra app registration, Graph permissions, SharePoint document library, OAuth2 login, and provider swap.

## Vanessa / OSHE Demo Path

Focus on:

1. Dashboard
2. Corrective Actions
3. Risk Register
4. Training
5. Documents
6. Document Intake
7. Data Quality
8. Reports
9. Activity Log
10. Evidence attachments

Message: workflow follow-up, compliance pressure, evidence, and management visibility.

## Lester / Peter Demo Path

Focus on:

1. Workflow capture
2. Document Intake
3. Human review/assignment points
4. Evidence/document library
5. Reports
6. Integration Overview
7. Implementation Plan
8. AI/M365 path as a staged improvement, not a replacement for human judgement

Message: understand the current process first, then identify where Microsoft 365, SharePoint, Power Automate, or AI-assisted steps may help.

## JV / Technical Demo Path

Focus on:

1. Local SQL-backed login
2. User Roles
3. Permission enforcement
4. EF Core data model
5. Workflows and CRUD
6. Attachment metadata
7. Local provider abstraction
8. Week 4 OAuth2 link path

Message: local SQL system now, Microsoft identity integration later.

## Demo Notes

Use honest wording:

```text
This is a local production-foundation prototype. Week 4 connects it to Microsoft 365 / SharePoint through tenant-specific configuration.
```

Avoid saying:

```text
Fully production deployed.
```

Use:

```text
Ready for manager review and production pilot configuration.
```
