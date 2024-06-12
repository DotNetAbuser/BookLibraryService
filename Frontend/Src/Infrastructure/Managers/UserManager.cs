namespace Infrastructure.Managers;

public interface IUserManager
{
    Task<IResult<int>> GetCountAsync();
    
    Task<IResult> CreateAsync(SignUpRequest request);
}

public class UserManager(
    IHttpClientFactory factory)
    : IUserManager
{
    public async Task<IResult<int>> GetCountAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(UserRoutes.GetCount);
        return await response.ToResultAsync<int>();
    }
    
    public async Task<IResult> CreateAsync(SignUpRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(UserRoutes.Create, request);
        return await response.ToResultAsync();
    }
}