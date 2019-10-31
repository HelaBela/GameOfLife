namespace GameOfLife
{
    public class Cell
    {
        public State CellState { get; set; }

        public Cell(State cellState)
        {
            CellState = cellState;
        }

        public override string ToString()
        {
            if (CellState == State.Dead)
                return ".";
            return "*";

        }
    }
}