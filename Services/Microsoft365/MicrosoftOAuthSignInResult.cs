namespace OperationsFlow.Services.Microsoft365;

public class MicrosoftOAuthSignInResult
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = "";

    public int? LocalUserId { get; set; }

    public string ProviderUserId { get; set; } = "";

    public string Email { get; set; } = "";

    public string DisplayName { get; set; } = "";

    public static MicrosoftOAuthSignInResult Success(
        int localUserId,
        string providerUserId,
        string email,
        string displayName)
    {
        return new MicrosoftOAuthSignInResult
        {
            Succeeded = true,
            Message = "Microsoft sign-in successful.",
            LocalUserId = localUserId,
            ProviderUserId = providerUserId,
            Email = email,
            DisplayName = displayName
        };
    }

    public static MicrosoftOAuthSignInResult Fail(string message)
    {
        return new MicrosoftOAuthSignInResult
        {
            Succeeded = false,
            Message = message
        };
    }
}