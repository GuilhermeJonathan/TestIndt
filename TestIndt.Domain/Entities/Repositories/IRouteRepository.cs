namespace TestIndt.Domain.Entities.Repositories
{
    public interface IRouteRepository : IRepository<Route>
    {
        Task AddAsync(Route route, CancellationToken cancellationToken);
        Task<Route?> GetByIdAsync(long Id, CancellationToken cancellationToken = default);

        Task<(IEnumerable<Route> Routes, int TotalCount)> GetPaginatedAsync(
            int page, int pageSize, string? search, CancellationToken cancellationToken);

        Task<IEnumerable<Route>> GetActiveRoutesAsync(CancellationToken cancellationToken);

        Task DeleteAsync(Route route, CancellationToken cancellationToken);
        Task UpdateAsync(Route entity, CancellationToken cancellationToken = default);
    }
}