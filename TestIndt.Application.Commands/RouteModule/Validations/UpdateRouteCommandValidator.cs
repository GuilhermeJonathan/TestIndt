using FluentValidation;
using TestIndt.Application.Commands.RouteModule.Command;

namespace TestIndt.Application.Commands.RouteModule.Validations
{
    public class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommand>
    {
        public UpdateRouteCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Origem).IsInEnum();
            RuleFor(x => x.Destino).IsInEnum();
            RuleFor(x => x.Valor).GreaterThanOrEqualTo(0);
            RuleFor(x => x)
                .Must(x => x.Origem != x.Destino)
                .WithMessage("Origem não pode ser igual ao destino.");
        }
    }
}