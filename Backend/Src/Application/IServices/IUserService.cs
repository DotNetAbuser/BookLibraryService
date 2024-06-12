namespace Application.IServices;

public interface IUserService
{
    Task<Result<int>> GetCountAsync();
    Task<Result> CreateAsync(SignUpRequest request);
}