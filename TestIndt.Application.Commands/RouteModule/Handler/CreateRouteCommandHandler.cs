using AutoMapper;
using MediatR;
using TestIndt.Application.Commands.RouteModule.Command;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Domain.Entities;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Commands.RouteModule.Handler
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, ResultType>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public CreateRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<ResultType> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            if (request.Origem.Equals(request.Destino))
                return ResultType.ErrorResult(String.Format("Origem {0} não pode ser igual ao destino {1}.", request.Origem, request.Destino));

            var existeRota = await _routeRepository.GetAsync(a =>
                a.Origem == request.Origem &&
                a.Destino == request.Destino
            , cancellationToken);

            if (existeRota != null)
                return ResultType.ErrorResult(String.Format("Já existe uma rota de {0} para {1}.", request.Origem, request.Destino));

            var route = new Route
            {
                Nome = request.Nome,
                Origem = request.Origem,
                Destino = request.Destino,
                Valor = request.Valor
            };

            await _routeRepository.AddAsync(route, cancellationToken);

            var accountDto = _mapper.Map<RouteDTO>(route);

            return ResultType.SuccessResult("Rota criada com sucesso.", accountDto);
        }
    }
}