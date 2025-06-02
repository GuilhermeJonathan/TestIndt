using MediatR;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.Enum;

namespace TestIndt.Application.Commands.RouteModule.Command
{
    public class CreateRouteCommand : IRequest<ResultType>
    {
        public string Nome { get; set; }
        public RotaEnum Origem { get; set; }
        public RotaEnum Destino { get; set; }
        public decimal Valor { get; set; }
    }
}