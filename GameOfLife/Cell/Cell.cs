namespace GameOfLife
{
    public class Cell:ICell
    {
        private  State _cellState;
        private ReadOnlyCell _readOnlyCell;


        public Cell(State cellState)
        {
            _cellState = cellState;
            UpdateReadOnlyCell();
        }

        public override string ToString()
        {
            if (_cellState == State.Dead)
                return ".";
            return "*";
        }

       
        public bool IsAlive()
        {
            return _readOnlyCell.IsAlive();
        }

        public bool IsDead()
        {
            return _readOnlyCell.IsDead();
        }
        
        public void Kill()

        {
            _cellState = State.Dead;
            UpdateReadOnlyCell();
        }


        public void Revive()
        {
            _cellState = State.Alive;
            UpdateReadOnlyCell();
        }
        
        public Cell Clone()
        {
            return new Cell(_cellState);
        }

        public ReadOnlyCell GetReadOnlyVersion()
        {
            return _readOnlyCell;
        }
        private void UpdateReadOnlyCell()
        {
            _readOnlyCell = new ReadOnlyCell(_cellState);
        }
    }
}