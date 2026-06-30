# MiniRouteOptimizer

Projeto desenvolvido para a Atividade 02 do 2º Bimestre — Disciplina: Códigos de Alta Performance.

## Descrição

O MiniRouteOptimizer representa uma pequena cidade como um **grafo dirigido ponderado** e realiza:

- **Cadastro de conexões** entre pontos da cidade
- **Cálculo do menor caminho** entre dois pontos usando o algoritmo de Dijkstra com fila de prioridade
- **Tratamento de rotas inexistentes** (retorna caminho vazio e custo `int.MaxValue`)
- **Ordenação de rotas** pelo menor custo total, com desempate pela menor quantidade de paradas

## Conceitos aplicados

| Conceito | Aplicação |
|---|---|
| Grafo dirigido | `CityGraph` com lista de adjacência (`Dictionary<string, List<Edge>>`) |
| Algoritmo de Dijkstra | `DijkstraService.FindShortestPath` com `PriorityQueue<string, int>` |
| Fila de prioridade (Heap) | `PriorityQueue` nativa do .NET 8, implementada internamente como min-heap |
| Ordenação de alta performance | `RouteSorter` usando LINQ `OrderBy().ThenBy()` (TimSort) |

## Como executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)

### Rodar os testes

```bash
dotnet test
```

### Rodar a aplicação de exemplo

```bash
dotnet run --project src/MiniRouteOptimizer
```

## Estrutura do projeto

```
MiniRouteOptimizer/
├── src/MiniRouteOptimizer/
│   ├── Models/
│   │   ├── Edge.cs           # Representa uma aresta do grafo (From, To, Cost)
│   │   └── RouteResult.cs    # Resultado de uma rota (Path, TotalCost, Stops)
│   ├── Services/
│   │   ├── CityGraph.cs      # Grafo da cidade com lista de adjacência
│   │   ├── DijkstraService.cs # Algoritmo de menor caminho
│   │   ├── RouteSorter.cs    # Ordenação de rotas por custo e paradas
│   │   └── SampleGraphFactory.cs # Grafo de exemplo para testes
│   └── Program.cs
└── tests/MiniRouteOptimizer.Tests/
    ├── CityGraphTests.cs
    ├── DijkstraServiceTests.cs
    └── RouteSorterTests.cs
```

## Resultado dos testes

```
Passed!  - Failed: 0, Passed: 6, Skipped: 0, Total: 6
```
