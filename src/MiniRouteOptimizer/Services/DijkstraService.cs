using MiniRouteOptimizer.Models;

namespace MiniRouteOptimizer.Services;

public sealed class DijkstraService
{
    public RouteResult FindShortestPath(CityGraph graph, string origin, string destination)
    {
        // dist[v] = menor custo conhecido até v
        var dist = new Dictionary<string, int>();
        // prev[v] = vértice anterior no caminho mínimo
        var prev = new Dictionary<string, string?>();

        foreach (var vertex in graph.GetVertices())
        {
            dist[vertex] = int.MaxValue;
            prev[vertex] = null;
        }

        if (!dist.ContainsKey(origin))
            return new RouteResult(Array.Empty<string>(), int.MaxValue);

        dist[origin] = 0;

        // Fila de prioridade: (custo, vértice)
        var pq = new PriorityQueue<string, int>();
        pq.Enqueue(origin, 0);

        while (pq.Count > 0)
        {
            var current = pq.Dequeue();

            // Se chegamos ao destino, reconstruímos o caminho
            if (current == destination)
                break;

            foreach (var edge in graph.GetNeighbors(current))
            {
                if (dist[current] == int.MaxValue)
                    continue;

                var newCost = dist[current] + edge.Cost;
                if (newCost < dist[edge.To])
                {
                    dist[edge.To] = newCost;
                    prev[edge.To] = current;
                    pq.Enqueue(edge.To, newCost);
                }
            }
        }

        // Se não atingiu o destino
        if (!dist.ContainsKey(destination) || dist[destination] == int.MaxValue)
            return new RouteResult(Array.Empty<string>(), int.MaxValue);

        // Reconstruir caminho
        var path = new List<string>();
        for (var node = destination; node != null; node = prev.GetValueOrDefault(node))
            path.Add(node);

        path.Reverse();

        // Verifica se o caminho realmente começa na origem
        if (path[0] != origin)
            return new RouteResult(Array.Empty<string>(), int.MaxValue);

        return new RouteResult(path.AsReadOnly(), dist[destination]);
    }
}
