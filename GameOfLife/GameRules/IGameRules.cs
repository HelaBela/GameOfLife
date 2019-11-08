namespace GameOfLife
{
    public interface IGameRules
    {
        CellState GetNextState(ReadOnlyCell currentCell, ReadOnlyCell[] neighbours);
    }
}