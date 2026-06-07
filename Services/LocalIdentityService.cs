using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OperationsFlow.Data;
using OperationsFlow.Models;

namespace OperationsFlow.Services;

public class LocalIdentityService
{
    private readonly OperationsFlowDbContext _db;
    private readonly PasswordHasher<LocalUser> _passwordHasher = new();

    public LocalIdentityService(OperationsFlowDbContext db)
    {
        _db = db;
    }

    public async Task EnsureSeedDataAsync()
    {
        await EnsureRolesAsync();
        await EnsurePermissionsAsync();
        await EnsureUsersAsync();
        await EnsureUserRolesAsync();
        await EnsureRolePermissionsAsync();
        await EnsureExternalLoginLinksAsync();
    }

    public async Task<List<LocalUserSummary>> GetUserSummariesAsync()
    {
        await EnsureSeedDataAsync();

        var users = await _db.LocalUsers
            .OrderBy(user => user.DisplayName)
            .ToListAsync();

        var roles = await _db.LocalRoles.ToListAsync();
        var userRoles = await _db.LocalUserRoles.ToListAsync();
        var loginLinks = await _db.ExternalLoginLinks.ToListAsync();

        return users.Select(user =>
        {
            var assignedRoleNames = userRoles
                .Where(userRole => userRole.LocalUserId == user.Id)
                .Join(
                    roles,
                    userRole => userRole.LocalRoleId,
                    role => role.Id,
                    (userRole, role) => role.DisplayName)
                .OrderBy(roleName => roleName)
                .ToList();

            var linkedProviders = loginLinks
                .Where(link => link.LocalUserId == user.Id && link.IsLinked)
                .Select(link => link.Provider)
                .Distinct()
                .OrderBy(provider => provider)
                .ToList();

            return new LocalUserSummary
            {
                Id = user.Id,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Department = user.Department,
                JobTitle = user.JobTitle,
                IsActive = user.IsActive,
                FailedLoginCount = user.FailedLoginCount,
                LockoutUntil = user.LockoutUntil,
                LastLoginAt = user.LastLoginAt,
                MustChangePassword = user.MustChangePassword,
                HasPassword = !string.IsNullOrWhiteSpace(user.PasswordHash),
                Roles = assignedRoleNames,
                LinkedProviders = linkedProviders,
                Notes = user.Notes
            };
        }).ToList();
    }

    public async Task<List<LocalRole>> GetRolesAsync()
    {
        await EnsureSeedDataAsync();

        return await _db.LocalRoles
            .OrderBy(role => role.Id)
            .ToListAsync();
    }

    public async Task<List<LocalPermission>> GetPermissionsAsync()
    {
        await EnsureSeedDataAsync();

        return await _db.LocalPermissions
            .OrderBy(permission => permission.Category)
            .ThenBy(permission => permission.DisplayName)
            .ToListAsync();
    }

    public async Task<List<LocalRolePermissionSummary>> GetRolePermissionSummariesAsync()
    {
        await EnsureSeedDataAsync();

        var roles = await _db.LocalRoles.OrderBy(role => role.Id).ToListAsync();

        var permissions = await _db.LocalPermissions
            .OrderBy(permission => permission.Category)
            .ThenBy(permission => permission.DisplayName)
            .ToListAsync();

        var rolePermissions = await _db.LocalRolePermissions.ToListAsync();

        var summaries = new List<LocalRolePermissionSummary>();

        foreach (var permission in permissions)
        {
            var accessByRole = new Dictionary<string, string>();

            foreach (var role in roles)
            {
                var rolePermission = rolePermissions.FirstOrDefault(item =>
                    item.LocalRoleId == role.Id &&
                    item.LocalPermissionId == permission.Id);

                accessByRole[role.Name] = rolePermission?.AccessLevel ?? "No";
            }

            summaries.Add(new LocalRolePermissionSummary
            {
                PermissionKey = permission.Key,
                PermissionName = permission.DisplayName,
                Category = permission.Category,
                Description = permission.Description,
                AccessByRole = accessByRole
            });
        }

        return summaries;
    }

