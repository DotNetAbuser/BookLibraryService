namespace Infrastructure.Repositories;

public class OrderStatusRepository(
    ApplicationDbContext dbContext)
    : IOrderStatusRepository
{
    public async Task<IEnumerable<OrderStatusEntity>> GetAllAsync()
    {
        return await dbContext.OrderStatuses
            .AsNoTracking()
            .ToListAsync();
    }
}