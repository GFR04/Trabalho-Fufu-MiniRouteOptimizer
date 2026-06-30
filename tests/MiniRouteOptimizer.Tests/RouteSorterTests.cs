using MiniRouteOptimizer.Models;
using MiniRouteOptimizer.Services;
using Xunit;

namespace MiniRouteOptimizer.Tests;

public sealed class RouteSorterTests
{
    [Fact]
    public void SortByCostThenStops_ShouldOrderByCostFirst()
    {
        var routes = new[]
        {
            new RouteResult(new[] { "A", "B", "C" }, 12),
            new RouteResult(new[] { "A", "D" }, 5),
            new RouteResult(new[] { "A", "E", "F" }, 8)
        };

        var ordered = new RouteSorter().SortByCostThenStops(routes).ToList();

        Assert.Equal(5, ordered[0].TotalCost);
        Assert.Equal(8, ordered[1].TotalCost);
        Assert.Equal(12, ordered[2].TotalCost);
    }

    [Fact]
    public void SortByCostThenStops_WhenCostTies_ShouldOrderByFewerStops()
    {
        var routes = new[]
        {
            new RouteResult(new[] { "A", "B", "C", "D" }, 10),
            new RouteResult(new[] { "A", "E", "D" }, 10),
            new RouteResult(new[] { "A", "F", "G", "H", "D" }, 10)
        };

        var ordered = new RouteSorter().SortByCostThenStops(routes).ToList();

        Assert.Equal(new[] { "A", "E", "D" }, ordered[0].Path);
        Assert.Equal(new[] { "A", "B", "C", "D" }, ordered[1].Path);
        Assert.Equal(new[] { "A", "F", "G", "H", "D" }, ordered[2].Path);
    }
}
