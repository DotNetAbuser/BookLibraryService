namespace Server.Controllers;

[ApiController]
[Route("api/common/genre")]
public class GenreController(
    IGenreService genreService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await genreService.GetAllAsync());
    }
    
}