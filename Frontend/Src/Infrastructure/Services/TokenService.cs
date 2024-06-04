namespace Infrastructure.Services;

public interface ITokenService
{
    Task<string> GetAuthTokenAsync();
    Task<string> GetRefreshTokenAsync();
    Task SetAuthTokenAsync(string authToken);
    Task SetRefreshTokenAsync(string refreshToken);
    Task RemoveAuthTokenAsync();
    Task RemoveRefreshTokenAsync();
    string GetUserIdFromAuthToken(string token);
    string GetRoleFromAuthToken(string token);
    string GetUsernameFromAuthToken(string token);
    string GetEmailFromAuthToken(string token);
}

public class TokenService(
    ISessionStorageService sessionStorageService)
    : ITokenService
{
    public async Task<string> GetAuthTokenAsync() =>
        await sessionStorageService.GetItemAsync<string>(StorageConstants.AuthToken) ?? string.Empty;

    public async Task<string> GetRefreshTokenAsync() =>
        await sessionStorageService.GetItemAsync<string>(StorageConstants.RefreshToken) ?? string.Empty;

    public async Task SetAuthTokenAsync(string authToken) =>
        await sessionStorageService.SetItemAsync(StorageConstants.AuthToken, authToken);

    public async Task SetRefreshTokenAsync(string refreshToken) =>
        await sessionStorageService.SetItemAsync(StorageConstants.RefreshToken, refreshToken);
    
    public async Task RemoveAuthTokenAsync() =>
        await sessionStorageService.RemoveItemAsync(StorageConstants.AuthToken);

    public async Task RemoveRefreshTokenAsync() =>
        await sessionStorageService.RemoveItemAsync(StorageConstants.RefreshToken);
    
    public string GetUserIdFromAuthToken(string token)
    {
        var authToken = new JwtSecurityToken(token);
        return authToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    }
    
    public string GetUsernameFromAuthToken(string token)
    {
        var authToken = new JwtSecurityToken(token);
        return authToken.Claims.First(c => c.Type == ClaimTypes.Name).Value;
    }

    public string GetEmailFromAuthToken(string token)
    {
        var authToken = new JwtSecurityToken(token);
        return authToken.Claims.First(c => c.Type == ClaimTypes.Email).Value;
    }

    public string GetRoleFromAuthToken(string token)
    {
        var authToken = new JwtSecurityToken(token);
        return authToken.Claims.First(c => c.Type == ClaimTypes.Role).Value;
    }
}