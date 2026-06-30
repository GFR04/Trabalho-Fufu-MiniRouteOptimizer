namespace MiniRouteOptimizer.Models;

public sealed record RouteResult(IReadOnlyList<string> Path, int TotalCost)
{
    public int Stops => Math.Max(0, Path.Count - 1);
}
