namespace GameOfLife
{
    public interface IGrid
    {
        BoundaryLessGrid CreateNextGeneration(IGameRules gameRules);
        ReadOnlyCell[,] GetCells();

    }
}