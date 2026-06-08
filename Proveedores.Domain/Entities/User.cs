using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Proveedores.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Rol { get; set; } = "Admin";
    public bool Activo { get; set; } = true;
}
