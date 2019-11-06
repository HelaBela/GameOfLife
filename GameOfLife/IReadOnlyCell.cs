namespace GameOfLife
{
    public interface IReadOnlyCell
    {
        bool IsAlive();
        bool IsDead();

    }
}