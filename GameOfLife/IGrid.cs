namespace GameOfLife
{
    public interface IGrid
    {
        BoundaryLessGrid CreateNextGen();
        string ToString();
        ReadOnlyCell[] GetNeighbours(int x, int y);
        bool IsAlive();

    }
}