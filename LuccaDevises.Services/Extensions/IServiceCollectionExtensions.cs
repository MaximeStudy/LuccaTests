using LuccaDevises.Services.Converter;
using LuccaDevises.Services.Facade;
using LuccaDevises.Services.Factory;
using LuccaDevises.Services.Parser;
using LuccaDevises.Services.RouteFinder;
using LuccaDevises.Services.Wrapper;
using Microsoft.Extensions.DependencyInjection;

namespace LuccaDevises.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddLuccaCurrencyServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IFileWrapper, FileWrapper>()
                                    .AddSingleton<CurrencyParser, CurrencyParser>()
                                    .AddSingleton<PositiveIntegerParser, PositiveIntegerParser>()
                                    .AddSingleton<ExchangeRateParser, ExchangeRateParser>()
                                    .AddSingleton<FirstLineParser, FirstLineParser>()
                                    .AddSingleton<SecondLineParser, SecondLineParser>()
                                    .AddSingleton<NthLineParser, NthLineParser>()
                                    .AddSingleton<IContentParser, ContentParser>()
                                    .AddSingleton<LuccaContentFactory, LuccaContentFactory>()
                                    .AddSingleton<UndirectedGraphFactory, UndirectedGraphFactory>()
                                    .AddSingleton<DijstraAlgorithm, DijstraAlgorithm>()
                                    .AddSingleton<CurrencyConverter, CurrencyConverter>()
                                    .AddSingleton<CurrencyFacade, CurrencyFacade>();
        }
    }
}