    public async Task<List<ExternalLoginLinkSummary>> GetExternalLoginLinksAsync()
    {
        await EnsureSeedDataAsync();

        var users = await _db.LocalUsers
            .AsNoTracking()
            .ToListAsync();

        var links = await _db.ExternalLoginLinks
            .AsNoTracking()
            .OrderBy(link => link.Provider)
            .ThenBy(link => link.ProviderEmail)
            .ToListAsync();

        return links.Select(link =>
        {
            var user = users.FirstOrDefault(item => item.Id == link.LocalUserId);

            return new ExternalLoginLinkSummary
            {
                Id = link.Id,
                LocalUserId = link.LocalUserId,
                LocalUserDisplayName = user?.DisplayName ?? "Unknown user",
                Provider = link.Provider,
                ProviderUserId = link.ProviderUserId,
                ProviderEmail = link.ProviderEmail,
                ProviderDisplayName = link.ProviderDisplayName,
                IsLinked = link.IsLinked,
                LinkedAt = link.LinkedAt,
                LastLoginAt = link.LastLoginAt,
                Notes = link.Notes
            };
        }).ToList();
    }

    public string GetBadgeClassForAccess(string accessLevel)
    {
        return accessLevel.Trim().ToLowerInvariant() switch
        {
            "yes" => "of-badge of-badge-success",
            "assigned" => "of-badge of-badge-warning",
            "limited" => "of-badge of-badge-warning",
            "approved" => "of-badge of-badge-warning",
            "review" => "of-badge of-badge-warning",
            "review evidence" => "of-badge of-badge-warning",
            "relevant" => "of-badge of-badge-info",
            "view" => "of-badge of-badge-muted",
            "no" => "of-badge of-badge-danger",
            _ => "of-badge of-badge-muted"
        };
    }

    public string GetRoleBadgeClass(string roleName)
    {
        return roleName.Trim().ToLowerInvariant() switch
        {
            "admin" => "of-badge of-badge-danger",
            "manager" => "of-badge of-badge-warning",
            "reviewer" => "of-badge of-badge-info",
            "worker" => "of-badge of-badge-success",
            "readonly" => "of-badge of-badge-muted",
            _ => "of-badge of-badge-muted"
        };
    }

    private async Task EnsureRolesAsync()
    {
        var roles = new[]
        {
            new LocalRole
            {
                Name = "Admin",
                DisplayName = "Admin",
                Description = "System administrator with access to settings, users, roles, provider setup, and protected operations.",
                BadgeTone = "danger",
                IsSystemRole = true,
                IsActive = true
            },
            new LocalRole
            {
                Name = "Manager",
                DisplayName = "Manager",
                Description = "Operational manager with workflow oversight, reports, data quality, workload, and follow-up review access.",
                BadgeTone = "warning",
                IsSystemRole = true,
                IsActive = true
            },
            new LocalRole
            {
                Name = "Reviewer",
                DisplayName = "Reviewer",
                Description = "Compliance or audit reviewer with evidence, report, activity, and data quality review access.",
                BadgeTone = "info",
                IsSystemRole = true,
                IsActive = true
            },
            new LocalRole
            {
                Name = "Worker",
                DisplayName = "Worker",
                Description = "Assigned worker who can update assigned work and attach supporting evidence.",
                BadgeTone = "success",
                IsSystemRole = true,
                IsActive = true
            },
            new LocalRole
            {
                Name = "ReadOnly",
                DisplayName = "ReadOnly",
                Description = "View-only user for review, demo, or limited stakeholder access.",
                BadgeTone = "muted",
                IsSystemRole = true,
                IsActive = true
            }
        };

        foreach (var role in roles)
        {
            var exists = await _db.LocalRoles.AnyAsync(item => item.Name == role.Name);

            if (!exists)
            {
                _db.LocalRoles.Add(role);
            }
        }

        await _db.SaveChangesAsync();
    }

