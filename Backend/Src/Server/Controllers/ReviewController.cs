namespace Server.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController(
    IReviewService reviewService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPaginatedReviewsAsync(
        int pageNumber, int pageSize)
    {
        return Ok(await reviewService.GetPaginatedReviewsAsync(
            pageNumber, pageSize));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(CreateReviewRequest request)
    {
        return Ok(await reviewService.CreateAsync(request));
    }
}