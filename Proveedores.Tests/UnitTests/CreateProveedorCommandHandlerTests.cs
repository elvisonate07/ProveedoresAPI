using Moq;
using FluentAssertions;
using Proveedores.Application.Features.Proveedores.Commands;
using Proveedores.Domain.Interfaces;
using Proveedores.Domain.Entities;

namespace Proveedores.Tests.UnitTests;

public class CreateProveedorCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateProveedorAndReturnDto()
    {
        // Arrange
        var repoMock = new Mock<IProveedorRepository>();
        repoMock.Setup(r => r.CreateAsync(It.IsAny<Proveedor>()))
                .Returns(Task.CompletedTask);

        var handler = new CreateProveedorCommandHandler(repoMock.Object);
        var command = new CreateProveedorCommand
        {
            Nit = "123456789-0",
            RazonSocial = "Test SAS",
            Direccion = "Calle 1",
            Ciudad = "Bogotá",
            Departamento = "Cundinamarca",
            Correo = "test@test.com",
            NombreContacto = "Juan",
            CorreoContacto = "juan@test.com"
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Nit.Should().Be("123456789-0");
        result.RazonSocial.Should().Be("Test SAS");
        result.Correo.Should().Be("test@test.com");
        result.Activo.Should().BeTrue();
        result.FechaCreacion.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }
}
