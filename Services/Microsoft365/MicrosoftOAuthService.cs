using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Options;
using OperationsFlow.Options;

namespace OperationsFlow.Services.Microsoft365;

public class MicrosoftOAuthService
{
    private readonly Microsoft365Options microsoft365Options;
    private readonly HttpClient httpClient;
    private readonly LocalAuthService localAuthService;

    public MicrosoftOAuthService(
        IOptions<Microsoft365Options> microsoft365Options,
        HttpClient httpClient,
        LocalAuthService localAuthService)
    {
        this.microsoft365Options = microsoft365Options.Value;
        this.httpClient = httpClient;
        this.localAuthService = localAuthService;
    }

    public string BuildAuthorizationUrl(string returnUrl = "/dashboard")
    {
        if (!microsoft365Options.Enabled ||
            !microsoft365Options.HasTenantId ||
            !microsoft365Options.HasClientId ||
            !microsoft365Options.HasRedirectUri)
        {
            throw new InvalidOperationException("Microsoft OAuth2 configuration is incomplete.");
        }

        var state = Uri.EscapeDataString(string.IsNullOrWhiteSpace(returnUrl) ? "/dashboard" : returnUrl);

        var query = new Dictionary<string, string?>
        {
            ["client_id"] = microsoft365Options.ClientId,
            ["response_type"] = "code",
            ["redirect_uri"] = microsoft365Options.RedirectUri,
            ["response_mode"] = "query",
            ["scope"] = "openid profile email offline_access User.Read",
            ["state"] = state,
            ["prompt"] = "select_account"
        };

        var queryString = string.Join("&", query.Select(item =>
            $"{Uri.EscapeDataString(item.Key)}={Uri.EscapeDataString(item.Value ?? "")}"));

        return $"https://login.microsoftonline.com/{Uri.EscapeDataString(microsoft365Options.TenantId)}/oauth2/v2.0/authorize?{queryString}";
    }

    public async Task<MicrosoftOAuthSignInResult> CompleteSignInAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft did not return an authorization code.");
        }

        if (!microsoft365Options.Enabled ||
            !microsoft365Options.HasBasicGraphConfig ||
            !microsoft365Options.HasRedirectUri)
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft OAuth2 configuration is incomplete.");
        }

        var token = await ExchangeCodeForTokenAsync(code, cancellationToken);

        if (string.IsNullOrWhiteSpace(token.AccessToken))
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft token exchange did not return an access token.");
        }

        var profile = await GetMicrosoftProfileAsync(token.AccessToken, cancellationToken);

        if (string.IsNullOrWhiteSpace(profile.ProviderUserId))
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft profile did not include a user id.");
        }

        if (string.IsNullOrWhiteSpace(profile.Email))
        {
            return MicrosoftOAuthSignInResult.Fail("Microsoft profile did not include an email or user principal name.");
        }

        return await localAuthService.LoginExternalMicrosoftAsync(
            providerUserId: profile.ProviderUserId,
            providerEmail: profile.Email,
            providerDisplayName: profile.DisplayName);
    }

    private async Task<TokenResponse> ExchangeCodeForTokenAsync(
        string code,
        CancellationToken cancellationToken)
    {
        var tokenUrl = $"https://login.microsoftonline.com/{Uri.EscapeDataString(microsoft365Options.TenantId)}/oauth2/v2.0/token";

        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = microsoft365Options.ClientId,
            ["client_secret"] = microsoft365Options.ClientSecret,
            ["code"] = code,
            ["redirect_uri"] = microsoft365Options.RedirectUri,
            ["grant_type"] = "authorization_code",
            ["scope"] = "openid profile email offline_access User.Read"
        });

        using var response = await httpClient.PostAsync(tokenUrl, content, cancellationToken);
        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Microsoft token exchange failed: {(int)response.StatusCode} {response.ReasonPhrase}. {body}");
        }

        using var json = JsonDocument.Parse(body);
        var root = json.RootElement;

        return new TokenResponse
        {
            AccessToken = root.TryGetProperty("access_token", out var accessToken)
                ? accessToken.GetString() ?? ""
                : "",
            IdToken = root.TryGetProperty("id_token", out var idToken)
                ? idToken.GetString() ?? ""
                : ""
        };
    }

    private async Task<MicrosoftProfile> GetMicrosoftProfileAsync(
        string accessToken,
        CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://graph.microsoft.com/v1.0/me?$select=id,displayName,mail,userPrincipalName");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Microsoft profile lookup failed: {(int)response.StatusCode} {response.ReasonPhrase}. {body}");
        }

        using var json = JsonDocument.Parse(body);
        var root = json.RootElement;

        var id = root.TryGetProperty("id", out var idElement)
            ? idElement.GetString() ?? ""
            : "";

        var displayName = root.TryGetProperty("displayName", out var displayNameElement)
            ? displayNameElement.GetString() ?? ""
            : "";

        var mail = root.TryGetProperty("mail", out var mailElement)
            ? mailElement.GetString() ?? ""
            : "";

        var userPrincipalName = root.TryGetProperty("userPrincipalName", out var upnElement)
            ? upnElement.GetString() ?? ""
            : "";

        var email = !string.IsNullOrWhiteSpace(mail)
            ? mail
            : userPrincipalName;

        return new MicrosoftProfile
        {
            ProviderUserId = id,
            DisplayName = displayName,
            Email = email
        };
    }

    private class TokenResponse
    {
        public string AccessToken { get; set; } = "";

        public string IdToken { get; set; } = "";
    }

    private class MicrosoftProfile
    {
        public string ProviderUserId { get; set; } = "";

        public string Email { get; set; } = "";

        public string DisplayName { get; set; } = "";
    }
}