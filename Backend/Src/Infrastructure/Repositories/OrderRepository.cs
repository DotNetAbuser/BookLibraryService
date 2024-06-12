namespace Infrastructure.Repositories;

public class OrderRepository(
    ApplicationDbContext dbContext)
    : IOrderRepository
{
    public async Task<int> GetCountAsync()
    {
        return await dbContext.Orders
            .AsNoTracking()
            .CountAsync();
    }

    public async Task<PaginatedData<OrderEntity>> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize)
    {
        var getListQuery = dbContext.Orders
            .OrderByDescending(x => x.Created)
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
            .OrderByDescending(x => x.Created)
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
    
    public async Task<OrderEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Orders
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(OrderEntity entity)
    {
        await dbContext.Orders.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderEntity entity)
    {
        dbContext.Orders.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(OrderEntity orderEntity)
    {
        dbContext.Orders.Remove(orderEntity);
        await dbContext.SaveChangesAsync();
    }

 
}