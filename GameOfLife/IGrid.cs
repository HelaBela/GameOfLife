namespace GameOfLife
{
    public interface IGrid
    {
        int GetNeigbours();
        void CreateNextGeneration();
        string ToString();
    }
}