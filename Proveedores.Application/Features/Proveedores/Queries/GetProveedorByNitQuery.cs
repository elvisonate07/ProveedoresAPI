using MediatR;
using Proveedores.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores.Application.Features.Proveedores.Queries
{
    public class GetProveedorByNitQuery : IRequest<ProveedorDto?>
    {
        public string Nit { get; set; }= string.Empty;
    }
}
