using MediatR;
using Proveedores.Application.DTOs;
using Proveedores.Domain.Entities;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Application.Features.Proveedores.Commands;

public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, ProveedorDto>
{
    private readonly IProveedorRepository _repository;

    public CreateProveedorCommandHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProveedorDto> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
    {
        if (await _repository.ExistsByNitAsync(request.Nit))
            throw new FluentValidation.ValidationException($"Ya existe un proveedor con el NIT {request.Nit}");

        var proveedor = new Proveedor
        {
            Nit = request.Nit,
            RazonSocial = request.RazonSocial,
            Direccion = request.Direccion,
            Ciudad = request.Ciudad,
            Departamento = request.Departamento,
            Correo = request.Correo,
            Activo = true,
            FechaCreacion = DateTime.UtcNow,
            NombreContacto = request.NombreContacto,
            CorreoContacto = request.CorreoContacto
        };

        await _repository.CreateAsync(proveedor);

        return new ProveedorDto
        {
            Id = proveedor.Id,
            Nit = proveedor.Nit,
            RazonSocial = proveedor.RazonSocial,
            Direccion = proveedor.Direccion,
            Ciudad = proveedor.Ciudad,
            Departamento = proveedor.Departamento,
            Correo = proveedor.Correo,
            Activo = proveedor.Activo,
            FechaCreacion = proveedor.FechaCreacion,
            NombreContacto = proveedor.NombreContacto,
            CorreoContacto = proveedor.CorreoContacto
        };
    }
}