using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OperationsFlow.Data;
using OperationsFlow.Models;
using OperationsFlow.Services.Microsoft365;

namespace OperationsFlow.Services;

public class LocalAuthService
{
    private readonly OperationsFlowDbContext _db;
    private readonly LocalIdentityService _localIdentityService;
    private readonly LocalCurrentUserService _currentUserService;
    private readonly PasswordHasher<LocalUser> _passwordHasher = new();

    public LocalAuthService(
        OperationsFlowDbContext db,
        LocalIdentityService localIdentityService,
        LocalCurrentUserService currentUserService)
    {
        _db = db;
        _localIdentityService = localIdentityService;
        _currentUserService = currentUserService;
    }

    public async Task<LocalLoginResult> LoginAsync(string userNameOrEmail, string password)
    {
        await _localIdentityService.EnsureSeedDataAsync();

        var loginValue = userNameOrEmail.Trim();

        if (string.IsNullOrWhiteSpace(loginValue) || string.IsNullOrWhiteSpace(password))
        {
            return LocalLoginResult.Fail("Enter a username/email and password.");
        }

        var user = await _db.LocalUsers
            .FirstOrDefaultAsync(item => item.UserName == loginValue || item.Email == loginValue);

        if (user is null)
        {
            return LocalLoginResult.Fail("Invalid username/email or password.");
        }

        if (!user.IsActive)
        {
            return LocalLoginResult.Fail("This local account is inactive.");
        }

        if (user.LockoutUntil.HasValue && user.LockoutUntil.Value > DateTime.UtcNow)
        {
            return LocalLoginResult.Fail($"This account is temporarily locked until {user.LockoutUntil.Value:g} UTC.");
        }

        if (string.IsNullOrWhiteSpace(user.PasswordHash))
        {
            return LocalLoginResult.Fail("This account does not have a local password configured.");
        }

        var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

        if (passwordResult == PasswordVerificationResult.Failed)
        {
            user.FailedLoginCount += 1;

            if (user.FailedLoginCount >= 5)
            {
                user.LockoutUntil = DateTime.UtcNow.AddMinutes(15);
            }

            await _db.SaveChangesAsync();

            return LocalLoginResult.Fail("Invalid username/email or password.");
        }

        if (passwordResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            user.PasswordUpdatedAt = DateTime.UtcNow;
        }

        user.FailedLoginCount = 0;
        user.LockoutUntil = null;
        user.LastLoginAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        var signedInUser = await BuildSignedInUserAsync(user.Id, "Local");

        if (signedInUser is null)
        {
            return LocalLoginResult.Fail("Login succeeded, but the local role profile could not be loaded.");
        }

        _currentUserService.SignIn(signedInUser);

        return LocalLoginResult.Success(signedInUser);
    }

    public async Task<LocalLoginResult> RestoreLoginAsync(int localUserId)
    {
        await _localIdentityService.EnsureSeedDataAsync();

        var user = await _db.LocalUsers.FirstOrDefaultAsync(item => item.Id == localUserId);

        if (user is null)
        {
            return LocalLoginResult.Fail("Saved local session could not be restored.");
        }

        if (!user.IsActive)
        {
            return LocalLoginResult.Fail("Saved local account is inactive.");
        }

        var latestMicrosoftLink = await _db.ExternalLoginLinks
            .AsNoTracking()
            .Where(link =>
                link.LocalUserId == user.Id &&
                link.Provider == "Microsoft" &&
                link.IsLinked &&
                link.LastLoginAt.HasValue)
            .OrderByDescending(link => link.LastLoginAt)
            .FirstOrDefaultAsync();

        var provider = latestMicrosoftLink is null ? "Local" : "Microsoft";

        var signedInUser = await BuildSignedInUserAsync(user.Id, provider);

        if (signedInUser is null)
        {
            return LocalLoginResult.Fail("Saved local role profile could not be loaded.");
        }

        _currentUserService.SignIn(signedInUser);

        return LocalLoginResult.Success(signedInUser);
    }

    public async Task<MicrosoftOAuthSignInResult> LoginExternalMicrosoftAsync(
        string providerUserId,
        string providerEmail,
        string providerDisplayName)
    {
        await _localIdentityService.EnsureSeedDataAsync();

        providerUserId = providerUserId.Trim();
        providerEmail = providerEmail.Trim();

        if (string.IsNullOrWhiteSpace(providerUserId))
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft provider user id was missing.");
        }

