using LuccaDevises.Domain.Input;
using LuccaDevises.Services.Parser;
using LuccaDevises.Services.Wrapper;
using System;
using System.IO;
using System.Linq;

namespace LuccaDevises.Services.Factory
{
    public class LuccaContentFactory
    {
        private readonly IContentParser contentParser;
        private readonly IFileWrapper fileWrapper;

        public LuccaContentFactory(IContentParser contentParser, IFileWrapper fileWrapper)
        {
            this.contentParser = contentParser;
            this.fileWrapper = fileWrapper;
        }

        public InputState Create(string filePath)
        {
            if (fileWrapper.Exists(filePath))
            {
                var inputFile = fileWrapper.ReadAllText(filePath)
                                    .Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

                return contentParser.Parse(inputFile);
            }
            else
            {
                throw new ArgumentException($"File {filePath} does not exists.");
            }
        }
    }
}