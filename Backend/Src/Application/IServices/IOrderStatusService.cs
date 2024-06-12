namespace Application.IServices;

public interface IOrderStatusService
{
    Task<Result<IEnumerable<OrderStatusResponse>>> GetAllStatusesAsync();
}