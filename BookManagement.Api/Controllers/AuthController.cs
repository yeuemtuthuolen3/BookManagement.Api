using BookManagement.Api.Dtos;
using BookManagement.Api.Services;
using BookManagement.Api.UoW;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtService _jwtService;
    private readonly AuthService _authService;

    public AuthController(JwtService jwtService, AuthService authService, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto reqDto)
    {
        var user = await _unitOfWork.Users.GetByUsernameAsync(reqDto.Username);

        if(user == null)
        {
            return Unauthorized(new ErrorDto("401", "Unauthorized", "Username or Password incorrect."));
        }

        if (_authService.VerifyPassword(reqDto.Password,user.Password))
        {
            var token = _jwtService.GenerateJwtToken(reqDto.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized(new ErrorDto("401", "Unauthorized", "Username or Password incorrect."));
    }
}

