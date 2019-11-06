namespace GameOfLife
{
    public static class GridFactory
    {
        public static IGrid CreateBoundaryLessGrid(int[,] cellsState, IGameRules gameRules)
        {
            var rows = cellsState.GetLength(0);
            var columns = cellsState.GetLength(1);
            
            var cells = new Cell[rows, columns];
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
            return new BoundaryLessGrid(cells, gameRules);
        }
        
        
    }
}