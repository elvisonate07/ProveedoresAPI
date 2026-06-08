using Proveedores.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores.Application.Common.Interfaces
{
    public interface IJwtService
    {
        LoginResponseDto GenerateToken(string correo, string rol);
    }
}
