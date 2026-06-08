# OperationsFlow Known Limitations

## Prototype Status

OperationsFlow is a local production-foundation prototype. It is suitable for portfolio review, manager review, and Week 4 Microsoft 365 pilot configuration planning. It is not yet a hosted/live production deployment.

## Current Technical Limitations

### Not Hosted Yet

The app currently runs locally. A production version would need hosting, deployment process, environment configuration, monitoring, backups, and support procedures.

### Microsoft 365 Not Connected Yet

A Microsoft 365 tenant is available for Week 4 setup, but the application is not yet connected to:

- Microsoft Entra OAuth2 login
- Microsoft Graph
- SharePoint document libraries
- Teams
- Planner
- Outlook mailbox intake
- Power Automate
- Power BI service

### Local Authentication Is Not Production Identity

Week 3 local SQL-backed authentication is implemented and tested, including local roles and action permissions.

Remaining production identity work:

- Entra ID / OAuth2 sign-in
- external login mapping
- token handling
- tenant/app registration config
- secure secret/certificate handling
- production sign-in/logout testing

### Role Permissions Are Local App Permissions

Week 3 app permissions are enforced in the UI/actions and are suitable for local pilot demonstration. Production would also need:

- server-side/policy-level enforcement review
- authenticated identity claims
- security testing
- audit rules
- tenant group mapping if used

### File Storage Is Local

Week 3 stores files locally through the file storage abstraction. It stores file metadata in `DocumentAttachment` records.

Remaining production file work:

- SharePoint document library setup
- Graph upload/open/delete
- file permission model
- retention rules
- folder/metadata conventions

### No Live Xero / Cin7 / WorkflowMax Integration Yet

OperationsFlow currently models workflow pressure and integration direction. It does not yet connect to Xero, Cin7, WorkflowMax, or other external business systems.

### No Production Reporting Platform Yet

Reports and CSV exports are implemented locally. Production reporting could later use Power BI, scheduled exports, or approved management dashboards.

### No Automated Test Suite Yet

Manual testing has been done, including Admin and ReadOnly permission behaviour. Automated unit/integration/UI tests are still future work.

### Seeded / Demo Data

The app uses demo records for portfolio and testing purposes. Production would require approved data migration/import rules.

### Some Options Are Still Hardcoded

Some dropdowns/status lists/options are currently code-defined. Production would likely move more configuration into admin tables/settings.

### Admin Settings Is a Configuration Boundary

Admin Settings explains and previews production configuration. It is not yet a full production admin console for tenant secrets, Graph permissions, or deployment settings.

## Business Scope Limitations

### Not a Full ERP System

OperationsFlow is focused on workflow follow-up, evidence, reporting, and management visibility. It is not a full ERP, accounting, CRM, or manufacturing system.

### Not a Certified Compliance System

It can support compliance workflows, but a production safety/compliance system would need business validation, legal/process sign-off, security review, and approved retention/audit policies.

## Limitation Summary

OperationsFlow now proves the workflow, evidence, reporting, role-permission, and production architecture shape. The remaining limitations are mostly production integration, hosting, identity, SharePoint/Graph storage, automated testing, and formal security/governance work.
