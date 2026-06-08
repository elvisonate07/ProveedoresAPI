using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Proveedores.Application.DTOs;

namespace Proveedores.Application.Features.Proveedores.Commands
{
    public class CreateProveedorCommand : IRequest<ProveedorDto>
    {
        public string Nit { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string NombreContacto { get; set; } = string.Empty;
        public string CorreoContacto { get; set; } = string.Empty;
    }
}
