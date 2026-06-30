using MiniRouteOptimizer.Models;

namespace MiniRouteOptimizer.Services;

public sealed class RouteSorter
{
    public IEnumerable<RouteResult> SortByCostThenStops(IEnumerable<RouteResult> routes)
    {
        return routes
            .OrderBy(r => r.TotalCost)
            .ThenBy(r => r.Stops);
    }
}
