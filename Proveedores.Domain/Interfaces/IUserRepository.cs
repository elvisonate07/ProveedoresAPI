using Proveedores.Domain.Entities;

namespace Proveedores.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByCorreoAsync(string correo);
    Task CreateAsync(User user);
    Task<bool> ExistsByCorreoAsync(string correo);
}
