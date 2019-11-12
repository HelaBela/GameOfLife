using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoundaryLessGrid :IGrid
    {
        private readonly Cell[,] _cells;
       
        
        public BoundaryLessGrid(Cell[,] cells)
        {
            _cells = cells;
           
        }

        public ReadOnlyCell[,] GetCells()
        {
            
            var readOnlyCells = new ReadOnlyCell[_cells.GetLength(0),_cells.GetLength(1)];
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    readOnlyCells[x, y] =_cells[x, y].GetReadOnlyVersion();
                }
            }

            return readOnlyCells;

        }

        private ReadOnlyCell[] GetNeighbours(int x, int y)
        {
            var neighbours = new List<ReadOnlyCell>
            {
                _cells[x, HandleEdgeIfNeeded(y + 1, 1)].GetReadOnlyVersion(),
                _cells[HandleEdgeIfNeeded(x + 1, 0), y].GetReadOnlyVersion(),
                _cells[HandleEdgeIfNeeded(x - 1, 0), y].GetReadOnlyVersion(),
                _cells[HandleEdgeIfNeeded(x - 1, 0), HandleEdgeIfNeeded(y + 1, 1)].GetReadOnlyVersion(),
                _cells[HandleEdgeIfNeeded(x - 1, 0), HandleEdgeIfNeeded(y - 1, 1)].GetReadOnlyVersion(),
                _cells[HandleEdgeIfNeeded(x + 1, 0), HandleEdgeIfNeeded(y - 1, 1)].GetReadOnlyVersion(),
                _cells[x, HandleEdgeIfNeeded(y - 1, 1)].GetReadOnlyVersion(),
                _cells[HandleEdgeIfNeeded(x + 1, 0), HandleEdgeIfNeeded(y + 1, 1)].GetReadOnlyVersion()
            };
            return neighbours.ToArray();
        }
        

        public BoundaryLessGrid CreateNextGeneration(IGameRules gameRules)
        {
            var nextGen = Clone(_cells);


            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    var currentCellReadonly = _cells[x, y].GetReadOnlyVersion();
                    var nextState = gameRules.GetNextState(currentCellReadonly, GetNeighbours(x, y));
                    if (nextState == CellState.Alive && _cells[x, y].IsDead())
                    {
                        nextGen[x, y].Revive();
                    }
                    else if (nextState == CellState.Dead)
                    {
                        nextGen[x, y].Kill();
                    }
                }
            }


            return new BoundaryLessGrid(nextGen);
        }
        private int HandleEdgeIfNeeded(int position, int dimension)
        {
            var gridHeight = _cells.GetLength(dimension);
            if (position >= gridHeight)
            {
                return 0;
            }

            if (position < 0)
            {
                return gridHeight - 1;
            }

            return position;
        }

        private Cell[,] Clone(Cell[,] existingCells)
        {
            var rows = existingCells.GetLength(0);
            var cols = existingCells.GetLength(1);

            var clonedCells = new Cell[rows, cols];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    var currentGenCell = existingCells[x, y];
                    clonedCells[x, y] = currentGenCell.Clone();
                }
            }

            return clonedCells;
        }
    }
}