using MediatR;
using Proveedores.Application.DTOs;

namespace Proveedores.Application.Features.Proveedores.Queries;

public class GetAllProveedoresQuery : IRequest<IEnumerable<ProveedorDto>>
{
}
