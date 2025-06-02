using AutoMapper;
using MediatR;
using TestIndt.Application.Commands.RouteModule.Command;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Commands.RouteModule.Handler
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, ResultType>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public UpdateRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<ResultType> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetByIdAsync(request.Id);
            if (route == null)
                return new ResultType { Success = false, Message = "Rota não encontrada." };

            route.Nome = request.Nome;
            route.Origem = request.Origem;
            route.Destino = request.Destino;
            route.Valor = request.Valor;

            await _routeRepository.UpdateAsync(route, cancellationToken);
            var accountDto = _mapper.Map<RouteDTO>(route);

            return new ResultType { Success = true, Message = "Rota atualizada com sucesso.", Data = route };
        }
    }
}