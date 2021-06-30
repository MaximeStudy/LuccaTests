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
                var graphFactory = serviceProvider.GetService<GraphFactory>();
                var dijstraAlgorithm = serviceProvider.GetService<DijstraAlgorithm>();
                var currencyConverter = serviceProvider.GetService<CurrencyConverter>();

                var inputState = luccaContentFactory.Create(filePath);
                var undirectedGraph = graphFactory.Create(inputState.ExchangeRates);
                var startVertex = graphFactory.CreateVertex(inputState.TransformationGoal.InitialCurrency);
                var endVertex = graphFactory.CreateVertex(inputState.TransformationGoal.TargetCurrency);
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