namespace GameOfLife
{
    public interface IGrid
    {
        BoundaryLessGrid CreateNextGeneration();
        string ToString();
        ReadOnlyCell[] GetNeighbours(int x, int y);
        bool IsAlive();

    }
}