using FluentValidation;
using Proveedores.Application.Features.Proveedores.Commands;

namespace Proveedores.Application.Features.Proveedores.Validators;

public class UpdateProveedorCommandValidator : AbstractValidator<UpdateProveedorCommand>
{
    public UpdateProveedorCommandValidator()
    {
        RuleFor(p => p.Nit)
            .NotEmpty().WithMessage("El NIT es requerido");

        RuleFor(p => p.RazonSocial)
            .NotEmpty().WithMessage("La razón social es requerida")
            .MaximumLength(200).WithMessage("Máximo 200 caracteres");

        RuleFor(p => p.Correo)
            .NotEmpty().WithMessage("El correo es requerido")
            .EmailAddress().WithMessage("Correo inválido");
    }
}
