using MediatR;
using Proveedores.Application.DTOs;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Application.Features.Proveedores.Commands;

public class UpdateProveedorCommandHandler : IRequestHandler<UpdateProveedorCommand, ProveedorDto>
{
    private readonly IProveedorRepository _repository;

    public UpdateProveedorCommandHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProveedorDto> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
    {
        var proveedor = await _repository.GetByNitAsync(request.Nit)
            ?? throw new KeyNotFoundException($"Proveedor con NIT {request.Nit} no encontrado");

        proveedor.RazonSocial = request.RazonSocial;
        proveedor.Direccion = request.Direccion;
        proveedor.Ciudad = request.Ciudad;
        proveedor.Departamento = request.Departamento;
        proveedor.Correo = request.Correo;
        proveedor.Activo = request.Activo;
        proveedor.NombreContacto = request.NombreContacto;
        proveedor.CorreoContacto = request.CorreoContacto;

        await _repository.UpdateAsync(proveedor);

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
