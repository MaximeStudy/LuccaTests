using LuccaDevises.Domain;
using LuccaDevises.Services.Parser;
using System;
using System.IO;
using System.Linq;

namespace LuccaDevises.Services.Factory
{
    public class LuccaContentFactory
    {
        private readonly ContentParser contentParser;

        public LuccaContentFactory(ContentParser contentParser)
        {
            this.contentParser = contentParser;
        }

        public InputState Create(string filePath)
        {
            if (File.Exists(filePath))
            {
                var inputFile = File.ReadAllText(filePath)
                                    .Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

                return contentParser.Parse(inputFile); ;
            }
            else
            {
                throw new ArgumentException($"File {filePath} does not exists.");
            }
        }
    }
}