using OperationsFlow.Data;
using OperationsFlow.Models;

namespace OperationsFlow.SeedData;

public static class DemoDataSeeder
{
    public static void Seed(OperationsFlowDbContext db)
    {
        db.Database.EnsureCreated();

        if (db.WorkOrders.Any())
        {
            return;
        }

        SeedSites(db);
        SeedDepartments(db);
        SeedWorkOrders(db);
        SeedCorrectiveActions(db);
        SeedDocuments(db);
        SeedRisks(db);
        SeedTraining(db);

        db.SaveChanges();
    }

    private static void SeedSites(OperationsFlowDbContext db)
    {
        db.Sites.AddRange(
            new Site { Name = "Main Workshop", Location = "Whakatane", Manager = "Operations Manager" },
            new Site { Name = "Yard", Location = "Whakatane", Manager = "Yard Supervisor" },
            new Site { Name = "Admin Office", Location = "Whakatane", Manager = "Office Manager" },
            new Site { Name = "Warehouse", Location = "Whakatane", Manager = "Warehouse Lead" },
            new Site { Name = "Dispatch Bay", Location = "Whakatane", Manager = "Dispatch Coordinator" }
        );
    }

    private static void SeedDepartments(OperationsFlowDbContext db)
    {
        db.Departments.AddRange(
            new Department { Name = "Operations", Manager = "Operations Manager" },
            new Department { Name = "Health & Safety", Manager = "H&S Coordinator" },
            new Department { Name = "Admin", Manager = "Office Manager" },
            new Department { Name = "Maintenance", Manager = "Maintenance Lead" },
            new Department { Name = "Warehouse", Manager = "Warehouse Lead" },
            new Department { Name = "Dispatch", Manager = "Dispatch Coordinator" },
            new Department { Name = "Quality", Manager = "Quality Coordinator" }
        );
    }

