using LuccaDevises.Services.Extensions;
using LuccaDevises.Services.Factory;
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
                var inputState = serviceProvider.GetService<LuccaContentFactory>().Create(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}