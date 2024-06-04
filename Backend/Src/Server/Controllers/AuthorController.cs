namespace Server.Controllers;

[ApiController]
[Route("api/common/author")]
public class AuthorController(
    IAuthorService authorService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPaginatedAuthorAsync(
        int pageNumber, int pageSize)
    {
        return Ok(await authorService.GetPaginatedAuthorsAsync(
            pageNumber, pageSize));
    }
}