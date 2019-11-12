namespace GameOfLife
{
    public interface IGameRules
    {
        CellState GetNextState(ReadOnlyCell currentCell, ReadOnlyCell[] neighbours);
        //game should know about game rules , not grid
    }
}