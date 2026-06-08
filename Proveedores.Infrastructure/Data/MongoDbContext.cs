using System.Net.Security;
using System.Security.Authentication;
using MongoDB.Driver;
using Proveedores.Domain.Entities;

namespace Proveedores.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.SslSettings = new SslSettings
        {
            EnabledSslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13,
            CheckCertificateRevocation = false,
            ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true
        };
        var client = new MongoClient(settings);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Proveedor> Proveedores =>
        _database.GetCollection<Proveedor>("Proveedores");

    public IMongoCollection<User> Users =>
        _database.GetCollection<User>("Users");

    public async Task EnsureIndexesAsync()
    {
        var indexKeys = Builders<Proveedor>.IndexKeys.Ascending(p => p.Nit);
        var indexOptions = new CreateIndexOptions { Unique = true, Name = "NIT_UNIQUE" };
        var indexModel = new CreateIndexModel<Proveedor>(indexKeys, indexOptions);
        try
        {
            await Proveedores.Indexes.CreateOneAsync(indexModel);
        }
        catch
        {
        }
    }
}
