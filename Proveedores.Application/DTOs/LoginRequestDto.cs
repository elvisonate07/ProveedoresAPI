using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores.Application.DTOs
{
    public class LoginRequestDto
    {
        public string Correo {  get; set; } = string.Empty;
        public string Contrasena {  get; set; } = string.Empty;
    }
}
