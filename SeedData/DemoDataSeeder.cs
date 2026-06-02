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
            new Site { Name = "Admin Office", Location = "Whakatane", Manager = "Office Manager" }
        );
    }

    private static void SeedDepartments(OperationsFlowDbContext db)
    {
        db.Departments.AddRange(
            new Department { Name = "Operations", Manager = "Operations Manager" },
            new Department { Name = "Health & Safety", Manager = "H&S Coordinator" },
            new Department { Name = "Admin", Manager = "Office Manager" },
            new Department { Name = "Maintenance", Manager = "Maintenance Lead" }
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
            }
        );
    }
}