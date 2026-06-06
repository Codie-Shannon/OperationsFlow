OperationsFlow CSV Export Package
=================================

Purpose
-------
This folder contains CSV exports from the OperationsFlow portfolio prototype.

These files are designed for:
- management review
- safety/compliance meetings
- Excel review
- Power BI-style analysis
- follow-up planning
- audit/review evidence
- Microsoft 365 / SharePoint / Power Automate implementation planning

Current Prototype Boundary
--------------------------
These CSV files are static demo exports for the local portfolio prototype.

They prove:
- the data model can be exported
- workflow records can be reviewed outside the app
- reports can support management packs
- future Microsoft 365 / Power BI / SharePoint integrations have a clear export shape

They do not yet prove:
- live scheduled exports
- authenticated export permissions
- tenant-based SharePoint storage
- live Power BI dataset refresh
- automated email delivery
- production audit retention rules

Recommended Review Order
------------------------
1. activity-log.csv
   Start here to see record-level traceability.

2. corrective-actions.csv
   Review open, overdue, high-priority, and source-linked follow-up work.

3. work-orders.csv
   Review operational work requests, owners, priorities, status, and due dates.

4. document-intake.csv
   Review incoming admin/document workflow items and target systems.

5. document-reviews.csv
   Review controlled documents, review dates, status, and due flags.

6. risk-register.csv
   Review hazards, risk score, controls, owners, and review dates.

7. training.csv
   Review required training, expiry dates, expired records, and compliance flags.

Export Files
------------
activity-log.csv
Record-level history of created, updated, and reviewed workflow events.

corrective-actions.csv
Corrective and improvement actions with source, owner, priority, status, due date, and notes.

work-orders.csv
Operational work requests with work order number, owner, department, type, priority, status, and due date.

document-intake.csv
Incoming documents, source type, target system, assigned person, status, due date, and processing notes.

document-reviews.csv
Controlled document review records including document number, owner, version, status, and review dates.

risk-register.csv
Operational risk records including hazard, controls, owner, likelihood, consequence, score, level, and review date.

training.csv
Training compliance records including staff, training type, status, completion date, expiry date, and required flag.

How This Supports Week 3 / Week 4
---------------------------------
Week 3 hybrid foundation:
- confirms export shapes
- maps local data to Microsoft Lists / SharePoint-ready columns
- supports implementation planning without needing a live tenant

Week 4 Microsoft 365 implementation:
- CSVs can be used as import/reference files for Microsoft Lists
- exports help define Power Automate trigger fields
- exports help define Power BI reporting tables
- exports provide sample data for SharePoint/Teams/Outlook workflow demos

Reviewer Notes
--------------
This export package is intentionally demo-safe.

All records use fake portfolio data.
No real business, employee, client, supplier, or safety data is included.