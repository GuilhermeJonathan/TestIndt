using FluentValidation;
using TestIndt.Application.Commands.RouteModule.Command;

namespace TestUCondo.Application.Commands.AccountModule.Validations
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateRouteCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Origem).IsInEnum().WithMessage("Origem é obrigatório.");

            RuleFor(x => x.Destino).IsInEnum().WithMessage("Destino é obrigatório.");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("Valor é obrigatório.");
        }
    }
}