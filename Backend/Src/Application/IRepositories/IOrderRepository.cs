namespace Application.IRepositories;

public interface IOrderRepository
{
    Task<int> GetCountAsync();

    Task<PaginatedData<OrderEntity>> GetPaginatedOrdersAsync(int pageNumber, int pageSize);
    Task<PaginatedData<OrderEntity>> GetPaginatedOrdersByUserIdAsync(Guid id, int pageNumber, int pageSize);
    Task CreateAsync(OrderEntity entity);
    Task UpdateAsync(OrderEntity entity);
    Task DeleteAsync(OrderEntity orderEntity);
    
    Task<OrderEntity?> GetByIdAsync(Guid id);
}