using MongoDB.Driver;
using Proveedores.Domain.Entities;
using Proveedores.Domain.Interfaces;
using Proveedores.Infrastructure.Data;

namespace Proveedores.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(MongoDbContext context)
    {
        _users = context.Users;
    }

    public async Task<User?> GetByCorreoAsync(string correo)
    {
        return await _users.Find(u => u.Correo == correo).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task<bool> ExistsByCorreoAsync(string correo)
    {
        return await _users.Find(u => u.Correo == correo).AnyAsync();
    }
}
