namespace Server.Controllers;

[ApiController]
[Route("api/common/book")]
public class BookController(
    IBookService bookService)
    : ControllerBase
{
    [HttpGet("count")]
    public async Task<IActionResult> GetCountAsync()
    {
        return Ok(await bookService.GetCountAsync());
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPaginatedBooksAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        return Ok(await bookService.GetPaginatedBooksAsync(
            pageNumber, pageSize, searchTerms));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        return Ok(await bookService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBookRequest request)
    {
        return Ok(await bookService.CreateAsync(request));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateBookRequest request)
    {
        return Ok(await bookService.UpdateAsync(id, request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(await bookService.DeleteAsync(id));
    }
}