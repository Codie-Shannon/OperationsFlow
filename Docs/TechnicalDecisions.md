# Technical Decisions

## Keep authorization local

Decision: Microsoft OAuth2 proves identity, but OperationsFlow local SQL roles/permissions authorize app actions.

Reason: Business permissions are application-specific. A user can be a valid Microsoft tenant user but still be ReadOnly inside OperationsFlow.

## Use ExternalLoginLinks

Decision: Link Microsoft accounts to local users through `ExternalLoginLinks`.

Reason: This avoids replacing the local permission model and supports future account linking/unlinking.

## Use storage abstraction

Decision: Upload pages call `IFileStorageService`, not a specific provider.

Reason: The same UI works with local storage or SharePoint storage.

## Store files in SharePoint and metadata in SQL

Decision: SharePoint stores the physical evidence file; SQL stores the workflow attachment record.

Reason: SharePoint is the document/evidence system, while SQL remains the app workflow/reporting system.

## Write SharePoint metadata

Decision: Write OperationsFlow fields to SharePoint columns.

Reason: A file viewed directly in SharePoint still carries module, record, evidence, uploader, and notes context.

## Delete lifecycle

Decision: Deleting from OperationsFlow deletes the physical SharePoint file and marks the local attachment deleted.

Reason: The app should not claim evidence is deleted while the file remains in SharePoint.

## Current-user activity logging

Decision: Upload/delete activity uses the signed-in current user.

Reason: Audit logs must prove who performed the action, not a generic demo user.
