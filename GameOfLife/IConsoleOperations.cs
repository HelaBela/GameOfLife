namespace GameOfLife
{
    public interface IConsoleOperations
    {
        void Write(string content);
        
        void WriteLine(string content);
        
        string Read();

        void Clear();
    }
}