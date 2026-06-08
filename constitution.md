# Constitution — ProveedoresAPI

**Versión:** 1.0 | **Fecha:** 08/06/2026 | **Tipo:** Brownfield

## Principios

### P-01 — Secretos fuera del código fuente
**Categoría:** Seguridad
**Principio:** Ninguna contraseña, API key, cadena de conexión o JWT secret se escribe en appsettings.json ni en ningún archivo que se suba al repositorio. Todo secreto va en User Secrets (desarrollo) o Variables de entorno (producción).
**Razón:** Un repositorio público con credenciales expuestas permite acceso no autorizado a bases de datos y sistemas externos.

### P-02 — Autenticación JWT obligatoria
**Categoría:** Seguridad
**Principio:** Todo endpoint de negocio requiere token JWT válido con `[Authorize]`. El endpoint de login es la única excepción.
**Razón:** Impide acceso anónimo a datos sensibles.

### P-03 — Contraseñas hasheadas, nunca texto plano
**Categoría:** Seguridad
**Principio:** Ninguna contraseña se almacena o compara en texto plano. Se usa BCrypt con salt para almacenar y verificar credenciales.
**Razón:** Si la base de datos se filtra, las contraseñas no están expuestas.

### P-04 — No exponer detalles internos en errores HTTP
**Categoría:** Seguridad / Resiliencia
**Principio:** En producción, las respuestas de error devuelven solo mensaje genérico. Los detalles técnicos se escriben en log interno pero nunca en la respuesta HTTP.
**Razón:** Los stack traces y mensajes de error revelan estructura interna de la aplicación.

### P-05 — Rate limiting en autenticación
**Categoría:** Seguridad
**Principio:** El endpoint de login tiene límite de intentos por IP para prevenir ataques de fuerza bruta.
**Razón:** Previene ataques automatizados contra el login.

### P-06 — Entrada validada antes de procesar
**Categoría:** Seguridad / Calidad
**Principio:** Todo comando y query pasa por FluentValidation antes de llegar al handler. No se confía en la validación del cliente.
**Razón:** Previene inyección de datos maliciosos o malformados.

## Stack y restricciones técnicas fijas
- Lenguaje/framework: C# .NET 8
- Arquitectura: Clean Architecture (Domain → Application → Infrastructure → Api)
- Patrón: CQRS con MediatR + Repository
- Base de datos: MongoDB (MongoDB.Driver)
- Autenticación: JWT Bearer (HMAC-SHA256)
- Validación: FluentValidation + ValidationBehavior pipeline
- Contenedorización: Docker + Docker Compose

## Gobernanza
- Los principios son no negociables. Violación → ajustar el artefacto, no el principio.
- Actualización: solo mediante re-ejecución explícita de esta skill.
- Toda fase posterior lee este documento al arrancar.
