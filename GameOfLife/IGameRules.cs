namespace GameOfLife
{
    public interface IGameRules
    {
        State GetNextState(IReadOnlyCell[] neighbours);
    }
}