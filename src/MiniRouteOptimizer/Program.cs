using MiniRouteOptimizer.Services;

Console.WriteLine("MiniRouteOptimizer");
Console.WriteLine("Complete os TODOs e execute: dotnet test");

var graph = SampleGraphFactory.Create();
var dijkstra = new DijkstraService();
var sorter = new RouteSorter();

try
{
    var route = dijkstra.FindShortestPath(graph, "Centro", "Cliente");
    Console.WriteLine($"Menor caminho: {string.Join(" -> ", route.Path)}");
    Console.WriteLine($"Custo total: {route.TotalCost}");

    var ordered = sorter.SortByCostThenStops(new[] { route }).ToList();
    Console.WriteLine($"Rotas ordenadas: {ordered.Count}");
}
catch (NotImplementedException)
{
    Console.WriteLine("Ainda existem implementações pendentes.");
}
