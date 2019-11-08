namespace GameOfLife
{
    public class ReadOnlyCell
    {
        private readonly CellState _cellCellState;

        public ReadOnlyCell(CellState cellCellState)
        {
            _cellCellState = cellCellState;
        }

        public bool IsAlive()
        {
            return _cellCellState == CellState.Alive;
        }

        public bool IsDead()
        {
            return !IsAlive();
        }
    }
}