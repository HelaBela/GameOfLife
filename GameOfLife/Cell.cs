namespace GameOfLife
{
    public class Cell
    {
        private State _cellState;

        public Cell(State cellState)
        {
            _cellState = cellState;
        }

        public override string ToString()
        {
            if (_cellState == State.Dead)
                return ".";
            return "*";
        }

        public bool IsAlive()
        {
            return _cellState == State.Alive;
        }

        public Cell Clone()
        {
            return new Cell(_cellState);
        }

        public void Kill(Grid grid)

        {
            if (grid.Contains(this))
                _cellState = State.Dead;
        }

        public void Revive(Grid grid)
        {
            if (grid.Contains(this))
                _cellState = State.Alive;
        }
    }
}