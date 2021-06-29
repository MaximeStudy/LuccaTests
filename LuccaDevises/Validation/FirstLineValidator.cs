namespace LuccaDevises.Validation
{
    public class FirstLineValidator : IValidator
    {
        private readonly string line;

        public FirstLineValidator(string line)
        {
            this.line = line;
        }

        public bool IsValid()
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                return false;
            }
            return true;
        }
    }
}