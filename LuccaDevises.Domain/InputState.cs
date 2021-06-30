using System.Collections.Generic;

namespace LuccaDevises.Domain
{
    public class InputState
    {
        public TransformationGoal TransformationGoal { get; init; }

        public List<ExchangeRate> ExchangeRates { get; init; }
    }
}