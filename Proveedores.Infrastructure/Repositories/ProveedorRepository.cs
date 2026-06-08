using MongoDB.Driver;
using Proveedores.Domain.Entities;
using Proveedores.Domain.Interfaces;
using Proveedores.Infrastructure.Data;

namespace Proveedores.Infrastructure.Repositories;

public class ProveedorRepository : IProveedorRepository
{
    private readonly IMongoCollection<Proveedor> _proveedores;

    public ProveedorRepository(MongoDbContext context)
    {
        _proveedores = context.Proveedores;
    }

    public async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _proveedores.Find(p => true).ToListAsync();
    }

    public async Task<Proveedor?> GetByNitAsync(string nit)
    {
        return await _proveedores.Find(p => p.Nit == nit).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Proveedor proveedor)
    {
        await _proveedores.InsertOneAsync(proveedor);
    }

    public async Task UpdateAsync(Proveedor proveedor)
    {
        await _proveedores.ReplaceOneAsync(p => p.Nit == proveedor.Nit, proveedor);
    }

    public async Task DeleteAsync(string nit)
    {
        await _proveedores.DeleteOneAsync(p => p.Nit == nit);
    }

    public async Task<bool> ExistsByNitAsync(string nit)
    {
        return await _proveedores.Find(p => p.Nit == nit).AnyAsync();
    }
}
