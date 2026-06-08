# Enterprise Upgrade Plan

OperationsFlow Week 4 is a working single-tenant Microsoft 365 pilot. This plan lists what would be needed to move from pilot to a real enterprise deployment.

## Already proven

- Microsoft OAuth2 sign-in.
- Microsoft tenant account to local user mapping.
- Local SQL roles and permissions.
- Microsoft Graph connection.
- SharePoint evidence upload.
- SharePoint metadata writeback.
- SharePoint delete lifecycle.
- Current-user activity logging.
- ReadOnly permission enforcement.

## Required production hardening

### Security

- Rotate any exposed development secrets.
- Store secrets in user-secrets, environment variables, Azure Key Vault, or equivalent.
- Review Graph permissions and move toward least privilege.
- Define admin roles for Microsoft/OperationsFlow administration.
- Add account linking/unlinking UI with audit trail.

### Hosting

- Host the app behind HTTPS.
- Use a production database.
- Configure environment-specific appsettings.
- Add production logging and health checks.

### Data protection

- Define backup/restore policy.
- Define document retention policy.
- Define deletion and recovery rules.
- Review SharePoint permissions and library access.

### Operations

- Add monitoring and alerting.
- Add retry/error handling for Graph calls.
- Add sync health/status dashboards.
- Add automated regression tests.

### Future integrations

- Outlook/shared mailbox intake.
- Teams notifications.
- Planner task creation.
- Power Automate trigger support.
- Power BI reporting dataset/export path.
- AI-assisted classification/extraction as a human-reviewed workflow.
