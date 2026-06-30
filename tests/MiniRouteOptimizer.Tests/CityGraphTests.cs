using MiniRouteOptimizer.Services;
using Xunit;

namespace MiniRouteOptimizer.Tests;

public sealed class CityGraphTests
{
    [Fact]
    public void AddConnection_ShouldRegisterVerticesAndEdges()
    {
        var graph = new CityGraph();

        graph.AddConnection("A", "B", 7);
        graph.AddConnection("A", "C", 3);

        Assert.Contains("A", graph.GetVertices());
        Assert.Contains("B", graph.GetVertices());
        Assert.Contains("C", graph.GetVertices());
        Assert.Equal(2, graph.GetEdges().Count);
    }

    [Fact]
    public void GetNeighbors_ShouldReturnOnlyOutgoingEdges()
    {
        var graph = new CityGraph();

        graph.AddConnection("A", "B", 7);
        graph.AddConnection("A", "C", 3);
        graph.AddConnection("B", "C", 1);

        var neighbors = graph.GetNeighbors("A");

        Assert.Equal(2, neighbors.Count);
        Assert.Contains(neighbors, edge => edge.From == "A" && edge.To == "B" && edge.Cost == 7);
        Assert.Contains(neighbors, edge => edge.From == "A" && edge.To == "C" && edge.Cost == 3);
    }
}
