using MediatR;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.CrossCutting.DTO.Routes;

namespace TestIndt.Application.Queries.RouteModule.Query
{
    public class GetRoutesPaginateQuery : IRequest<PaginatedResultDto<RouteDTO>>
    {
        public int Page { get; }
        public int PageSize { get; }
        public string? Search { get; }

        public GetRoutesPaginateQuery(int page, int pageSize, string? search)
        {
            Page = page;
            PageSize = pageSize;
            Search = search;
        }
    }
}