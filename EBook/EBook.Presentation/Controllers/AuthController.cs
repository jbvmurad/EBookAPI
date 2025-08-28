using EBook.Application.DTOs.AuthDTOs;
using EBook.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid data format");
        }

        var result = await _authService.LoginAsync(request);

        if (string.IsNullOrEmpty(result.Token))
        {
            return Unauthorized(result);
        }

        return Ok(result);
    }
}
