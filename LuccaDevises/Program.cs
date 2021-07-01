using LuccaDevises.Services.Converter;
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

        private static int Main(string[] args)
        
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter a file path.");
                Console.WriteLine("Usage: LuccaDevises <file path>");
                return -1;
            }

            try
            {
                string filePath = args[0];
                var luccaContentFactory = serviceProvider.GetService<LuccaContentFactory>();
                var undirectedGraphFactory = serviceProvider.GetService<UndirectedGraphFactory>();
                var dijstraAlgorithm = serviceProvider.GetService<DijstraAlgorithm>();
                var currencyConverter = serviceProvider.GetService<CurrencyConverter>();

                var inputState = luccaContentFactory.Create(filePath);
                var undirectedGraph = undirectedGraphFactory.Create(inputState.ExchangeRates);
                var startVertex = undirectedGraphFactory.CreateVertex(inputState.TransformationGoal.InitialCurrency);
                var endVertex = undirectedGraphFactory.CreateVertex(inputState.TransformationGoal.TargetCurrency);
                var shortestPathResult = dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex);
                var result = currencyConverter.ConvertCurrency(inputState, shortestPathResult.VerticesOrder);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}