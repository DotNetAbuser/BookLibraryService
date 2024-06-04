namespace Infrastructure.Repositories;

public class UserRepository(
    ApplicationDbContext dbContext)
    : IUserRepository
{
    public async Task<UserEntity?> GetByUsernameWithRoleAsync(string username)
    {
        return await dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<UserEntity?> GetByIdWithRoleAsync(Guid id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<bool> IsExistByEmailAsync(string email)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsExistByUsernameAsync(string username)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Username == username);
    }

    public async Task CreateAsync(UserEntity entity)
    {
        await dbContext.Users.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }


}