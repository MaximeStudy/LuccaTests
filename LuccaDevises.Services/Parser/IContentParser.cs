using LuccaDevises.Domain.Input;
using System.Collections.Generic;

namespace LuccaDevises.Services.Parser
{
    public interface IContentParser
    {
        public InputState Parse(List<string> fileContent);
    }
}