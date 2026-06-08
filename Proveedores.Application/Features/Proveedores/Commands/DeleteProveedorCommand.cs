using MediatR;
using Proveedores.Application.DTOs;

namespace Proveedores.Application.Features.Proveedores.Commands;

public class DeleteProveedorCommand : IRequest<bool>
{
    public string Nit { get; set; } = string.Empty;
}
