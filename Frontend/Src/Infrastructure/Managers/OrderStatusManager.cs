namespace Infrastructure.Managers;

public interface IOrderStatusManager
{
    Task<IResult<IEnumerable<OrderStatusResponse>>> GetAllStatusesAsync();
}

public class OrderStatusManager(
    IHttpClientFactory factory)
    : IOrderStatusManager
{
    public async Task<IResult<IEnumerable<OrderStatusResponse>>> GetAllStatusesAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderStatusRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<OrderStatusResponse>>();
    }
}