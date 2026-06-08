# OperationsFlow Styling System

## Purpose

This document explains the shared UI/style direction used across OperationsFlow. The goal is a clean internal business systems dashboard, not a flashy marketing site.

## Current Styling Direction

OperationsFlow should look like:

```text
professional internal operations / admin / compliance system
```

Visual language:

- navy/purple sidebar
- light cards
- blue accent buttons/links
- readable metric cards
- status badges
- table cards
- clear page heroes
- reviewer/business panels
- practical form layouts

## Shared UI Components

Use these before adding new custom page structures:

- `PageHero`
- `PurposeNote`
- `MetricGrid`
- `MetricCard`
- `InfoPanel`
- `TableCard`
- `FilterBar`
- `EmptyState`
- `GuidanceNote`
- `ActionStrip`
- `ActivityHistoryPanel`
- `RecordAttachments`

## Preferred CSS Class Families

Common classes:

```text
of-btn
of-btn-primary
of-btn-secondary
of-card-link
of-badge
of-badge-success
of-badge-warning
of-badge-danger
of-badge-info
of-badge-muted
of-review-proof-grid
of-review-proof-card
of-two-column-grid
of-mini-list
of-mini-list-item
of-link-row
of-muted-text
of-input
of-select
badge
badge-success
badge-warning
badge-danger
badge-info
badge-muted
helper-text
```

## Permission UI Rule

When adding new actions, wire the visibility to permissions:

- create/edit workflow actions -> `CurrentUserService.CanEditWorkflow`
- upload evidence -> `CurrentUserService.CanUploadEvidence`
- delete evidence -> `CurrentUserService.CanDeleteEvidence`
- export/download CSV -> `CurrentUserService.CanExportData`
- settings -> `CurrentUserService.CanManageSettings`
- users/roles -> `CurrentUserService.CanManageUsers`

Do not add new create/edit/upload/delete/export buttons without checking the relevant permission.

## What Was Cleaned

Week 2 cleaned repeated layout patterns and reduced duplicated CSS. Week 3 reused those patterns for authentication, document library, role/permission pages, reports, and reviewer pages.

## Why Some Compatibility Classes Remain

Some pages still use older `btn`, `badge`, `form-control`, or compatibility classes. They remain to avoid unnecessary churn while the shared UI system is stabilised.

## Future CSS Structure

Later cleanup could split CSS into:

- layout
- navigation
- buttons
- badges
- forms
- tables
- cards
- auth/session
- attachments
- reports

## Styling Rule Going Forward

For Week 4, do not redesign pages. Keep the current UI language and only add Microsoft 365 configuration/status sections where needed.
