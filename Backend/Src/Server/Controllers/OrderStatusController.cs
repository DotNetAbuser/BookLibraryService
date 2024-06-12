namespace Server.Controllers;

[ApiController]
[Route("api/common/order-status")]
public class OrderStatusController(
    IOrderStatusService orderStatusService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStatusesAsync()
    {
        return Ok(await orderStatusService.GetAllStatusesAsync());
    }
}