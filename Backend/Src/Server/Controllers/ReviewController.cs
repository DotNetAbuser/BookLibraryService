using Microsoft.AspNetCore.Http.HttpResults;

namespace Server.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController(
    IReviewService reviewService)
    : ControllerBase
{
    [HttpGet("count")]
    public async Task<IActionResult> GetCountAsync()
    {
        return Ok(await reviewService.GetCountAsync());
    }
    
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