using FluentValidation;
using TestIndt.Application.Queries.RouteModule.Query;

namespace TestIndt.Application.Queries.RouteModule.Validations
{
    public class GetRouteByIdQueryValidator : AbstractValidator<GetRouteByIdQuery>
    {
        public GetRouteByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id deve ser maior que zero.");
        }
    }
}
