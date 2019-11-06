namespace GameOfLife
{
    public interface IGrid
    {
        BoundaryLessGrid CreateNextGen();
        string ToString();
        IReadOnlyCell[] GetNeighbours(int x, int y);
        bool IsAlive();

    }
}