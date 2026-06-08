using Microsoft.AspNetCore.Mvc;
using Proveedores.Application.Common.Interfaces;
using Proveedores.Application.DTOs;

namespace Proveedores.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        // Simulación: en producción validarías contra una BD de usuarios
        if (request.Correo != "admin@test.com" || request.Contrasena != "123456")
            return Unauthorized(new { mensaje = "Credenciales inválidas" });

        var response = _jwtService.GenerateToken(request.Correo, "Admin");
        return Ok(response);
    }
}