    private async Task EnsurePermissionsAsync()
    {
        var permissions = new[]
        {
            Permission("CanViewDashboard", "View dashboard", "Navigation", "Can view dashboard and general landing pages."),
            Permission("CanEditWorkflow", "Create/edit workflow records", "Workflow", "Can create or edit work orders, corrective actions, and document intake records."),
            Permission("CanUploadEvidence", "Upload evidence", "Evidence", "Can upload supporting files to workflow records."),
            Permission("CanDeleteEvidence", "Delete/soft-delete evidence", "Evidence", "Can soft-delete evidence files from records or the document library."),
            Permission("CanViewDocumentLibrary", "View document library", "Evidence", "Can view the cross-module document library."),
            Permission("CanViewReports", "View reports", "Reporting", "Can view reports, evidence coverage, and management summaries."),
            Permission("CanViewDataQuality", "View data quality", "Reporting", "Can view data quality issues and missing evidence checks."),
            Permission("CanExportData", "Export CSV", "Reporting", "Can export CSV review files."),
            Permission("CanManageSettings", "Manage settings", "Administration", "Can manage provider, tenant, and application settings."),
            Permission("CanConfigureStorage", "Configure storage provider", "Administration", "Can configure local, SharePoint, or future storage providers."),
            Permission("CanManageUsers", "Manage users/roles", "Administration", "Can manage local users, roles, role assignments, and external login links.")
        };

        foreach (var permission in permissions)
        {
            var exists = await _db.LocalPermissions.AnyAsync(item => item.Key == permission.Key);

            if (!exists)
            {
                _db.LocalPermissions.Add(permission);
            }
        }

        await _db.SaveChangesAsync();
    }

    private async Task EnsureUsersAsync()
    {
        await EnsureUserAsync(
            userName: "admin",
            displayName: "Local Admin",
            email: "admin@example.local",
            department: "Business Systems",
            jobTitle: "System Administrator",
            password: "Admin123!",
            notes: "Seeded local admin account for Week 3 free/local version.");

        await EnsureUserAsync(
            userName: "manager",
            displayName: "Operations Manager",
            email: "manager@example.local",
            department: "Operations",
            jobTitle: "Operations Manager",
            password: "Manager123!",
            notes: "Seeded local manager account for workflow oversight.");

        await EnsureUserAsync(
            userName: "reviewer",
            displayName: "Safety Reviewer",
            email: "reviewer@example.local",
            department: "Safety",
            jobTitle: "Safety / Compliance Reviewer",
            password: "Reviewer123!",
            notes: "Seeded local reviewer account for evidence and audit review.");

        await EnsureUserAsync(
            userName: "worker",
            displayName: "Site Worker",
            email: "worker@example.local",
            department: "Site",
            jobTitle: "Assigned Worker",
            password: "Worker123!",
            notes: "Seeded local worker account for assigned workflow updates.");

        await EnsureUserAsync(
            userName: "viewer",
            displayName: "Read Only Viewer",
            email: "viewer@example.local",
            department: "Management",
            jobTitle: "Read-only Stakeholder",
            password: "Viewer123!",
            notes: "Seeded local read-only account for view-only access.");
    }

    private async Task EnsureUserAsync(
        string userName,
        string displayName,
        string email,
        string department,
        string jobTitle,
        string password,
        string notes)
    {
        var existingUser = await _db.LocalUsers.FirstOrDefaultAsync(item => item.UserName == userName);

        if (existingUser is null)
        {
            var user = new LocalUser
            {
                UserName = userName,
                DisplayName = displayName,
                Email = email,
                Department = department,
                JobTitle = jobTitle,
                IsActive = true,
                MustChangePassword = false,
                FailedLoginCount = 0,
                Notes = notes
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            user.PasswordUpdatedAt = DateTime.UtcNow;

            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();

            return;
        }

        if (string.IsNullOrWhiteSpace(existingUser.PasswordHash))
        {
            existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser, password);
            existingUser.PasswordUpdatedAt = DateTime.UtcNow;
            existingUser.MustChangePassword = false;

            await _db.SaveChangesAsync();
        }
    }

