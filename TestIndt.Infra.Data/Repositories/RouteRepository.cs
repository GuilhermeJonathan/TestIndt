using Microsoft.EntityFrameworkCore;
using TestIndt.Application.CrossCutting.Enum;
using TestIndt.Domain.Entities;
using TestIndt.Domain.Entities.Repositories;
using TestIndt.Infra.Data.Context;
using TestIndt.Infra.Data.Repository.Base;

namespace TestIndt.Infra.Data.Repositories
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        private readonly DefaultDbContext _context;

        public RouteRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Route?> GetByIdAsync(long Id, CancellationToken cancellationToken = default)
        {
            return await _context.Rotas.FirstOrDefaultAsync(a => a.Id == Id, cancellationToken);
        }

        public async Task AddAsync(Route Route, CancellationToken cancellationToken = default)
        {
            await _context.Rotas.AddAsync(Route, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Route entity, CancellationToken cancellationToken = default)
        {
            _context.Set<Route>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Route route, CancellationToken cancellationToken = default)
        {
            _context.Rotas.Remove(route);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<(IEnumerable<Route> Routes, int TotalCount)> GetPaginatedAsync(
            int page, int pageSize, string? search, CancellationToken cancellationToken)
        {
            var query = _context.Set<Route>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                bool isEnum = Enum.TryParse<RotaEnum>(search, true, out var rotaEnumValue);
                query = query.Where(u => u.Nome.Contains(search) ||
                    (isEnum && (u.Origem == rotaEnumValue || u.Destino == rotaEnumValue))
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var Routes = await query
                .OrderBy(u => u.Nome)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (Routes, totalCount);
        }

        public async Task<IEnumerable<Route>> GetActiveRoutesAsync(CancellationToken cancellationToken)
        {
            return await _context.Rotas
                .Where(r => r.Ativo)
                .ToListAsync(cancellationToken);
        }
    }
}