using LuccaDevises.Services.Converter;
using LuccaDevises.Services.Factory;
using LuccaDevises.Services.RouteFinder;
using Microsoft.Extensions.Logging;

namespace LuccaDevises.Services.Facade
{
    public class CurrencyFacade
    {
        private readonly LuccaContentFactory luccaContentFactory;
        private readonly UndirectedGraphFactory undirectedGraphFactory;
        private readonly DijstraAlgorithm dijstraAlgorithm;
        private readonly CurrencyConverter currencyConverter;

        public CurrencyFacade(LuccaContentFactory luccaContentFactory, UndirectedGraphFactory undirectedGraphFactory, DijstraAlgorithm dijstraAlgorithm, CurrencyConverter currencyConverter)
        {
            this.luccaContentFactory = luccaContentFactory;
            this.undirectedGraphFactory = undirectedGraphFactory;
            this.dijstraAlgorithm = dijstraAlgorithm;
            this.currencyConverter = currencyConverter;
        }

        public int ConvertCurrency(string filePath)
        {
            var inputState = luccaContentFactory.Create(filePath);
            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(inputState.ExchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex(inputState.TransformationGoal.InitialCurrency);
            var endVertex = undirectedGraphFactory.CreateVertex(inputState.TransformationGoal.TargetCurrency);
            var shortestPathResult = dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex);
            var result = currencyConverter.ConvertCurrency(inputState.TransformationGoal.InitialAmount, inputState.ExchangeRates, shortestPathResult.VerticesOrder);
            return result;
        }
    }
}