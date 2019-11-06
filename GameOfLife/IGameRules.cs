namespace GameOfLife
{
    public interface IGameRules
    {
        State GetNextState(Cell[] neighbours);
    }
}