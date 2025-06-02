using FluentValidation;
using TestIndt.Application.Commands.RouteModule.Command;

namespace TestIndt.Application.Commands.RouteModule.Validations
{
    public class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommand>
    {
        public DeleteRouteCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Route Id must be greater than zero.");
        }
    }
}   