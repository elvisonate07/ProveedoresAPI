using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proveedores.Domain.Entities
{
    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string Id { get; set; } = string.Empty;

        public string Nit { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad {  get; set; } = string.Empty;
        public string Departamento {  get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion {  get; set; } = DateTime.UtcNow;
        public string NombreContacto {  get; set; } = string.Empty;
        public string CorreoContacto { get; set; } = string.Empty;
    }
}
