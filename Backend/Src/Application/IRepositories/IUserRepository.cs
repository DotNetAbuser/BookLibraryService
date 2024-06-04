namespace Application.IRepositories;

public interface IUserRepository
{
    Task<bool> IsExistByEmailAsync(string email);
    Task<bool> IsExistByUsernameAsync(string username);
    Task CreateAsync(UserEntity entity);
    Task<UserEntity?> GetByUsernameWithRoleAsync(string username);
    Task<UserEntity?> GetByIdWithRoleAsync(Guid id);
}