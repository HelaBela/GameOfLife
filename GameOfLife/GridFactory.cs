namespace GameOfLife
{
    public class GridFactory
    {
        public static Grid CreateGrid(int[,] cellsState, IConsoleOperations consoleOperations)
        {
            var rows = cellsState.GetLength(0);
            var columns = cellsState.GetLength(1);
            
            var cells = new Cell[cellsState.GetLength(0), cellsState.GetLength(1)];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    State aliveOrDead;

                    if (cellsState[i, j] == 1)
                    {
                        aliveOrDead = State.Alive;
                    }
                    else
                        aliveOrDead = State.Dead;

                    cells[i, j] = new Cell(aliveOrDead);
                }
            }
            return new Grid(cells, consoleOperations);
        }
        
        
    }
}