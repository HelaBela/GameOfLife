namespace GameOfLife
{
    public interface ICell:IReadOnlyCell
    {
        void Kill();
        void Revive();
        Cell Clone();
    }
}