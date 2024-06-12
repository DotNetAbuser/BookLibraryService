namespace Infrastructure.Managers;

public interface IOrderManager
{
    Task<IResult<int>> GetCountAsync();
    
    Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize);
    Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedOrdersByUserIdAsync(
        Guid id, int pageNumber, int pageSize);

    Task<IResult<PaginatedData<OrderResponse>>> GetPaginatedMyOrdersAsync(
        int pageNumber, int pageSize);

    Task<IResult> CreateAsync(CreateOrderRequest request);
    Task<IResult> ChangeOrderStatusRequest(Guid id, ChangeOrderStatusRequest request);
    Task<IResult> ExtendOrderAsync(Guid id, ExtendOrderRequest request);
    Task<IResult> DeleteAsync(Guid id);
}

public class OrderManager(
    IHttpClientFactory factory)
    : IOrderManager
{
    public async Task<IResult<int>> GetCountAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetCount);
        return await response.ToResultAsync<int>();
    }
    
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

    public async Task<IResult> ChangeOrderStatusRequest(Guid id, ChangeOrderStatusRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(OrderRoutes.ChangeOrderStatus(id), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> ExtendOrderAsync(Guid id, ExtendOrderRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(OrderRoutes.ExtendOrder(id), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(OrderRoutes.Delete(id));
        return await response.ToResultAsync();
    }
}