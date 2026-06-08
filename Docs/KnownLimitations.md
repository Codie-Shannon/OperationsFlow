# Known Limitations

OperationsFlow is a working portfolio/pilot implementation, not a fully hardened enterprise SaaS system.

## Current limitations

- The app is not deployed to a hosted production environment yet.
- Development secrets must not be committed and should be moved to user-secrets, environment variables, or a managed secret store.
- Any exposed development client secret should be rotated before final publishing or further sharing.
- Graph permissions should be reviewed and narrowed where practical before real production rollout.
- There is no formal production backup/restore policy yet.
- There is no formal retention or legal hold policy yet.
- Monitoring, alerting, and centralized error logging are not yet implemented.
- Automated test coverage is not yet implemented.
- Microsoft account linking is pilot-level and should be expanded with admin UI for linking/unlinking accounts.
- The current pilot is single-tenant and not a multi-tenant SaaS product.
- External integrations such as Outlook shared mailbox intake, Teams, Planner, Power BI, Xero, Cin7, or WorkflowMax are not connected yet.

## What is implemented

- Local SQL auth and roles.
- Microsoft OAuth2 sign-in.
- Microsoft account to local user mapping.
- SharePoint evidence upload.
- SharePoint metadata writeback.
- SharePoint delete lifecycle.
- Current-user activity logging.
- ReadOnly permission enforcement.
- Reports and data quality pages.

## Honest positioning

Production pilot-ready for a single-tenant Microsoft 365 environment.
