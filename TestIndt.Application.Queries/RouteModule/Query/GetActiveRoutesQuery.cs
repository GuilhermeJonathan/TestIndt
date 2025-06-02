using MediatR;
using TestIndt.Application.CrossCutting.DTO.Routes;

namespace TestIndt.Application.Queries.RouteModule.Query
{
    public class GetActiveRoutesQuery : IRequest<IEnumerable<RouteResumeDTO>>
    {

    }
}