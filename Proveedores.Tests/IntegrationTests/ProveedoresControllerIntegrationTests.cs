using System.Net.Http.Headers;
using System.Net.Http.Json;
using FluentAssertions;
using Proveedores.Application.DTOs;
using Proveedores.Application.Features.Proveedores.Commands;

namespace Proveedores.Tests.IntegrationTests;

public class ProveedoresControllerIntegrationTests : IClassFixture<ProveedoresApiFactory>
{
    private readonly ProveedoresApiFactory _factory;

    public ProveedoresControllerIntegrationTests(ProveedoresApiFactory factory)
    {
        _factory = factory;
    }

    private async Task<string> GetTokenAsync(HttpClient client)
    {
        var login = new LoginRequestDto
        {
            Correo = "admin@test.com",
            Contrasena = "123456"
        };

        var response = await client.PostAsJsonAsync("/api/Auth/login", login);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
        return result!.Token;
    }

    [Fact]
    public async Task CreateProveedor_ShouldReturn201()
    {
        var client = _factory.CreateClient();

        var token = await GetTokenAsync(client);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var command = new CreateProveedorCommand
        {
            Nit = "111111111-1",
            RazonSocial = "Integration Test SAS",
            Direccion = "Calle 100",
            Ciudad = "Bogotá",
            Departamento = "Cundinamarca",
            Correo = "integracion@test.com",
            NombreContacto = "Test",
            CorreoContacto = "test@test.com"
        };

        var response = await client.PostAsJsonAsync("/api/Proveedores", command);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

        var proveedor = await response.Content.ReadFromJsonAsync<ProveedorDto>();
        proveedor.Should().NotBeNull();
        proveedor!.Nit.Should().Be("111111111-1");
    }

    [Fact]
    public async Task GetProveedores_ShouldReturnList()
    {
        var client = _factory.CreateClient();

        var token = await GetTokenAsync(client);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync("/api/Proveedores");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetProveedorByNit_ShouldReturn404_WhenNotExists()
    {
        var client = _factory.CreateClient();

        var token = await GetTokenAsync(client);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync("/api/Proveedores/999999999-9");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }
}
