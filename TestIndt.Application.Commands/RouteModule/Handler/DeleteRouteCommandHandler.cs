using MediatR;
using TestIndt.Application.Commands.RouteModule.Command;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Commands.RouteModule.Handler
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, ResultType>
    {
        private readonly IRouteRepository _routeRepository;

        public DeleteRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<ResultType> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetByIdAsync(request.Id);
            if (route == null)
                return new ResultType { Success = false, Message = "Rota não encontrada." };

            await _routeRepository.DeleteAsync(route, cancellationToken);

            return new ResultType { Success = true, Message = "Rota excluída com sucesso." };
        }
    }
}