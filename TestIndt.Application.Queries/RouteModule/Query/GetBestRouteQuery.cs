using MediatR;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Application.CrossCutting.Enum;

namespace TestIndt.Application.Queries.RouteModule.Query
{
    public class GetBestRouteQuery : IRequest<ResultType>
    {
        public RotaEnum Origem { get; set; }
        public RotaEnum Destino { get; set; }
    }
}