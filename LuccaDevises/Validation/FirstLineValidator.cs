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
            return false;
        }
    }
}