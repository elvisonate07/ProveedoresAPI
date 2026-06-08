using FluentValidation;
using Proveedores.Application.Features.Proveedores.Commands;

namespace Proveedores.Application.Features.Proveedores.Validators;

public class CreateProveedorCommandValidator : AbstractValidator<CreateProveedorCommand>
{
    public CreateProveedorCommandValidator()
    {
        RuleFor(p => p.Nit)
            .NotEmpty().WithMessage("El NIT es requerido");

        RuleFor(p => p.RazonSocial)
            .NotEmpty().WithMessage("La razón social es requerida")
            .MaximumLength(200).WithMessage("Máximo 200 caracteres");

        RuleFor(p => p.Correo)
            .NotEmpty().WithMessage("El correo es requerido")
            .EmailAddress().WithMessage("Correo inválido");

        RuleFor(p => p.CorreoContacto)
            .NotEmpty().WithMessage("El correo de contacto es requerido")
            .EmailAddress().WithMessage("Correo de contacto inválido");
    }
}
