namespace GameOfLife
{
    public interface ICell
    {
        bool IsAlive();
        bool IsDead();
        Cell Clone();
        ReadOnlyCell GetReadOnlyVersion();
        void Kill();
        void Revive();
    }
}