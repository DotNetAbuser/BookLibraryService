namespace Application.IRepositories;

public interface IOrderStatusRepository
{
    Task<IEnumerable<OrderStatusEntity>> GetAllAsync();
}