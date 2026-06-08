# Demo Walkthrough

## Goal

Show OperationsFlow as a production pilot-ready Microsoft 365 workflow system.

## Recommended walkthrough

1. Open the Login page.
   - Show local SQL login.
   - Show Microsoft sign-in.
   - Explain that Microsoft proves identity while OperationsFlow local SQL controls roles/permissions.

2. Sign in with Microsoft as Admin.
   - Show the dashboard.
   - Show the sidebar `Microsoft-linked` badge and Admin role.

3. Sign out and sign in locally as Admin.
   - Show the `Local login` badge.
   - Explain both paths load the same local authorization model.

4. Open Admin Settings.
   - Run or show Microsoft 365 connection test.
   - Confirm Graph connected, SharePoint site resolved, and document library resolved.

5. Open User Roles.
   - Show local users, roles, permissions, and external login links.
   - Explain Microsoft accounts map to local users.

6. Open a Work Order details page.
   - Upload evidence.
   - Confirm provider is SharePoint.

7. Open SharePoint.
   - Show OperationsFlow Evidence / Work Orders / record folder.
   - Show uploaded file.
   - Show metadata columns populated.

8. Open Document Library.
   - Show SharePoint provider.
   - Show Open/Delete actions for Admin.

9. Open Activity Log.
   - Show upload/delete events recorded against the current user.

10. Sign in as ReadOnly.
    - Show no upload/delete/export actions.

## Key sentence

OperationsFlow is a working single-tenant Microsoft 365 pilot with local SQL authorization, Microsoft OAuth2 identity, SharePoint evidence storage, metadata writeback, and permission-controlled workflow actions.
