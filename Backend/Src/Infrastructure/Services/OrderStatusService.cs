namespace Infrastructure.Services;

public class OrderStatusService(
    IOrderStatusRepository orderStatusRepository)
    : IOrderStatusService
{
    public async Task<Result<IEnumerable<OrderStatusResponse>>> GetAllStatusesAsync()
    {
        var ordersStatusesEntities = await orderStatusRepository.GetAllAsync();
        var ordersStatusesResponse = ordersStatusesEntities
            .Select(orderStatusEntity => 
                new OrderStatusResponse(
                    Id: orderStatusEntity.Id,
                    Name: orderStatusEntity.Name)).ToList();
        return Result<IEnumerable<OrderStatusResponse>>.Success(ordersStatusesResponse, "Все статусы заказов успешно получены.");
    }
}