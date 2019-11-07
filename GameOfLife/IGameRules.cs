namespace GameOfLife
{
    public interface IGameRules
    {
        State GetNextState(ReadOnlyCell currentCell, ReadOnlyCell[] neighbours);
    }
}