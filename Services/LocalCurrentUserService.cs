using OperationsFlow.Models;

namespace OperationsFlow.Services;

public class LocalCurrentUserService
{
    public LocalSignedInUser? CurrentUser { get; private set; }

    public bool IsSignedIn => CurrentUser is not null;

    public event Action? CurrentUserChanged;

    public void SignIn(LocalSignedInUser user)
    {
        CurrentUser = user;
        CurrentUserChanged?.Invoke();
    }

    public void SignOut()
    {
        CurrentUser = null;
        CurrentUserChanged?.Invoke();
    }

    public bool HasRole(string roleName)
    {
        if (CurrentUser is null)
        {
            return false;
        }

        return CurrentUser.Roles.Any(role =>
            role.Equals(roleName, StringComparison.OrdinalIgnoreCase));
    }

    public bool HasPermission(string permissionKey)
    {
        if (CurrentUser is null)
        {
            return false;
        }

        return CurrentUser.Permissions.Any(permission =>
            permission.Equals(permissionKey, StringComparison.OrdinalIgnoreCase));
    }

    public bool CanEditWorkflow => HasPermission("CanEditWorkflow");

    public bool CanUploadEvidence => HasPermission("CanUploadEvidence");

    public bool CanDeleteEvidence => HasPermission("CanDeleteEvidence");

    public bool CanViewDocumentLibrary => HasPermission("CanViewDocumentLibrary");

    public bool CanViewReports => HasPermission("CanViewReports");

    public bool CanViewDataQuality => HasPermission("CanViewDataQuality");

    public bool CanExportData => HasPermission("CanExportData");

    public bool CanManageSettings => HasPermission("CanManageSettings");

    public bool CanConfigureStorage => HasPermission("CanConfigureStorage");

    public bool CanManageUsers => HasPermission("CanManageUsers");
}

public class LocalSignedInUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string SignInProvider { get; set; } = "Local";

    public List<string> Roles { get; set; } = new();

    public List<string> Permissions { get; set; } = new();

    public bool IsMicrosoftLinked =>
        SignInProvider.Equals("Microsoft", StringComparison.OrdinalIgnoreCase);

    public string SignInProviderDisplay =>
        IsMicrosoftLinked ? "Microsoft-linked" : "Local login";
}