namespace Server.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController(
    IOrderService orderService)
    : ControllerBase
{
    [HttpGet("count")]
    public async Task<IActionResult> GetOrdersCountAsync()
    {
        return Ok(await orderService.GetOrdersCountAsync());
    }
    
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(await orderService.DeleteAsync(id));
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> ChangeOrderStatusAsync(Guid id, ChangeOrderStatusRequest request)
    {
        return Ok(await orderService.ChangeOrderStatusRequest(id, request));
    }

    [HttpPut("{id:guid}/extend")]
    public async Task<IActionResult> ExtendOrderAsync(Guid id, ExtendOrderRequest request)
    {
        return Ok(await orderService.ExtendOrderAsync(id, request));
    }
}