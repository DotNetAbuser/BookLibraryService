namespace Application.IServices;

public interface IOrderService
{
    Task<Result<int>> GetOrdersCountAsync();
    
    Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize);
    Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(
        Guid id, int pageNumber, int pageSize);

    Task<Result<PaginatedData<OrderResponse>>> GetPaginatedMyOrdersAsync(
        int pageNumber, int pageSize);

    Task<Result> CreateAsync(CreateOrderRequest request);
    Task<Result> DeleteAsync(Guid id);

    Task<Result> ChangeOrderStatusRequest(Guid id, ChangeOrderStatusRequest request);
    Task<Result> ExtendOrderAsync(Guid id, ExtendOrderRequest request);
}