    private async Task EnsureUserRolesAsync()
    {
        await EnsureUserRoleAsync("admin", "Admin");
        await EnsureUserRoleAsync("manager", "Manager");
        await EnsureUserRoleAsync("reviewer", "Reviewer");
        await EnsureUserRoleAsync("worker", "Worker");
        await EnsureUserRoleAsync("viewer", "ReadOnly");
    }

    private async Task EnsureRolePermissionsAsync()
    {
        var roles = await _db.LocalRoles.ToListAsync();
        var permissions = await _db.LocalPermissions.ToListAsync();

        var matrix = new Dictionary<string, Dictionary<string, string>>
        {
            ["Admin"] = new()
            {
                ["CanViewDashboard"] = "Yes",
                ["CanEditWorkflow"] = "Yes",
                ["CanUploadEvidence"] = "Yes",
                ["CanDeleteEvidence"] = "Yes",
                ["CanViewDocumentLibrary"] = "Yes",
                ["CanViewReports"] = "Yes",
                ["CanViewDataQuality"] = "Yes",
                ["CanExportData"] = "Yes",
                ["CanManageSettings"] = "Yes",
                ["CanConfigureStorage"] = "Yes",
                ["CanManageUsers"] = "Yes"
            },
            ["Manager"] = new()
            {
                ["CanViewDashboard"] = "Yes",
                ["CanEditWorkflow"] = "Yes",
                ["CanUploadEvidence"] = "Yes",
                ["CanDeleteEvidence"] = "Limited",
                ["CanViewDocumentLibrary"] = "Yes",
                ["CanViewReports"] = "Yes",
                ["CanViewDataQuality"] = "Yes",
                ["CanExportData"] = "Yes",
                ["CanManageSettings"] = "No",
                ["CanConfigureStorage"] = "No",
                ["CanManageUsers"] = "No"
            },
            ["Reviewer"] = new()
            {
                ["CanViewDashboard"] = "Yes",
                ["CanEditWorkflow"] = "Review",
                ["CanUploadEvidence"] = "Review evidence",
                ["CanDeleteEvidence"] = "No",
                ["CanViewDocumentLibrary"] = "Yes",
                ["CanViewReports"] = "Yes",
                ["CanViewDataQuality"] = "Yes",
                ["CanExportData"] = "Approved",
                ["CanManageSettings"] = "No",
                ["CanConfigureStorage"] = "No",
                ["CanManageUsers"] = "No"
            },
            ["Worker"] = new()
            {
                ["CanViewDashboard"] = "Yes",
                ["CanEditWorkflow"] = "Assigned",
                ["CanUploadEvidence"] = "Assigned",
                ["CanDeleteEvidence"] = "No",
                ["CanViewDocumentLibrary"] = "Relevant",
                ["CanViewReports"] = "Limited",
                ["CanViewDataQuality"] = "Limited",
                ["CanExportData"] = "No",
                ["CanManageSettings"] = "No",
                ["CanConfigureStorage"] = "No",
                ["CanManageUsers"] = "No"
            },
            ["ReadOnly"] = new()
            {
                ["CanViewDashboard"] = "Yes",
                ["CanEditWorkflow"] = "No",
                ["CanUploadEvidence"] = "No",
                ["CanDeleteEvidence"] = "No",
                ["CanViewDocumentLibrary"] = "View",
                ["CanViewReports"] = "View",
                ["CanViewDataQuality"] = "View",
                ["CanExportData"] = "No",
                ["CanManageSettings"] = "No",
                ["CanConfigureStorage"] = "No",
                ["CanManageUsers"] = "No"
            }
        };

        foreach (var role in roles)
        {
            if (!matrix.TryGetValue(role.Name, out var permissionsForRole))
            {
                continue;
            }

            foreach (var permission in permissions)
            {
                var accessLevel = permissionsForRole.TryGetValue(permission.Key, out var configuredAccess)
                    ? configuredAccess
                    : "No";

                var existing = await _db.LocalRolePermissions.FirstOrDefaultAsync(item =>
                    item.LocalRoleId == role.Id &&
                    item.LocalPermissionId == permission.Id);

                if (existing is null)
                {
                    _db.LocalRolePermissions.Add(new LocalRolePermission
                    {
                        LocalRoleId = role.Id,
                        LocalPermissionId = permission.Id,
                        AccessLevel = accessLevel,
                        Notes = "Seeded permission matrix for Week 3 local SQL-backed roles."
                    });
                }
                else if (string.IsNullOrWhiteSpace(existing.AccessLevel))
                {
                    existing.AccessLevel = accessLevel;
                }
            }
        }

        await _db.SaveChangesAsync();
    }

