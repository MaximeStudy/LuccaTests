using LuccaDevises.Services.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace LuccaDevises.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddLuccaDevicesServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<CurrencyParser, CurrencyParser>()
                                    .AddSingleton<PositiveIntegerParser, PositiveIntegerParser>()
                                    .AddSingleton<ExchangeRateParser, ExchangeRateParser>()
                                    .AddSingleton<FirstLineParser, FirstLineParser>()
                                    .AddSingleton<SecondLineParser, SecondLineParser>()
                                    .AddSingleton<NthLineParser, NthLineParser>()
                                    .AddSingleton<ContentParser, ContentParser>();
        }
    }
}