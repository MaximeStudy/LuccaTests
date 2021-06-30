using LuccaDevises.Services.Extensions;
using LuccaDevises.Services.Factory;
using LuccaDevises.Services.RouteFinder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LuccaDevises
{
    internal class Program
    {
        private static readonly ServiceProvider serviceProvider = new ServiceCollection()
                                                                    .AddLuccaDevisesServices()
                                                                    .BuildServiceProvider();

        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter a file path.");
                Console.WriteLine("Usage: LuccaDevises <file path>");
                return;
            }

            try
            {
                string filePath = args[0];
                var luccaContentFactory = serviceProvider.GetService<LuccaContentFactory>();
                var graphFactory = serviceProvider.GetService<GraphFactory>();
                var dijstraAlgorithm = serviceProvider.GetService<DijstraAlgorithm>();

                var inputState = luccaContentFactory.Create(filePath);
                var graph = graphFactory.Create(inputState.ExchangeRates);
                var startVertex = graphFactory.CreateVertex(inputState.TransformationGoal.InitialCurrency);
                var endVertex = graphFactory.CreateVertex(inputState.TransformationGoal.TargetCurrency);
                dijstraAlgorithm.CalculateShortestPath(graph, startVertex, endVertex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}