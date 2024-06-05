namespace Infrastructure.Repositories;

public class OrderRepository(
    ApplicationDbContext dbContext)
    : IOrderRepository
{
    public async Task<PaginatedData<OrderEntity>> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize)
    {
        var getListQuery = dbContext.Orders
            .AsNoTracking();
        var countQuery = dbContext.Orders
            .AsNoTracking();
        
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Book)
            .Include(x => x.User)
            .Include(x => x.Status)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<OrderEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<OrderEntity>> GetPaginatedOrdersByUserIdAsync(Guid id, int pageNumber, int pageSize)
    {
        var getListQuery = dbContext.Orders
            .AsNoTracking()
            .Where(x => x.UserId == id);
        var countQuery = dbContext.Orders
            .AsNoTracking()
            .Where(x => x.UserId == id);
        
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Book)
            .Include(x => x.User)
            .Include(x => x.Status)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<OrderEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task CreateAsync(OrderEntity entity)
    {
        await dbContext.Orders.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
}