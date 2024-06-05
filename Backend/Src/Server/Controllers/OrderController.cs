namespace Server.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(
    IOrderService orderService)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPaginatedOrdersAsync(
        int pageNumber, int pageSize)
    {
        return Ok(await orderService.GetPaginatedOrdersAsync(
            pageNumber, pageSize));
    }

    [HttpGet("user/{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedOrdersAsync(
        Guid id, int pageNumber, int pageSize)
    {
        return Ok(await orderService.GetPaginatedOrdersByUserIdAsync(
            id, pageNumber, pageSize));
    }

    [HttpGet("my-orders")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedMyOrdersAsync(
        int pageNumber, int pageSize)
    {
        return Ok(await orderService.GetPaginatedMyOrdersAsync(
            pageNumber, pageSize));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(CreateOrderRequest request)
    {
        return Ok(await orderService.CreateAsync(request));
    }
}