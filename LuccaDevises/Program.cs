using LuccaDevises.Services.Extensions;
using LuccaDevises.Services.Facade;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LuccaDevises
{
    internal class Program
    {
        private static readonly ServiceProvider serviceProvider = new ServiceCollection()
                                                                    .AddLuccaCurrencyServices()
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
                return serviceProvider.GetService<CurrencyFacade>().ConvertCurrency(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}