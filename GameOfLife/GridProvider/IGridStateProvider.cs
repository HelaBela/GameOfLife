namespace GameOfLife
{
    public interface IGridStateProvider
    {
         int[,] GetGridState();
    }
}