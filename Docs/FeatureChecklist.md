# OperationsFlow Feature Checklist

## Core App

- [x] Blazor/.NET 8 app
- [x] Shared layout/navigation
- [x] Shared UI components
- [x] SQLite local development support
- [x] SQL Server / LocalDB production foundation support
- [x] EF Core models/services
- [x] Seeded demo workflow data
- [x] Activity logging
- [x] CSV export package

## Authentication / Permissions

- [x] Local SQL-backed users
- [x] Local roles
- [x] Local permissions
- [x] Login page as landing page
- [x] Logout flow
- [x] SessionStorage login persistence
- [x] Protected navigation
- [x] Sidebar user/role display
- [x] ReadOnly view-only role tested
- [x] Admin action role tested
- [x] Workflow create/edit permission enforcement
- [x] Evidence upload permission enforcement
- [x] Evidence delete permission enforcement
- [x] CSV/export permission enforcement
- [x] Settings/user management permission boundaries
- [ ] Microsoft Entra OAuth2 sign-in
- [ ] Microsoft account to local user linking

## Dashboard

- [x] Workflow status cards
- [x] Recent activity visibility
- [x] Local SQL/auth status messaging
- [x] Links to user roles/admin/technical pages

## Work Orders

- [x] Register/list
- [x] Details page
- [x] Create page
- [x] Edit page
- [x] Activity history
- [x] Attachment panel
- [x] File count column
- [x] ReadOnly hides new/edit/upload/delete actions

## Corrective Actions

- [x] Register/list
- [x] Details page
- [x] Create page
- [x] Edit page
- [x] Source-linked creation from risk/training/documents
- [x] Attachment panel
- [x] File count column
- [x] ReadOnly hides new/edit/upload/delete actions

## Document Intake

- [x] Register/list
- [x] Details page
- [x] Create page
- [x] Edit page
- [x] Attachment panel
- [x] File count column
- [x] ReadOnly hides new/edit/upload/delete actions
- [ ] SharePoint file routing

## Document Library

- [x] Upload local files
- [x] Store file metadata
- [x] Search/filter
- [x] Open/download links
- [x] Soft delete
- [x] Activity logging
- [x] Upload/delete permission enforcement
- [ ] SharePoint provider connected

## Safety / Compliance

- [x] Risk Register
- [x] Training Compliance
- [x] Document Control
- [x] Source-linked Create Action links
- [x] Create Action links hidden from ReadOnly

## Management Views

- [x] Workload
- [x] Reminders
- [x] Reports
- [x] Evidence coverage report
- [x] Missing evidence report
- [x] Data Quality
- [x] Missing evidence checks

## Activity / Audit

- [x] Global Activity Log
- [x] Record-level histories
- [x] Upload/delete activity events
- [x] Export hidden unless export permission exists
- [ ] Production immutable audit rules
- [ ] Microsoft 365 audit/history mapping

## CSV Exports

- [x] Export package
- [x] README/manifest
- [x] Export permission visibility rules
- [ ] Scheduled exports
- [ ] Power BI service publishing

## Reviewer / Portfolio Pages

- [x] Reviewer Checklist
- [x] Demo Guide
- [x] Business Value
- [x] Technical Overview
- [x] Integration Overview
- [x] Prototype Scope
- [x] Implementation Plan
- [x] User Roles
- [x] Admin Settings

## Week 4 Microsoft 365 Targets

- [ ] Confirm tenant/admin access
- [ ] Create test users/groups
- [ ] Create SharePoint site
- [ ] Create SharePoint document library
- [ ] Create Entra app registration
- [ ] Configure redirect URLs
- [ ] Configure Graph permissions
- [ ] Implement OAuth2 sign-in
- [ ] Link Microsoft accounts to LocalUser
- [ ] Connect SharePointFileStorageService
- [ ] Test SharePoint upload/open/delete
- [ ] Update docs/screenshots/setup guide

## Current Overall State

OperationsFlow now demonstrates business workflow thinking, local SQL auth, permissions, evidence/document handling, reports, data quality, activity traceability, shared UI refactoring, and a clear Microsoft 365 production implementation path.
