using MediatR;
using Proveedores.Domain.Interfaces;

namespace Proveedores.Application.Features.Proveedores.Commands;

public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, bool>
{
    private readonly IProveedorRepository _repository;

    public DeleteProveedorCommandHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
    {
        var existe = await _repository.ExistsByNitAsync(request.Nit);
        if (!existe)
            return false;

        await _repository.DeleteAsync(request.Nit);
        return true;
    }
}
