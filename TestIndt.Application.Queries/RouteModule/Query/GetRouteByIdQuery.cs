using MediatR;
using TestIndt.Application.CrossCutting.DTO.Routes;

namespace TestIndt.Application.Queries.RouteModule.Query
{
    public class GetRouteByIdQuery : IRequest<RouteDTO?>
    {
        public int Id { get; set; }
    }
}