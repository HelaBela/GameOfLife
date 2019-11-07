namespace GameOfLife
{
    public class ReadOnlyCell
    {
        private readonly State _cellState;

        public ReadOnlyCell(State cellState)
        {
            _cellState = cellState;
        }

        public bool IsAlive()
        {
            return _cellState == State.Alive;
        }

        public bool IsDead()
        {
            return !IsAlive();
        }
    }
}