        if (string.IsNullOrWhiteSpace(providerEmail))
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft provider email was missing.");
        }

        var existingLink = await _db.ExternalLoginLinks
            .FirstOrDefaultAsync(item =>
                item.Provider == "Microsoft" &&
                item.ProviderUserId == providerUserId &&
                item.IsLinked);

        LocalUser? user = null;

        if (existingLink is not null)
        {
            user = await _db.LocalUsers
                .FirstOrDefaultAsync(item => item.Id == existingLink.LocalUserId);
        }

        if (user is null)
        {
            var normalizedProviderEmail = providerEmail.Trim().ToLowerInvariant();

            user = await _db.LocalUsers
                .FirstOrDefaultAsync(item =>
                    item.Email.ToLower() == normalizedProviderEmail);
        }

        if (user is null)
        {
            var microsoftUserName = ExtractMicrosoftUserName(providerEmail);

            user = await _db.LocalUsers
                .FirstOrDefaultAsync(item =>
                    item.UserName.ToLower() == microsoftUserName);
        }

        if (user is null)
        {
            return MicrosoftOAuthSignInResult.Fail($"No active local OperationsFlow user is linked to Microsoft account '{providerEmail}'.");
        }

        if (!user.IsActive)
        {
            return MicrosoftOAuthSignInResult.Fail("The matched local OperationsFlow account is inactive.");
        }

        var link = await _db.ExternalLoginLinks
            .FirstOrDefaultAsync(item =>
                item.Provider == "Microsoft" &&
                item.LocalUserId == user.Id);

        if (link is null)
        {
            link = new ExternalLoginLink
            {
                LocalUserId = user.Id,
                Provider = "Microsoft",
                ProviderUserId = providerUserId,
                ProviderEmail = providerEmail,
                ProviderDisplayName = string.IsNullOrWhiteSpace(providerDisplayName)
                    ? user.DisplayName
                    : providerDisplayName,
                IsLinked = true,
                LinkedAt = DateTime.UtcNow,
                LastLoginAt = DateTime.UtcNow,
                Notes = "Auto-linked during Week 4 Microsoft OAuth2 sign-in."
            };

            _db.ExternalLoginLinks.Add(link);
        }
        else
        {
            link.ProviderUserId = providerUserId;
            link.ProviderEmail = providerEmail;
            link.ProviderDisplayName = string.IsNullOrWhiteSpace(providerDisplayName)
                ? user.DisplayName
                : providerDisplayName;
            link.IsLinked = true;
            link.LastLoginAt = DateTime.UtcNow;
        }

        user.LastLoginAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        var signedInUser = await BuildSignedInUserAsync(user.Id, "Microsoft");

        if (signedInUser is null)
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft sign-in succeeded, but the local role profile could not be loaded.");
        }

        _currentUserService.SignIn(signedInUser);

        return MicrosoftOAuthSignInResult.Success(
            localUserId: signedInUser.Id,
            providerUserId: providerUserId,
            email: providerEmail,
            displayName: signedInUser.DisplayName);
    }

    public void Logout()
    {
        _currentUserService.SignOut();
    }

    private async Task<LocalSignedInUser?> BuildSignedInUserAsync(
        int userId,
        string signInProvider)
    {
        var user = await _db.LocalUsers.FirstOrDefaultAsync(item => item.Id == userId);

        if (user is null)
        {
            return null;
        }

        var roles = await _db.LocalUserRoles
            .Where(userRole => userRole.LocalUserId == user.Id)
            .Join(
                _db.LocalRoles,
                userRole => userRole.LocalRoleId,
                role => role.Id,
                (userRole, role) => role.Name)
            .Distinct()
            .OrderBy(role => role)
            .ToListAsync();

        var permissions = await _db.LocalUserRoles
            .Where(userRole => userRole.LocalUserId == user.Id)
            .Join(
                _db.LocalRolePermissions,
                userRole => userRole.LocalRoleId,
                rolePermission => rolePermission.LocalRoleId,
                (userRole, rolePermission) => rolePermission)
            .Where(rolePermission => rolePermission.AccessLevel != "No")
            .Join(
                _db.LocalPermissions,
                rolePermission => rolePermission.LocalPermissionId,
                permission => permission.Id,
                (rolePermission, permission) => permission.Key)
            .Distinct()
            .OrderBy(permission => permission)
            .ToListAsync();

        return new LocalSignedInUser
        {
            Id = user.Id,
            UserName = user.UserName,
            DisplayName = user.DisplayName,
            Email = user.Email,
            SignInProvider = string.IsNullOrWhiteSpace(signInProvider)
                ? "Local"
                : signInProvider,
            Roles = roles,
            Permissions = permissions
        };
    }

    private static string ExtractMicrosoftUserName(string providerEmail)
    {
        if (string.IsNullOrWhiteSpace(providerEmail))
        {
            return "";
        }

        var prefix = providerEmail
            .Split('@', StringSplitOptions.RemoveEmptyEntries)
            .FirstOrDefault() ?? "";

        prefix = prefix.Trim().ToLowerInvariant();

        return prefix switch
        {
            "readonly" => "viewer",
            "read-only" => "viewer",
            "read_only" => "viewer",
            "read only" => "viewer",
            _ => prefix
        };
    }
}

public class LocalLoginResult
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public LocalSignedInUser? User { get; set; }

    public static LocalLoginResult Success(LocalSignedInUser user)
    {
        return new LocalLoginResult
        {
            Succeeded = true,
            Message = "Login successful.",
            User = user
        };
    }

    public static LocalLoginResult Fail(string message)
    {
        return new LocalLoginResult
        {
            Succeeded = false,
            Message = message
        };
    }
}