using LuccaDevises.Services.Extensions;
using LuccaDevises.Services.Factory;
using LuccaDevises.Services.Parser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace LuccaDevises
{
    internal class Program
    {
        private static readonly ServiceProvider serviceProvider = new ServiceCollection()
                                                                    .AddLuccaDevicesServices()
                                                                    .BuildServiceProvider();

        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter a file path.");
                Console.WriteLine("Usage: LuccaDevises <file path>");
                return;
            }

            string filePath = args[0];
            try
            {
                var inputState = serviceProvider.GetService<LuccaContentFactory>().Create(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}