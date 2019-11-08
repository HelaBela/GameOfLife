using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoundaryLessGrid : IGrid
    {
        private readonly Cell[,] _cells;
        private readonly IGameRules _gameRules;
        
        public BoundaryLessGrid(Cell[,] cells, IGameRules gameRules)
        {
            _cells = cells;
            _gameRules = gameRules;
        }

        public override string ToString()
        {
            var output = "";

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    output += $"{_cells[i, j]}";
                }

                output += Environment.NewLine;
            }

            return output;
        }


        public ReadOnlyCell[] GetNeighbours(int x, int y)
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

        public bool IsAlive()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    if (_cells[i, j].IsAlive())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public BoundaryLessGrid CreateNextGeneration()
        {
            var nextGen = Clone(_cells);


            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    var currentCellReadonly = _cells[x, y].GetReadOnlyVersion();
                    var nextState = _gameRules.GetNextState(currentCellReadonly, GetNeighbours(x, y));
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


            return new BoundaryLessGrid(nextGen, _gameRules);
        }
        
        public bool IsCellAliveAt(int x, int y)
        {
            return _cells[x, y].IsAlive();
        }

        public bool IsCellDeadAt(int x, int y)
        {
            return _cells[x, y].IsDead();
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
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var currentGenCell = existingCells[i, j];
                    clonedCells[i, j] = currentGenCell.Clone();
                }
            }

            return clonedCells;
        }
    }
}