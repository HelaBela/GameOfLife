namespace GameOfLife
{
    public class Cell
    {
        private readonly MutableCell _mutableCell;

        public Cell(MutableCell mutableCell)
        {
            _mutableCell = mutableCell;
        }

       
        public bool IsAlive()
        {
            return _mutableCell.CellState == State.Alive;
        }

        public bool IsDead()
        {
            return !IsAlive();
        }
        
    }
}