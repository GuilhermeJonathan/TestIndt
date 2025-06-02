using MediatR;
using TestIndt.Application.CrossCutting.DTO;
using TestIndt.Application.Queries.UsuarioModule.DTO;

namespace TestIndt.Application.Queries.UsuarioModule.Query
{
    public class GetUsersPaginateQuery : IRequest<PaginatedResultDto<UserQueryDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }

        public GetUsersPaginateQuery(int page, int pageSize, string? search = null)
        {
            Page = page;
            PageSize = pageSize;
            Search = search;
        }
    }
}