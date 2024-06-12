namespace Infrastructure.Repositories;

public class ReviewRepository(
    ApplicationDbContext dbContext)
    : IReviewRepository
{
    public async Task<PaginatedData<ReviewEntity>> GetPaginatedReviewsAsync(int pageNumber, int pageSize)
    {
        var getListQuery = dbContext.Reviews
            .AsNoTracking()
            .OrderByDescending(x => x.Created);
        var countQuery = dbContext.Reviews
            .AsNoTracking();
        
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.User)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<ReviewEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task CreateAsync(ReviewEntity entity)
    {
        await dbContext.Reviews.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await dbContext.Reviews
            .AsNoTracking()
            .CountAsync();
    }
}