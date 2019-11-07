namespace GameOfLife
{
    public interface ICommunicationOperations
    {
        void Write(string content);
        
        void WriteLine(string content);
        
        string Read();

        void Clear();
    }
}