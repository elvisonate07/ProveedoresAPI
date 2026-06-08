using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proveedores.Application.Features.Proveedores.Commands;
using Proveedores.Application.Features.Proveedores.Queries;

namespace Proveedores.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProveedoresController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProveedoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllProveedoresQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{nit}")]
    public async Task<IActionResult> GetByNit(string nit)
    {
        var query = new GetProveedorByNitQuery { Nit = nit };
        var result = await _mediator.Send(query);

        if (result is null)
            return NotFound(new { mensaje = $"Proveedor con NIT {nit} no encontrado" });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProveedorCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByNit), new { nit = result.Nit }, result);
    }

    [HttpPut("{nit}")]
    public async Task<IActionResult> Update(string nit, [FromBody] UpdateProveedorCommand command)
    {
        if (nit != command.Nit)
            return BadRequest(new { mensaje = "El NIT no coincide" });

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{nit}")]
    public async Task<IActionResult> Delete(string nit)
    {
        var command = new DeleteProveedorCommand { Nit = nit };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
