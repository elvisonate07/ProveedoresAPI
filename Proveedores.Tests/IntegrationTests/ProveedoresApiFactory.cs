using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Testcontainers.MongoDb;


namespace Proveedores.Tests.IntegrationTests;

public class ProveedoresApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDb = new MongoDbBuilder()
        .WithImage("mongo:6")
        .Build();

    public string ConnectionString => _mongoDb.GetConnectionString();

    public async Task InitializeAsync()
    {
        await _mongoDb.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _mongoDb.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:MongoDb"] = ConnectionString,
                ["MongoDb:DatabaseName"] = "TestDB",
                ["Jwt:Key"] = "EstaEsUnaLlaveSuperSecretaDe128Bits!",
                ["Jwt:Issuer"] = "Test",
                ["Jwt:Audience"] = "Test"
            });
        });
    }
}
