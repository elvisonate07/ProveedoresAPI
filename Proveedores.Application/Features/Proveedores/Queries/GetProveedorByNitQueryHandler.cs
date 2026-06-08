using MediatR;
using Proveedores.Application.DTOs;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Application.Features.Proveedores.Queries;

public class GetProveedorByNitQueryHandler : IRequestHandler<GetProveedorByNitQuery, ProveedorDto?>
{
    private readonly IProveedorRepository _repository;

    public GetProveedorByNitQueryHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProveedorDto?> Handle(GetProveedorByNitQuery request, CancellationToken cancellationToken)
    {
        var p = await _repository.GetByNitAsync(request.Nit);
        if (p is null) return null;

        return new ProveedorDto
        {
            Id = p.Id,
            Nit = p.Nit,
            RazonSocial = p.RazonSocial,
            Direccion = p.Direccion,
            Ciudad = p.Ciudad,
            Departamento = p.Departamento,
            Correo = p.Correo,
            Activo = p.Activo,
            FechaCreacion = p.FechaCreacion,
            NombreContacto = p.NombreContacto,
            CorreoContacto = p.CorreoContacto
        };
    }
}
