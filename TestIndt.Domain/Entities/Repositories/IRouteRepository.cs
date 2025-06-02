using System.Threading;
using System.Threading.Tasks;
using TestIndt.Domain.Entities;

namespace TestIndt.Domain.Entities.Repositories
{
    public interface IRouteRepository
    {
        Task AddAsync(Route route, CancellationToken cancellationToken);
        // Add other methods as needed (e.g., GetByIdAsync, UpdateAsync, etc.)
    }
}