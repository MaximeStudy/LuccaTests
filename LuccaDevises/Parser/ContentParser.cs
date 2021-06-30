using System;
using System.Collections.Generic;

namespace LuccaDevises.Parser
{
    public class ContentParser
    {
        public bool IsValid(List<string> fileContent)
        {
            if (fileContent.Count <= 2)
            {
                return false;
            }
            var firstLineValidator = new FirstLineParser();
            var secondLineValidator = new SecondLineParser();
            if (firstLineValidator.IsValid(fileContent[0]) && secondLineValidator.IsValid(fileContent[1]))
            {
                var numberOfExchangeRate = int.Parse(fileContent[1]);
                if (fileContent.Count != numberOfExchangeRate + 2)
                {
                    return false;
                }
                for (int i = 2; i < fileContent.Count; i++)
                {
                    var nthLineValidator = new NthLineParser();
                    if (!nthLineValidator.IsValid(fileContent[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}