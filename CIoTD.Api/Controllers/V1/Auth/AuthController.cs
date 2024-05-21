using CIoTD.Api.Helpers;
using CIoTD.Core.V1.Auth.Interfaces.Services;
using CIoTD.Core.V1.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace CIoTD.Api;

[ApiController]
[Route("/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] AuthRequest input)
    {
        var response = await _authService.Authenticate(input);

        return Ok(response);
    }
}
