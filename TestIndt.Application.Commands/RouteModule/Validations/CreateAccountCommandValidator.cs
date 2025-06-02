using FluentValidation;
using TestIndt.Application.Commands.RouteModule.Command;

namespace TestUCondo.Application.Commands.AccountModule.Validations
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateRouteCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome � obrigat�rio.")
                .MaximumLength(100).WithMessage("Nome deve ter no m�ximo 100 caracteres.");

            RuleFor(x => x.Origem).IsInEnum().WithMessage("Origem � obrigat�rio.");

            RuleFor(x => x.Destino).IsInEnum().WithMessage("Destino � obrigat�rio.");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("Valor � obrigat�rio.");
        }
    }
}