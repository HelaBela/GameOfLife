namespace GameOfLife
{
    public class Cell:ICell
    {
        private  State _cellState;


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

        public bool IsDead()
        {
            return !IsAlive();
        }
        
        public void Kill()

        {
            _cellState = State.Dead;
        }

        public void Revive()
        {
            _cellState = State.Alive;
        }
        
        public Cell Clone()
        {
            return new Cell(_cellState);
        }
        
    }
}