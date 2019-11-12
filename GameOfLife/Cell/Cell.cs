namespace GameOfLife
{
    public class Cell
    {
        private CellState _cellCellState;
        private ReadOnlyCell _readOnlyCell;


        public Cell(CellState cellCellState)
        {
            _cellCellState = cellCellState;
            UpdateReadOnlyCell();
        }
        
        public bool IsAlive()
        {
            return _readOnlyCell.IsAlive();
        }

        public bool IsDead()
        {
            return _readOnlyCell.IsDead();
        }

        public Cell Clone()
        {
            return new Cell(_cellCellState);
        }

        public ReadOnlyCell GetReadOnlyVersion()
        {
            return _readOnlyCell;
        }

        public void Kill()

        {
            _cellCellState = CellState.Dead;
            UpdateReadOnlyCell();
        }


        public void Revive()
        {
            _cellCellState = CellState.Alive;
            UpdateReadOnlyCell();
        }

        private void UpdateReadOnlyCell()
        {
            _readOnlyCell = new ReadOnlyCell(_cellCellState);
        }
    }
}