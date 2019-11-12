namespace GameOfLife
{
    public static class GridFactory
    {
        public static IGrid CreateBoundaryLessGrid(int[,] cellsState)
        {
            var rows = cellsState.GetLength(0);
            var columns = cellsState.GetLength(1);
            
            var cells = new Cell[rows, columns];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    CellState aliveOrDead;

                    if (cellsState[x, y] == 1)
                    {
                        aliveOrDead = CellState.Alive;
                    }
                    else
                        aliveOrDead = CellState.Dead;
                    
                    cells[x, y] = new Cell(aliveOrDead);
                }
            }
            return new BoundaryLessGrid(cells);
        }
        
        
    }
}