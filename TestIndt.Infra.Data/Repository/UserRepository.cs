using Microsoft.EntityFrameworkCore;
using TestIndt.Domain.Entities;
using TestIndt.Domain.Entities.Repositories;
using TestIndt.Infra.Data.Context;
using TestIndt.Infra.Data.Repository.Base;

namespace TestIndt.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DefaultDbContext _context;

        public UserRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Usuarios.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            _context.Set<User>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Set<User>().Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<(IEnumerable<User> Users, int TotalCount)> GetPaginatedAsync(
            int page, int pageSize, string? search, CancellationToken cancellationToken)
        {
            var query = _context.Set<User>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u => u.Name.Contains(search) || u.Email.Contains(search));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var users = await query
                .OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (users, totalCount);
        }
    }
}
