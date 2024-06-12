namespace Server.Controllers;

[ApiController]
[Route("api/common/author")]
public class AuthorController(
    IAuthorService authorService)
    : ControllerBase
{
    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginatedAuthorAsync(
        int pageNumber, int pageSize)
    {
        return Ok(await authorService.GetPaginatedAuthorsAsync(
            pageNumber, pageSize));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await authorService.GetAllAsync());
    }
}