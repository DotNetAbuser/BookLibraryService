namespace Infrastructure.Managers;

public interface IOrderManager
{
    Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize);
    Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(
        Guid id, int pageNumber, int pageSize);

    Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedMyOrdersAsync(
        int pageNumber, int pageSize);

    Task<IResult> CreateAsync(CreateOrderRequest request);
}

public class OrderManager(
    IHttpClientFactory factory)
    : IOrderManager
{
    public async Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(int pageNumber, int pageSize)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetPaginatedOrders(pageNumber, pageSize));
        return await response.ToResultAsync<PaginatedData<OrderResponse>>();
    }

    public async Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(Guid id, int pageNumber, int pageSize)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetPaginatedOrdersByUserId(id, pageNumber, pageSize));
        return await response.ToResultAsync<PaginatedData<OrderResponse>>();
    }

    public async Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedMyOrdersAsync(int pageNumber, int pageSize)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetPaginatedMyOrders(pageNumber, pageSize));
        return await response.ToResultAsync<PaginatedData<OrderResponse>>();
    }

    public async Task<IResult> CreateAsync(CreateOrderRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(OrderRoutes.Create,request);
        return await response.ToResultAsync<PaginatedData<OrderResponse>>();
    }
}