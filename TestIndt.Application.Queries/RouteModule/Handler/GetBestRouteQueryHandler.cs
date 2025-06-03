using AutoMapper;
using MediatR;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Application.Queries.RouteModule.Query;
using TestIndt.Domain.Entities.Repositories;
using TestIndt.Domain.Services;

namespace TestIndt.Application.Queries.RouteModule.Handler
{
    public class GetBestRouteQueryHandler : IRequestHandler<GetBestRouteQuery, ResultType>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IRouteService _routeService;

        public GetBestRouteQueryHandler(IRouteRepository routeRepository, IMapper mapper, IRouteService routeService)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _routeService = routeService;
        }

        public async Task<ResultType> Handle(GetBestRouteQuery request, CancellationToken cancellationToken)
        {
            var routes = await _routeRepository.GetListAsync(a => a.Ativo, cancellationToken);

            if (routes == null)
                return ResultType.ErrorResult(String.Format("Não existe rotas cadastrada."));

            var bestPath = _routeService.FindBestRoute(routes.ToList(), request.Origem, request.Destino);

            if (bestPath == null || !bestPath.Any())
                return ResultType.ErrorResult($"Rota não encontrada {request.Origem} - {request.Destino}");

            var result = new RouteResponseDTO()
            {
                Rotas = _mapper.Map<IEnumerable<RouteResumeDTO>>(bestPath).ToList(),
                ValorTotal = bestPath.Sum(r => r.Valor)
            };

            return ResultType.SuccessResult("Melhor rota encontrada com sucesso.", result);
        }
    }
}