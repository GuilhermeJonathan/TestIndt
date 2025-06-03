using Moq;
using TestIndt.Application.CrossCutting.Enum;
using TestIndt.Domain.Entities;
using TestIndt.Domain.Entities.Repositories;
using TestIndt.Domain.Services;

namespace TestIndt.Test
{
    public class RouteServiceTests
    {
        [Fact]
        public async Task Should_Search_Route_By_Id()
        {
            // Arrange
            var mockRepo = new Mock<IRouteRepository>();
            var route = new Route { Id = 1, Nome = "Rota A" };
            mockRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(route);
            var result = await mockRepo.Object.GetByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Rota A", result.Nome);
        }

        [Fact]
        public async Task Should_Create_Route()
        {
            // Arrange
            var mockRepo = new Mock<IRouteRepository>();
            var route = new Route { Nome = "Nova Rota" };

            mockRepo
                .Setup(r => r.AddAsync(It.IsAny<Route>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Route r, CancellationToken _) => { r.Id = 2; return r; });

            // Act
            var result = await mockRepo.Object.AddAsync(route, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Id);
            Assert.Equal("Nova Rota", result.Nome);
        }

        [Fact]
        public async Task Should_Find_Best_Route()
        {
            // Arrange
            var mockRepo = new Mock<IRouteRepository>();
            var routes = new List<Route>
                {
                    new Route { Id = 1, Nome = "A", Origem = RotaEnum.GRU, Destino = RotaEnum.BRC, Valor = 20 },
                    new Route { Id = 2, Nome = "B", Origem = RotaEnum.BRC, Destino = RotaEnum.SCL, Valor = 5 }                    
                };
            
            mockRepo.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(routes);
            var service = new RouteService();

            // Act            
            var bestRoute = service.FindBestRoute(routes, RotaEnum.GRU, RotaEnum.SCL);

            // Assert
            Assert.NotNull(bestRoute);
            Assert.Equal(25, bestRoute.Sum(r => r.Valor));
        }
    }
}