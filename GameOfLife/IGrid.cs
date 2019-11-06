namespace GameOfLife
{
    public interface IGrid
    {
        BoundaryLessGrid CreateNextGen();
        string ToString();
        Cell[] GetNeighbours(int x, int y);
        bool IsAlive();

    }
}