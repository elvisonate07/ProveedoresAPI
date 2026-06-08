using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Proveedores.Application.Common.Interfaces;
using Proveedores.Application.DTOs;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("LoginPolicy")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserRepository _userRepository;

    public AuthController(IJwtService jwtService, IUserRepository userRepository)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var user = await _userRepository.GetByCorreoAsync(request.Correo);
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Contrasena, user.PasswordHash))
            return Unauthorized(new { mensaje = "Credenciales inválidas" });

        if (!user.Activo)
            return Unauthorized(new { mensaje = "Usuario inactivo" });

        var response = _jwtService.GenerateToken(user.Correo, user.Rol);
        return Ok(response);
    }
}
