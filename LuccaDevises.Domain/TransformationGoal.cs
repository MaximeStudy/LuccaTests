using System;

namespace LuccaDevises.Domain
{
    public class TransformationGoal
    {
        public string InitialCurrency { get; init; }

        public int InitialAmount { get; init; }

        public string TargetCurrency { get; init; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                TransformationGoal transformationGoal = (TransformationGoal)obj;
                return (InitialCurrency == transformationGoal.InitialCurrency) && (InitialAmount == transformationGoal.InitialAmount) && (TargetCurrency == transformationGoal.TargetCurrency);
            }
        }

        public override int GetHashCode()
        {
            return Tuple.Create(InitialCurrency, TargetCurrency, InitialAmount).GetHashCode();
        }
    }
}