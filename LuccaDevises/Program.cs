using System;
using System.IO;
using System.Linq;

namespace LuccaDevises
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter a file path.");
                Console.WriteLine("Usage: LuccaDevises <file path>");
                return;
            }

            string filePath = args[0];
            if (File.Exists(filePath))
            {
                Console.WriteLine("Ok");
                var inputFile = File.ReadAllText(filePath)
                                    .Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();
            }
            else
            {
                Console.WriteLine($"File {filePath} does not exists.");
            }
        }
    }
}