    private static void SeedWorkOrders(OperationsFlowDbContext db)
    {
        db.WorkOrders.AddRange(
            new WorkOrder
            {
                Title = "Forklift pre-start checklist issue",
                WorkOrderNumber = "WO-1001",
                Site = "Main Workshop",
                Department = "Operations",
                Owner = "Sam",
                Type = "Maintenance",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-12),
                DueDate = DateTime.Today.AddDays(-2),
                Notes = "Checklist issue raised during morning pre-start."
            },
            new WorkOrder
            {
                Title = "Workshop lighting repair",
                WorkOrderNumber = "WO-1002",
                Site = "Main Workshop",
                Department = "Maintenance",
                Owner = "Jordan",
                Type = "Repair",
                Priority = "Medium",
                Status = "In Progress",
                CreatedDate = DateTime.Today.AddDays(-8),
                DueDate = DateTime.Today.AddDays(3),
                Notes = "Several lights flickering in bay 2."
            },
            new WorkOrder
            {
                Title = "PPE stock reorder",
                WorkOrderNumber = "WO-1003",
                Site = "Yard",
                Department = "Health & Safety",
                Owner = "Taylor",
                Type = "Supply",
                Priority = "Medium",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-5),
                DueDate = DateTime.Today.AddDays(5),
                Notes = "Gloves and safety glasses running low."
            },
            new WorkOrder
            {
                Title = "Update site induction board",
                WorkOrderNumber = "WO-1004",
                Site = "Admin Office",
                Department = "Admin",
                Owner = "Casey",
                Type = "Admin",
                Priority = "Low",
                Status = "Completed",
                CreatedDate = DateTime.Today.AddDays(-10),
                DueDate = DateTime.Today.AddDays(-1),
                Notes = "Board updated with current emergency contact list."
            },
            new WorkOrder
            {
                Title = "Repair roller door sensor",
                WorkOrderNumber = "WO-1005",
                Site = "Warehouse",
                Department = "Maintenance",
                Owner = "Jordan",
                Type = "Repair",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-9),
                DueDate = DateTime.Today.AddDays(-1),
                Notes = "Roller door sensor intermittently fails to detect obstruction."
            },
            new WorkOrder
            {
                Title = "Replace damaged pallet racking label",
                WorkOrderNumber = "WO-1006",
                Site = "Warehouse",
                Department = "Warehouse",
                Owner = "Mia",
                Type = "Compliance",
                Priority = "Low",
                Status = "Completed",
                CreatedDate = DateTime.Today.AddDays(-14),
                DueDate = DateTime.Today.AddDays(-6),
                Notes = "Load rating label replaced on aisle 3 rack."
            },
            new WorkOrder
            {
                Title = "Service air compressor",
                WorkOrderNumber = "WO-1007",
                Site = "Main Workshop",
                Department = "Maintenance",
                Owner = "Jordan",
                Type = "Preventative Maintenance",
                Priority = "Medium",
                Status = "In Progress",
                CreatedDate = DateTime.Today.AddDays(-4),
                DueDate = DateTime.Today.AddDays(8),
                Notes = "Scheduled service for workshop air compressor."
            },
            new WorkOrder
            {
                Title = "Check spill kit contents",
                WorkOrderNumber = "WO-1008",
                Site = "Dispatch Bay",
                Department = "Health & Safety",
                Owner = "Taylor",
                Type = "Inspection",
                Priority = "Medium",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-2),
                DueDate = DateTime.Today.AddDays(4),
                Notes = "Quarterly spill kit check required for dispatch area."
            },
            new WorkOrder
            {
                Title = "Repaint pedestrian walkway line",
                WorkOrderNumber = "WO-1009",
                Site = "Yard",
                Department = "Operations",
                Owner = "Sam",
                Type = "Site Improvement",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-7),
                DueDate = DateTime.Today.AddDays(1),
                Notes = "Walkway line is faded near loading area."
            },
            new WorkOrder
            {
                Title = "Archive completed job folders",
                WorkOrderNumber = "WO-1010",
                Site = "Admin Office",
                Department = "Admin",
                Owner = "Casey",
                Type = "Admin",
                Priority = "Low",
                Status = "Completed",
                CreatedDate = DateTime.Today.AddDays(-18),
                DueDate = DateTime.Today.AddDays(-9),
                Notes = "Completed job folders archived to document library."
            },
            new WorkOrder
            {
                Title = "Investigate dispatch scanner issue",
                WorkOrderNumber = "WO-1011",
                Site = "Dispatch Bay",
                Department = "Dispatch",
                Owner = "Riley",
                Type = "IT Support",
                Priority = "Medium",
                Status = "In Progress",
                CreatedDate = DateTime.Today.AddDays(-3),
                DueDate = DateTime.Today.AddDays(6),
                Notes = "Scanner occasionally fails to sync completed dispatch checks."
            },
            new WorkOrder
            {
                Title = "Replace first aid room notice",
                WorkOrderNumber = "WO-1012",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Owner = "Mia",
                Type = "Compliance",
                Priority = "Low",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-1),
                DueDate = DateTime.Today.AddDays(12),
                Notes = "Notice needs updated first aid officer list."
            }
        );
    }

    private static void SeedCorrectiveActions(OperationsFlowDbContext db)
    {
        db.CorrectiveActions.AddRange(
            new CorrectiveAction
            {
                Title = "Review chemical storage process",
                Source = "Internal Audit",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Owner = "Mia",
                ActionType = "Process Review",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-20),
                DueDate = DateTime.Today.AddDays(-4),
                Notes = "Chemicals need clearer segregation and labelling."
            },
            new CorrectiveAction
            {
                Title = "Replace damaged safety signage",
                Source = "Inspection",
                Site = "Yard",
                Department = "Operations",
                Owner = "Sam",
                ActionType = "Repair",
                Priority = "Medium",
                Status = "In Progress",
                CreatedDate = DateTime.Today.AddDays(-6),
                DueDate = DateTime.Today.AddDays(2),
                Notes = "Damaged pedestrian walkway signage."
            },
            new CorrectiveAction
            {
                Title = "Investigate near-miss report",
                Source = "Incident",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Owner = "Taylor",
                ActionType = "Investigation",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-3),
                DueDate = DateTime.Today.AddDays(7),
                Notes = "Near miss involving forklift and pedestrian."
            },
            new CorrectiveAction
            {
                Title = "Update manual handling SOP",
                Source = "Risk Review",
                Site = "Admin Office",
                Department = "Health & Safety",
                Owner = "Mia",
                ActionType = "Document Update",
                Priority = "Medium",
                Status = "Completed",
                CreatedDate = DateTime.Today.AddDays(-30),
                DueDate = DateTime.Today.AddDays(-10),
                CompletedDate = DateTime.Today.AddDays(-12),
                Notes = "SOP updated and issued."
            },
            new CorrectiveAction
            {
                Title = "Create weekly housekeeping checklist",
                Source = "Inspection",
                Site = "Main Workshop",
                Department = "Operations",
                Owner = "Sam",
                ActionType = "Checklist",
                Priority = "Medium",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-11),
                DueDate = DateTime.Today.AddDays(-1),
                Notes = "Inspection found inconsistent housekeeping records."
            },
            new CorrectiveAction
            {
                Title = "Review contractor sign-in process",
                Source = "Internal Audit",
                Site = "Admin Office",
                Department = "Admin",
                Owner = "Casey",
                ActionType = "Process Review",
                Priority = "Low",
                Status = "In Progress",
                CreatedDate = DateTime.Today.AddDays(-9),
                DueDate = DateTime.Today.AddDays(10),
                Notes = "Contractor sign-in records need consistent review."
            },
            new CorrectiveAction
            {
                Title = "Update forklift exclusion zone map",
                Source = "Risk Review",
                Site = "Warehouse",
                Department = "Health & Safety",
                Owner = "Taylor",
                ActionType = "Document Update",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-5),
                DueDate = DateTime.Today.AddDays(5),
                Notes = "Warehouse traffic layout changed after racking adjustment."
            },
            new CorrectiveAction
            {
                Title = "Replace worn extension lead",
                Source = "Hazard Report",
                Site = "Main Workshop",
                Department = "Maintenance",
                Owner = "Jordan",
                ActionType = "Repair",
                Priority = "High",
                Status = "Completed",
                CreatedDate = DateTime.Today.AddDays(-16),
                DueDate = DateTime.Today.AddDays(-8),
                CompletedDate = DateTime.Today.AddDays(-9),
                Notes = "Damaged lead removed from service and replaced."
            },
            new CorrectiveAction
            {
                Title = "Run refresher on incident reporting",
                Source = "Incident",
                Site = "Dispatch Bay",
                Department = "Health & Safety",
                Owner = "Mia",
                ActionType = "Training",
                Priority = "Medium",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-2),
                DueDate = DateTime.Today.AddDays(14),
                Notes = "Team needs reminder on near-miss reporting expectations."
            },
            new CorrectiveAction
            {
                Title = "Review dispatch loading checklist",
                Source = "Quality Review",
                Site = "Dispatch Bay",
                Department = "Dispatch",
                Owner = "Riley",
                ActionType = "Checklist",
                Priority = "Medium",
                Status = "In Progress",
                CreatedDate = DateTime.Today.AddDays(-7),
                DueDate = DateTime.Today.AddDays(4),
                Notes = "Checklist needs clearer final load confirmation step."
            },
            new CorrectiveAction
            {
                Title = "Add SDS link to chemical register",
                Source = "Internal Audit",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Owner = "Taylor",
                ActionType = "System Update",
                Priority = "Low",
                Status = "Completed",
                CreatedDate = DateTime.Today.AddDays(-24),
                DueDate = DateTime.Today.AddDays(-12),
                CompletedDate = DateTime.Today.AddDays(-13),
                Notes = "SDS links added to shared document register."
            },
            new CorrectiveAction
            {
                Title = "Review missed maintenance escalation",
                Source = "Management Review",
                Site = "Main Workshop",
                Department = "Maintenance",
                Owner = "Jordan",
                ActionType = "Process Review",
                Priority = "High",
                Status = "Open",
                CreatedDate = DateTime.Today.AddDays(-4),
                DueDate = DateTime.Today.AddDays(3),
                Notes = "One preventative maintenance task was not escalated before due date."
            }
        );
    }

    private static void SeedDocuments(OperationsFlowDbContext db)
    {
        db.DocumentRecords.AddRange(
            new DocumentRecord
            {
                Title = "Health and Safety Policy",
                DocumentNumber = "DOC-HS-001",
                DocumentType = "Policy",
                Owner = "Mia",
                Department = "Health & Safety",
                Status = "Current",
                Version = "2.1",
                LastReviewedDate = DateTime.Today.AddMonths(-11),
                NextReviewDate = DateTime.Today.AddDays(20),
                Notes = "Annual policy review due soon."
            },
            new DocumentRecord
            {
                Title = "Emergency Response Plan",
                DocumentNumber = "DOC-HS-002",
                DocumentType = "Procedure",
                Owner = "Taylor",
                Department = "Health & Safety",
                Status = "Review Due",
                Version = "1.4",
                LastReviewedDate = DateTime.Today.AddMonths(-13),
                NextReviewDate = DateTime.Today.AddDays(-8),
                Notes = "Needs review after site layout changes."
            },
            new DocumentRecord
            {
                Title = "Forklift SOP",
                DocumentNumber = "DOC-OPS-010",
                DocumentType = "SOP",
                Owner = "Sam",
                Department = "Operations",
                Status = "Current",
                Version = "3.0",
                LastReviewedDate = DateTime.Today.AddMonths(-5),
                NextReviewDate = DateTime.Today.AddMonths(7),
                Notes = "Current version used in training."
            },
            new DocumentRecord
            {
                Title = "Contractor Induction Form",
                DocumentNumber = "DOC-ADM-004",
                DocumentType = "Form",
                Owner = "Casey",
                Department = "Admin",
                Status = "Draft",
                Version = "0.9",
                LastReviewedDate = DateTime.Today.AddMonths(-2),
                NextReviewDate = DateTime.Today.AddDays(14),
                Notes = "Draft form awaiting approval."
            },
            new DocumentRecord
            {
                Title = "Manual Handling SOP",
                DocumentNumber = "DOC-HS-003",
                DocumentType = "SOP",
                Owner = "Mia",
                Department = "Health & Safety",
                Status = "Current",
                Version = "2.4",
                LastReviewedDate = DateTime.Today.AddMonths(-3),
                NextReviewDate = DateTime.Today.AddMonths(9),
                Notes = "Updated after corrective action review."
            },
            new DocumentRecord
            {
                Title = "Warehouse Traffic Management Plan",
                DocumentNumber = "DOC-OPS-014",
                DocumentType = "Procedure",
                Owner = "Sam",
                Department = "Operations",
                Status = "Review Due",
                Version = "1.2",
                LastReviewedDate = DateTime.Today.AddMonths(-12),
                NextReviewDate = DateTime.Today.AddDays(-2),
                Notes = "Review required after warehouse layout change."
            },
            new DocumentRecord
            {
                Title = "Spill Response Checklist",
                DocumentNumber = "DOC-HS-006",
                DocumentType = "Checklist",
                Owner = "Taylor",
                Department = "Health & Safety",
                Status = "Current",
                Version = "1.1",
                LastReviewedDate = DateTime.Today.AddMonths(-4),
                NextReviewDate = DateTime.Today.AddMonths(8),
                Notes = "Used during quarterly spill kit inspections."
            },
            new DocumentRecord
            {
                Title = "Dispatch Load Verification Form",
                DocumentNumber = "DOC-DIS-002",
                DocumentType = "Form",
                Owner = "Riley",
                Department = "Dispatch",
                Status = "Under Review",
                Version = "1.6",
                LastReviewedDate = DateTime.Today.AddMonths(-8),
                NextReviewDate = DateTime.Today.AddDays(10),
                Notes = "Reviewing final sign-off section."
            },
            new DocumentRecord
            {
                Title = "Preventative Maintenance Schedule",
                DocumentNumber = "DOC-MNT-001",
                DocumentType = "Register",
                Owner = "Jordan",
                Department = "Maintenance",
                Status = "Current",
                Version = "4.2",
                LastReviewedDate = DateTime.Today.AddMonths(-1),
                NextReviewDate = DateTime.Today.AddMonths(11),
                Notes = "Master schedule for routine maintenance."
            },
            new DocumentRecord
            {
                Title = "Quality Inspection Checklist",
                DocumentNumber = "DOC-QUA-005",
                DocumentType = "Checklist",
                Owner = "Alex",
                Department = "Quality",
                Status = "Current",
                Version = "2.0",
                LastReviewedDate = DateTime.Today.AddMonths(-6),
                NextReviewDate = DateTime.Today.AddMonths(6),
                Notes = "Checklist used for final quality checks."
            }
        );
    }

    private static void SeedRisks(OperationsFlowDbContext db)
    {
        db.RiskItems.AddRange(
            new RiskItem
            {
                Title = "Forklift and pedestrian interaction",
                Hazard = "Moving forklifts near pedestrian walkway",
                Site = "Main Workshop",
                Department = "Operations",
                Owner = "Sam",
                Likelihood = 4,
                Consequence = 5,
                Controls = "Marked walkways, spotters, speed limits, induction.",
                Status = "Active",
                ReviewDate = DateTime.Today.AddDays(15)
            },
            new RiskItem
            {
                Title = "Chemical storage",
                Hazard = "Incorrect storage of hazardous substances",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Owner = "Mia",
                Likelihood = 3,
                Consequence = 5,
                Controls = "Labels, SDS folder, segregated cabinet.",
                Status = "Active",
                ReviewDate = DateTime.Today.AddDays(-3)
            },
            new RiskItem
            {
                Title = "Manual handling injury",
                Hazard = "Lifting heavy components without assistance",
                Site = "Yard",
                Department = "Operations",
                Owner = "Jordan",
                Likelihood = 3,
                Consequence = 3,
                Controls = "Team lifts, trolley use, manual handling SOP.",
                Status = "Active",
                ReviewDate = DateTime.Today.AddDays(60)
            },
            new RiskItem
            {
                Title = "Workshop trip hazards",
                Hazard = "Loose cables and tools near work area",
                Site = "Main Workshop",
                Department = "Maintenance",
                Owner = "Taylor",
                Likelihood = 2,
                Consequence = 3,
                Controls = "Housekeeping checks and cable management.",
                Status = "Monitoring",
                ReviewDate = DateTime.Today.AddDays(30)
            },
            new RiskItem
            {
                Title = "Warehouse racking impact",
                Hazard = "Forklift impact damage to pallet racking",
                Site = "Warehouse",
                Department = "Warehouse",
                Owner = "Sam",
                Likelihood = 3,
                Consequence = 4,
                Controls = "Rack inspections, barriers, speed limits, operator training.",
                Status = "Monitoring",
                ReviewDate = DateTime.Today.AddDays(18)
            },
            new RiskItem
            {
                Title = "Dispatch load movement",
                Hazard = "Loads shifting during final dispatch checks",
                Site = "Dispatch Bay",
                Department = "Dispatch",
                Owner = "Riley",
                Likelihood = 3,
                Consequence = 4,
                Controls = "Load restraint checklist, final verification, supervisor sign-off.",
                Status = "Active",
                ReviewDate = DateTime.Today.AddDays(8)
            },
            new RiskItem
            {
                Title = "Electrical lead damage",
                Hazard = "Damaged extension leads used in workshop",
                Site = "Main Workshop",
                Department = "Maintenance",
                Owner = "Jordan",
                Likelihood = 2,
                Consequence = 5,
                Controls = "Test and tag, visual inspections, remove damaged leads from service.",
                Status = "Controlled",
                ReviewDate = DateTime.Today.AddMonths(3)
            },
            new RiskItem
            {
                Title = "Outdoor heat exposure",
                Hazard = "Staff working outside during hot conditions",
                Site = "Yard",
                Department = "Operations",
                Owner = "Taylor",
                Likelihood = 3,
                Consequence = 3,
                Controls = "Water access, rest breaks, shade, heat awareness reminders.",
                Status = "Controlled",
                ReviewDate = DateTime.Today.AddMonths(2)
            },
            new RiskItem
            {
                Title = "Contractor access control",
                Hazard = "Contractors entering site without current induction",
                Site = "Admin Office",
                Department = "Admin",
                Owner = "Casey",
                Likelihood = 2,
                Consequence = 4,
                Controls = "Sign-in process, induction records, visitor badges.",
                Status = "Monitoring",
                ReviewDate = DateTime.Today.AddDays(-1)
            },
            new RiskItem
            {
                Title = "Quality check missed before dispatch",
                Hazard = "Product dispatched without final quality verification",
                Site = "Dispatch Bay",
                Department = "Quality",
                Owner = "Alex",
                Likelihood = 2,
                Consequence = 4,
                Controls = "Quality inspection checklist, dispatch hold point, supervisor review.",
                Status = "Controlled",
                ReviewDate = DateTime.Today.AddMonths(4)
            }
        );
    }

    private static void SeedTraining(OperationsFlowDbContext db)
    {
        db.TrainingRecords.AddRange(
            new TrainingRecord
            {
                StaffName = "Sam",
                TrainingName = "Forklift Refresher",
                Site = "Main Workshop",
                Department = "Operations",
                Status = "Expired",
                CompletedDate = DateTime.Today.AddYears(-2),
                ExpiryDate = DateTime.Today.AddDays(-15),
                IsRequired = true,
                Notes = "Refresher needs booking."
            },
            new TrainingRecord
            {
                StaffName = "Mia",
                TrainingName = "First Aid",
                Site = "Admin Office",
                Department = "Health & Safety",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-8),
                ExpiryDate = DateTime.Today.AddMonths(16),
                IsRequired = true,
                Notes = "Current certificate."
            },
            new TrainingRecord
            {
                StaffName = "Jordan",
                TrainingName = "Site Induction",
                Site = "Yard",
                Department = "Maintenance",
                Status = "Expiring Soon",
                CompletedDate = DateTime.Today.AddMonths(-11),
                ExpiryDate = DateTime.Today.AddDays(12),
                IsRequired = true,
                Notes = "Renewal due soon."
            },
            new TrainingRecord
            {
                StaffName = "Casey",
                TrainingName = "Hazard Reporting",
                Site = "Admin Office",
                Department = "Admin",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-3),
                ExpiryDate = DateTime.Today.AddMonths(9),
                IsRequired = true,
                Notes = "Completed online training."
            },
            new TrainingRecord
            {
                StaffName = "Taylor",
                TrainingName = "Incident Investigation",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-5),
                ExpiryDate = DateTime.Today.AddMonths(7),
                IsRequired = true,
                Notes = "Supports incident and near-miss review process."
            },
            new TrainingRecord
            {
                StaffName = "Riley",
                TrainingName = "Load Restraint",
                Site = "Dispatch Bay",
                Department = "Dispatch",
                Status = "Expiring Soon",
                CompletedDate = DateTime.Today.AddMonths(-11),
                ExpiryDate = DateTime.Today.AddDays(20),
                IsRequired = true,
                Notes = "Dispatch refresher due soon."
            },
            new TrainingRecord
            {
                StaffName = "Alex",
                TrainingName = "Quality Inspection",
                Site = "Dispatch Bay",
                Department = "Quality",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-4),
                ExpiryDate = DateTime.Today.AddMonths(8),
                IsRequired = true,
                Notes = "Current quality inspection competency."
            },
            new TrainingRecord
            {
                StaffName = "Jordan",
                TrainingName = "Electrical Safety Awareness",
                Site = "Main Workshop",
                Department = "Maintenance",
                Status = "Expired",
                CompletedDate = DateTime.Today.AddMonths(-18),
                ExpiryDate = DateTime.Today.AddDays(-20),
                IsRequired = true,
                Notes = "Refresher required for maintenance work."
            },
            new TrainingRecord
            {
                StaffName = "Sam",
                TrainingName = "Manual Handling",
                Site = "Yard",
                Department = "Operations",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-6),
                ExpiryDate = DateTime.Today.AddMonths(6),
                IsRequired = true,
                Notes = "Current manual handling training."
            },
            new TrainingRecord
            {
                StaffName = "Casey",
                TrainingName = "Privacy and Records Handling",
                Site = "Admin Office",
                Department = "Admin",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-2),
                ExpiryDate = DateTime.Today.AddMonths(10),
                IsRequired = false,
                Notes = "Optional admin development training."
            },
            new TrainingRecord
            {
                StaffName = "Mia",
                TrainingName = "Chemical Handling",
                Site = "Main Workshop",
                Department = "Health & Safety",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-7),
                ExpiryDate = DateTime.Today.AddMonths(5),
                IsRequired = true,
                Notes = "Required for chemical storage process review."
            },
            new TrainingRecord
            {
                StaffName = "Riley",
                TrainingName = "Emergency Evacuation Warden",
                Site = "Dispatch Bay",
                Department = "Dispatch",
                Status = "Current",
                CompletedDate = DateTime.Today.AddMonths(-9),
                ExpiryDate = DateTime.Today.AddMonths(3),
                IsRequired = false,
                Notes = "Optional warden training for dispatch area."
            }
        );
    }
}