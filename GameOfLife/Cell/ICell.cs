namespace GameOfLife
{
    public interface ICell
    {
        bool IsAlive();
        bool IsDead();
        void Kill();
        void Revive();
        Cell Clone();

        ReadOnlyCell GetReadOnlyVersion();
    }
}