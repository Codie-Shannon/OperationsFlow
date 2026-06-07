using Microsoft.JSInterop;

namespace OperationsFlow.Services;

public class LocalSessionStorageService
{
    private const string LocalUserIdKey = "operationsflow.localUserId";
    private readonly IJSRuntime jsRuntime;

    public LocalSessionStorageService(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public async Task SaveSignedInUserIdAsync(int localUserId)
    {
        await jsRuntime.InvokeVoidAsync(
            "localStorage.setItem",
            LocalUserIdKey,
            localUserId.ToString());
    }

    public async Task<int?> GetSignedInUserIdAsync()
    {
        try
        {
            var value = await jsRuntime.InvokeAsync<string?>(
                "localStorage.getItem",
                LocalUserIdKey);

            if (int.TryParse(value, out var localUserId))
            {
                return localUserId;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task ClearSignedInUserIdAsync()
    {
        await jsRuntime.InvokeVoidAsync(
            "localStorage.removeItem",
            LocalUserIdKey);
    }
}