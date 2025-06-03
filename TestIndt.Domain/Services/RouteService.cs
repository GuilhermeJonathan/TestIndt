using TestIndt.Application.CrossCutting.Enum;
using TestIndt.Domain.Entities;

namespace TestIndt.Domain.Services
{
    public class RouteService : IRouteService
    {
        public List<Route> FindBestRoute(List<Route> routes, RotaEnum origem, RotaEnum destino)
        {
            var costs = new Dictionary<RotaEnum, decimal>();
            var previous = new Dictionary<RotaEnum, Route>();
            var queue = new PriorityQueue<RotaEnum, decimal>();

            foreach (var route in routes)
            {
                costs[route.Origem] = decimal.MaxValue;
                costs[route.Destino] = decimal.MaxValue;
            }
            costs[origem] = 0;
            queue.Enqueue(origem, 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var route in routes.Where(r => r.Origem == current))
                {
                    var newCost = costs[current] + route.Valor;
                    if (newCost < costs[route.Destino])
                    {
                        costs[route.Destino] = newCost;
                        previous[route.Destino] = route;
                        queue.Enqueue(route.Destino, newCost);
                    }
                }
            }

            var path = new List<Route>();
            var node = destino;
            while (previous.ContainsKey(node))
            {
                var route = previous[node];
                path.Insert(0, route);
                node = route.Origem;
            }

            return path.Any() && path.First().Origem == origem ? path : null;
        }
    }
}
