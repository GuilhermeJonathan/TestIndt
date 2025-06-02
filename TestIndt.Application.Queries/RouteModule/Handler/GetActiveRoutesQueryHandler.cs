using AutoMapper;
using MediatR;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Application.Queries.RouteModule.Query;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Queries.RouteModule.Handler
{
    public class GetActiveRoutesQueryHandler : IRequestHandler<GetActiveRoutesQuery, IEnumerable<RouteResumeDTO>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetActiveRoutesQueryHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RouteResumeDTO>> Handle(GetActiveRoutesQuery request, CancellationToken cancellationToken)
        {
            var activeRoutes = await _routeRepository.GetActiveRoutesAsync(cancellationToken);
            return _mapper.Map<IEnumerable<RouteResumeDTO>>(activeRoutes);
        }
    }
}