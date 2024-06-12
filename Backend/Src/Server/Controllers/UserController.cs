using Microsoft.AspNetCore.Http.HttpResults;

namespace Server.Controllers;

[ApiController]
[Route("api/identity/user")]
public class UserController(
    IUserService userService)
    : ControllerBase
{
    [HttpGet("count")]
    public async Task<IActionResult> GetCountAsync()
    {
        return Ok(await userService.GetCountAsync());
    }
    
    [HttpPost] 
    public async Task<IActionResult> CreateAsync(SignUpRequest request) 
    { 
        return Ok(await userService.CreateAsync(request));
    }
        
}