using FluentValidation;

namespace CleanArquitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder 50 caracteres");

            RuleFor(p => p.Url)
                .NotNull()
                .NotEmpty().WithMessage("la {Url} no puede estar en blanco");
        }
    }
}
