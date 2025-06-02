using AutoMapper;
using MediatR;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.DTO.Routes;
using TestIndt.Application.Queries.RouteModule.Query;
using TestIndt.Domain.Entities.Repositories;

namespace TestIndt.Application.Queries.RouteModule.Handler
{
    public class GetRoutesPaginateQueryHandler : IRequestHandler<GetRoutesPaginateQuery, PaginatedResultDto<RouteDTO>>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetRoutesPaginateQueryHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResultDto<RouteDTO>> Handle(GetRoutesPaginateQuery request, CancellationToken cancellationToken)
        {
            var (routes, totalCount) = await _routeRepository.GetPaginatedAsync(
                request.Page, request.PageSize, request.Search, cancellationToken);

            var routeDtos = routes.Select(a => _mapper.Map<RouteDTO>(a));

            return new PaginatedResultDto<RouteDTO>
            {
                Items = routeDtos,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}