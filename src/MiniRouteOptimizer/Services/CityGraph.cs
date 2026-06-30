using MiniRouteOptimizer.Models;

namespace MiniRouteOptimizer.Services;

public sealed class CityGraph
{
    private readonly Dictionary<string, List<Edge>> _adjacency = new();

    public void AddConnection(string from, string to, int cost)
    {
        if (cost < 0)
            throw new ArgumentException("Custo não pode ser negativo.", nameof(cost));

        if (!_adjacency.ContainsKey(from))
            _adjacency[from] = new List<Edge>();

        if (!_adjacency.ContainsKey(to))
            _adjacency[to] = new List<Edge>();

        _adjacency[from].Add(new Edge(from, to, cost));
    }

    public IReadOnlyCollection<string> GetVertices() =>
        _adjacency.Keys.ToList().AsReadOnly();

    public IReadOnlyCollection<Edge> GetEdges() =>
        _adjacency.Values.SelectMany(edges => edges).ToList().AsReadOnly();

    public IReadOnlyCollection<Edge> GetNeighbors(string vertex)
    {
        if (!_adjacency.TryGetValue(vertex, out var edges))
            return Array.Empty<Edge>();

        return edges.AsReadOnly();
    }
}
