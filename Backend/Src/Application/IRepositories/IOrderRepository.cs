namespace Application.IRepositories;

public interface IOrderRepository
{
    Task<PaginatedData<OrderEntity>> GetPaginatedOrdersAsync(int pageNumber, int pageSize);
    Task<PaginatedData<OrderEntity>> GetPaginatedOrdersByUserIdAsync(Guid id, int pageNumber, int pageSize);
    Task CreateAsync(OrderEntity entity);
}