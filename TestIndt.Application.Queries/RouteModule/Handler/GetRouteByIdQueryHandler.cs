using AutoMapper;
using MediatR;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Application.Queries.RouteModule.Query;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Queries.RouteModule.Handler
{
    public class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, RouteDTO?>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetRouteByIdQueryHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<RouteDTO?> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (route == null)
                return null;

            return _mapper.Map<RouteDTO>(route);
        }
    }
}