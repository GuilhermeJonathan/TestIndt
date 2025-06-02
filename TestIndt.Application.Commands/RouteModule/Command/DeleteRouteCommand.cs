using MediatR;
using TestIndt.Application.CrossCutting.DTO;

namespace TestIndt.Application.Commands.RouteModule.Command
{
    public class DeleteRouteCommand : IRequest<ResultType>
    {
        public int Id { get; set; }
    }
}