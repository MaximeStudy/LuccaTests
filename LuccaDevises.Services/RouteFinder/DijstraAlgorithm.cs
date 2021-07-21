using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.RouteFinder;
using System;
using System.Collections.Generic;

namespace LuccaDevises.Services.RouteFinder
{
    public class DijstraAlgorithm
    {
        public ShortestPathResult CalculateShortestPath(UndirectedGraph graph, Vertex startingVertex, Vertex endingVertex)
        {
            //TODO check that startingVertex and endingVertex are in graph
            //Verify O((A+N)logn) O(a+nlogn)
            //TODO Check positive weight for dijstra
            if (startingVertex == endingVertex)
            {
                throw new ArgumentException($"starting vertex {startingVertex} and ending vertex {endingVertex} cannot be the same");
            }
            try
            {
                //https://fr.wikipedia.org/wiki/Algorithme_de_Dijkstra
                Dictionary<Vertex, int> distancePerVertex = new();
                Dictionary<Vertex, bool> unusedVertex = new();
                Dictionary<Vertex, Dictionary<Vertex, Edge>> neighbors = new();
                Dictionary<Vertex, Vertex> predecessor = new();

                DictionaryInitialization(graph, distancePerVertex, unusedVertex, neighbors);
                if (!distancePerVertex.ContainsKey(startingVertex))
                {
                    throw new ArgumentException($"starting vertex {startingVertex} does not exist in graph");
                }
                if (!distancePerVertex.ContainsKey(endingVertex))
                {
                    throw new ArgumentException($"ending vertex {endingVertex} does not exist in graph");
                }

                distancePerVertex[startingVertex] = 0;

                while (unusedVertex.Count != 0)
                {
                    var currentVertex = ChoseMinimalDistanceVertex(distancePerVertex, unusedVertex); //complexity of algorithm is here
                    unusedVertex.Remove(currentVertex);
                    foreach (var neighbor in neighbors[currentVertex])
                    {
                        //Update distances and predecessor
                        var neighborVertex = neighbor.Key;
                        if (unusedVertex.ContainsKey(neighborVertex))
                        {
                            var weight = neighbor.Value.Weight;
                            if (distancePerVertex[neighborVertex] > (distancePerVertex[currentVertex] + weight))
                            {
                                distancePerVertex[neighborVertex] = distancePerVertex[currentVertex] + weight;
                                predecessor[neighborVertex] = currentVertex;
                            }
                        }
                    }
                }

                ShortestPathResult shortestPathResult = new()
                {
                    Distance = distancePerVertex[endingVertex],
                    VerticesOrder = GetVertexResultPath(startingVertex, endingVertex, predecessor)
                };
                PrintResult(shortestPathResult);
                return shortestPathResult;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Dijstra!");
                throw;
            }
        }

        private static Stack<Vertex> GetVertexResultPath(Vertex startingVertex, Vertex endingVertex, Dictionary<Vertex, Vertex> predecessor)
        {
            var endWhile = false;
            var currentElement = endingVertex;
            var result = new Stack<Vertex>();
            while (!endWhile)
            {
                result.Push(currentElement);
                currentElement = predecessor[currentElement];
                if (currentElement.Equals(startingVertex))
                {
                    result.Push(currentElement);
                    endWhile = true;
                }
            }
            return result;
        }

        private static void PrintResult(ShortestPathResult shortestPathResult)
        {
            var stack = new Stack<Vertex>(shortestPathResult.VerticesOrder);
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Minimal distance : {shortestPathResult.Distance}");
        }

        private static Dictionary<Vertex, Edge> GetNeighbors(Vertex currentVertex, List<Edge> edges)
        {
            Dictionary<Vertex, Edge> neighbors = new();
            foreach (var edge in edges)
            {
                if (edge.VertexOne.Equals(currentVertex))
                {
                    if (!neighbors.ContainsKey(edge.VertexTwo))
                    {
                        neighbors.Add(edge.VertexTwo, edge);
                    }
                }
                else if (edge.VertexTwo.Equals(currentVertex))
                {
                    if (!neighbors.ContainsKey(edge.VertexOne))
                    {
                        neighbors.Add(edge.VertexOne, edge);
                    }
                }
            }
            return neighbors;
        }

        private static void DictionaryInitialization(UndirectedGraph graph, Dictionary<Vertex, int> distancePerVertex, Dictionary<Vertex, bool> unusedVertex, Dictionary<Vertex, Dictionary<Vertex, Edge>> neighbors)
        {
            foreach (var vertex in graph.Vertices)
            {
                distancePerVertex[vertex] = int.MaxValue;
                unusedVertex[vertex] = true;
                neighbors[vertex] = GetNeighbors(vertex, graph.Edges);
            }
        }

        private static Vertex ChoseMinimalDistanceVertex(Dictionary<Vertex, int> distancePerVertex, Dictionary<Vertex, bool> unusedVertex)
        {
            //can be improved by using priority queue
            var minDistance = int.MaxValue;
            Vertex vertex = null;
            foreach (var currentVertex in distancePerVertex.Keys)
            {
                if (unusedVertex.ContainsKey(currentVertex))
                {
                    var currentDistance = distancePerVertex[currentVertex];
                    if (currentDistance <= minDistance)
                    {
                        vertex = currentVertex;
                        minDistance = currentDistance;
                    }
                }
            }
            return vertex;
        }
    }
}