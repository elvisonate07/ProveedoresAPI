using MediatR;
using Proveedores.Application.DTOs;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Application.Features.Proveedores.Queries;

public class GetAllProveedoresQueryHandler : IRequestHandler<GetAllProveedoresQuery, IEnumerable<ProveedorDto>>
{
    private readonly IProveedorRepository _repository;

    public GetAllProveedoresQueryHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProveedorDto>> Handle(GetAllProveedoresQuery request, CancellationToken cancellationToken)
    {
        var proveedores = await _repository.GetAllAsync();
        return proveedores.Select(p => new ProveedorDto
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
        });
    }
}
