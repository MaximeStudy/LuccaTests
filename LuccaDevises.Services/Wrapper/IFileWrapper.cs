namespace LuccaDevises.Services.Wrapper
{
    public interface IFileWrapper
    {
        public bool Exists(string path);

        public string ReadAllText(string path);
    }
}