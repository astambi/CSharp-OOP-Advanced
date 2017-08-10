namespace Demo.Data
{
    public interface IFileProvider
    {
        string ReadAllText(string filePath);

        void WriteAllText(string filePath, string content);
    }
}