    private async Task EnsureExternalLoginLinksAsync()
    {
        await EnsureExternalLoginLinkAsync(
            "admin",
            "Microsoft",
            "pending-microsoft-object-id",
            "admin@example.local",
            "Local Admin",
            "Week 4 OAuth2 will replace this placeholder with the Microsoft provider user id/object id.");
    }

    private static LocalPermission Permission(string key, string displayName, string category, string description)
    {
        return new LocalPermission
        {
            Key = key,
            DisplayName = displayName,
            Category = category,
            Description = description,
            IsActive = true
        };
    }

    private async Task EnsureUserRoleAsync(string userName, string roleName)
    {
        var user = await _db.LocalUsers.FirstOrDefaultAsync(item => item.UserName == userName);
        var role = await _db.LocalRoles.FirstOrDefaultAsync(item => item.Name == roleName);

        if (user is null || role is null)
        {
            return;
        }

        var exists = await _db.LocalUserRoles.AnyAsync(item =>
            item.LocalUserId == user.Id &&
            item.LocalRoleId == role.Id);

        if (!exists)
        {
            _db.LocalUserRoles.Add(new LocalUserRole
            {
                LocalUserId = user.Id,
                LocalRoleId = role.Id,
                AssignedAt = DateTime.UtcNow,
                AssignedBy = "System",
                Notes = "Seeded local SQL-backed role assignment."
            });

            await _db.SaveChangesAsync();
        }
    }

    private async Task EnsureExternalLoginLinkAsync(
        string userName,
        string provider,
        string providerUserId,
        string providerEmail,
        string providerDisplayName,
        string notes)
    {
        var user = await _db.LocalUsers.FirstOrDefaultAsync(item => item.UserName == userName);

        if (user is null)
        {
            return;
        }

        var exists = await _db.ExternalLoginLinks.AnyAsync(item =>
            item.LocalUserId == user.Id &&
            item.Provider == provider);

        if (!exists)
        {
            _db.ExternalLoginLinks.Add(new ExternalLoginLink
            {
                LocalUserId = user.Id,
                Provider = provider,
                ProviderUserId = providerUserId,
                ProviderEmail = providerEmail,
                ProviderDisplayName = providerDisplayName,
                IsLinked = true,
                LinkedAt = DateTime.UtcNow,
                Notes = notes
            });

            await _db.SaveChangesAsync();
        }
    }
}

public class LocalUserSummary
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public string JobTitle { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public bool HasPassword { get; set; }

    public int FailedLoginCount { get; set; }

    public DateTime? LockoutUntil { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public bool MustChangePassword { get; set; }

    public List<string> Roles { get; set; } = new();

    public List<string> LinkedProviders { get; set; } = new();

    public string Notes { get; set; } = string.Empty;
}

public class LocalRolePermissionSummary
{
    public string PermissionKey { get; set; } = string.Empty;

    public string PermissionName { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Dictionary<string, string> AccessByRole { get; set; } = new();
}

public class ExternalLoginLinkSummary
{
    public int Id { get; set; }

    public int LocalUserId { get; set; }

    public string LocalUserDisplayName { get; set; } = string.Empty;

    public string Provider { get; set; } = string.Empty;

    public string ProviderUserId { get; set; } = string.Empty;

    public string ProviderEmail { get; set; } = string.Empty;

    public string ProviderDisplayName { get; set; } = string.Empty;

    public bool IsLinked { get; set; }

    public DateTime LinkedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public string Notes { get; set; } = string.Empty;
}