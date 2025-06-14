﻿using TestIndt.Domain.Entities;

namespace TestIndt.Domain.Entities.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user, CancellationToken cancellationToken = default);
        Task DeleteAsync(User user, CancellationToken cancellationToken = default);

        Task<(IEnumerable<User> Users, int TotalCount)> GetPaginatedAsync(
            int page, int pageSize, string? search, CancellationToken cancellationToken);
        Task UpdateAsync(User entity, CancellationToken cancellationToken = default);
    }
}
