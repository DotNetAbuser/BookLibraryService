namespace Application.IServices;

public interface IOrderService
{
    Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize);
    Task<Result<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(
        Guid id, int pageNumber, int pageSize);

    Task<Result<PaginatedData<OrderResponse>>> GetPaginatedMyOrdersAsync(
        int pageNumber, int pageSize);

    Task<Result> CreateAsync(CreateOrderRequest request);
}