namespace MiniRouteOptimizer.Services;

public static class SampleGraphFactory
{
    public static CityGraph Create()
    {
        var graph = new CityGraph();

        graph.AddConnection("Centro", "Bairro A", 4);
        graph.AddConnection("Centro", "Bairro B", 2);
        graph.AddConnection("Bairro A", "Bairro C", 5);
        graph.AddConnection("Bairro B", "Bairro A", 1);
        graph.AddConnection("Bairro B", "Bairro C", 8);
        graph.AddConnection("Bairro B", "Bairro D", 10);
        graph.AddConnection("Bairro C", "Bairro D", 2);
        graph.AddConnection("Bairro D", "Cliente", 3);
        graph.AddConnection("Bairro C", "Cliente", 6);

        return graph;
    }
}
