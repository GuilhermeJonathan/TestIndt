using TestIndt.Application.CrossCutting.Enum;
using TestIndt.Domain.Entities;

namespace TestIndt.Domain.Services
{
    public interface IRouteService
    {
        List<Route> FindBestRoute(List<Route> routes, RotaEnum origem, RotaEnum destino);
    }
}
