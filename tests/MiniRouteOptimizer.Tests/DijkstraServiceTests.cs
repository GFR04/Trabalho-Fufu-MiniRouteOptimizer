using MiniRouteOptimizer.Services;
using Xunit;

namespace MiniRouteOptimizer.Tests;

public sealed class DijkstraServiceTests
{
    [Fact]
    public void FindShortestPath_ShouldReturnExpectedRouteFromCentroToCliente()
    {
        var graph = SampleGraphFactory.Create();
        var service = new DijkstraService();

        var result = service.FindShortestPath(graph, "Centro", "Cliente");

        Assert.Equal(13, result.TotalCost);
        Assert.Equal(new[] { "Centro", "Bairro B", "Bairro A", "Bairro C", "Bairro D", "Cliente" }, result.Path);
    }

    [Fact]
    public void FindShortestPath_WhenThereIsNoRoute_ShouldReturnEmptyPathAndMaxCost()
    {
        var graph = new CityGraph();
        graph.AddConnection("A", "B", 1);
        graph.AddConnection("C", "D", 1);
        var service = new DijkstraService();

        var result = service.FindShortestPath(graph, "A", "D");

        Assert.Empty(result.Path);
        Assert.Equal(int.MaxValue, result.TotalCost);
    }
}
