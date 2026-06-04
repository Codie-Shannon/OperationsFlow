# OperationsFlow CSS Cleanup Plan

## Purpose

This document explains the planned CSS cleanup/refactor for OperationsFlow.

The current `wwwroot/app.css` file grew quickly during the rapid build sprint. It contains shared layout styles, component styles, table styles, form styles, page-specific styles, responsive rules, and reviewer/portfolio page styles in one large file.

This is acceptable for the current portfolio prototype, but it should be cleaned up before the project is treated as a long-term maintainable codebase.

---

## Current State

Current CSS state:

- Single large `wwwroot/app.css` file.
- Approximately 5,000+ lines after rapid feature/page development.
- Contains both shared styles and page-specific styles.
- Many page sections follow similar visual patterns.
- Some repeated patterns could be extracted into shared component classes.
- The app is currently stable and screenshotted for review.

Because the project is being packaged for review, the immediate priority is to avoid breaking working layouts before Vanessa, Lester, Peter, or technical reviewers see the project.

---

## Why Cleanup Is Needed

A large CSS file becomes harder to maintain because:

- It is harder to find the correct style block.
- Page-specific styles can accidentally affect other pages.
- Repeated card/table/form styles make future changes slower.
- Responsive rules become harder to reason about.
- New pages are more likely to duplicate existing patterns.
- Visual regressions become harder to track.

The goal is not to make the CSS “clever.” The goal is to make it easier to maintain safely.

---

## Cleanup Timing

The full CSS cleanup should happen after the review package is stable.

Recommended timing:

1. Finish all core app/reviewer pages.
2. Finish README/docs/screenshots.
3. Confirm the app builds and runs.
4. Confirm screenshots match the current UI.
5. Then refactor CSS carefully with regression testing.

For the Tuesday review package, the safe approach is:

- Document the cleanup plan.
- Avoid risky class renames.
- Avoid large layout changes.
- Avoid splitting files unless there is time for full retesting.
- Keep the current screenshots accurate.

---

## Proposed CSS File Structure

A future cleanup could split `wwwroot/app.css` into organised files:

```text
wwwroot/css/base.css
wwwroot/css/layout.css
wwwroot/css/components/cards.css
wwwroot/css/components/forms.css
wwwroot/css/components/tables.css
wwwroot/css/components/badges.css
wwwroot/css/components/buttons.css
wwwroot/css/pages/dashboard.css
wwwroot/css/pages/operations.css
wwwroot/css/pages/compliance.css
wwwroot/css/pages/management.css
wwwroot/css/pages/portfolio-review.css
wwwroot/css/pages/technical-review.css
wwwroot/css/pages/production-planning.css
wwwroot/css/responsive.css