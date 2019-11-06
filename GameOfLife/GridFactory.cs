namespace GameOfLife
{
    public static class GridFactory
    {
        public static IGrid CreateBoundaryLessGrid(int[,] cellsState, IGameRules gameRules)
        {
            var rows = cellsState.GetLength(0);
            var columns = cellsState.GetLength(1);
            
            var cells = new Cell[rows, columns];
            var mutableCells = new MutableCell[rows, columns];
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

                    mutableCells[i, j] = new MutableCell(aliveOrDead);
                    cells[i, j] = new Cell(mutableCells[i, j]);
                }
            }
            return new BoundaryLessGrid(cells, mutableCells, gameRules);
        }
        
        
    }
}