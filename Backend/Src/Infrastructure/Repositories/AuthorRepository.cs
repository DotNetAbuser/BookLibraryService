namespace Infrastructure.Repositories;

public class AuthorRepository(
    ApplicationDbContext dbContext)
    : IAuthorRepository
{
    public async Task<PaginatedData<AuthorEntity>> GetPaginatedAuthorsAsync(
        int pageNumber, int pageSize)
    {
        var getListQuery = dbContext.Authors
            .AsNoTracking();
        var countQuery = dbContext.Authors
            .AsNoTracking();
        
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<AuthorEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<IEnumerable<AuthorEntity>> GetAllAsync()
    {
        return await dbContext.Authors
            .AsNoTracking()
            .ToListAsync();
    }
}