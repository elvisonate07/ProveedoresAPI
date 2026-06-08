using MongoDB.Driver;
using Proveedores.Domain.Entities;

namespace Proveedores.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Proveedor> Proveedores =>
        _database.GetCollection<Proveedor>("Proveedores");

    public IMongoCollection<User> Users =>
        _database.GetCollection<User>("Users");
}
