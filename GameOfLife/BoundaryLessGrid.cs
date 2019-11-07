using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoundaryLessGrid : IGrid
    {
        private readonly Cell[,] _cellsGeneration;
        private readonly IGameRules _gameRules;


        public BoundaryLessGrid(Cell[,] cellsGeneration, IGameRules gameRules)
        {
            _cellsGeneration = cellsGeneration;
            _gameRules = gameRules;
        }

        public override string ToString()
        {
            var output = "";

            for (int i = 0; i < _cellsGeneration.GetLength(0); i++)
            {
                for (int j = 0; j < _cellsGeneration.GetLength(1); j++)
                {
                    output += $"{_cellsGeneration[i, j]}";
                }

                output += Environment.NewLine;
            }

            return output;
        }



        public ReadOnlyCell[] GetNeighbours(int x, int y)
        {
            var neighbours = new List<ReadOnlyCell>
            {
                _cellsGeneration[x, HandleEdgeIfNeeded(y + 1, 1)].GetReadOnlyVersion(),
                _cellsGeneration[HandleEdgeIfNeeded(x + 1, 0), y].GetReadOnlyVersion(),
                _cellsGeneration[HandleEdgeIfNeeded(x - 1, 0), y].GetReadOnlyVersion(),
                _cellsGeneration[HandleEdgeIfNeeded(x - 1, 0), HandleEdgeIfNeeded(y + 1, 1)].GetReadOnlyVersion(),
                _cellsGeneration[HandleEdgeIfNeeded(x - 1, 0), HandleEdgeIfNeeded(y - 1, 1)].GetReadOnlyVersion(),
                _cellsGeneration[HandleEdgeIfNeeded(x + 1, 0), HandleEdgeIfNeeded(y - 1, 1)].GetReadOnlyVersion(),
                _cellsGeneration[x, HandleEdgeIfNeeded(y - 1, 1)].GetReadOnlyVersion(),
                _cellsGeneration[HandleEdgeIfNeeded(x + 1, 0), HandleEdgeIfNeeded(y + 1, 1)].GetReadOnlyVersion()
            };
            return neighbours.ToArray();
        }

        public bool IsAlive()
        {
            for (int i = 0; i < _cellsGeneration.GetLength(0); i++)
            {
                for (int j = 0; j < _cellsGeneration.GetLength(1); j++)
                {
                    if (_cellsGeneration[i, j].IsAlive())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public BoundaryLessGrid CreateNextGen()
        {
           var nextGen = Clone(_cellsGeneration);


            for (int x = 0; x < _cellsGeneration.GetLength(0); x++)
            {
                for (int y = 0; y < _cellsGeneration.GetLength(1); y++)
                {
                    var currentCellReadonly = _cellsGeneration[x, y].GetReadOnlyVersion();
                    var nextState = _gameRules.GetNextState(currentCellReadonly, GetNeighbours(x, y)); 
                    if (nextState == State.Alive && _cellsGeneration[x,y].IsDead())
                    {
                        nextGen[x, y].Revive();
                    }
                    else if (nextState == State.Dead)
                    {
                        nextGen[x, y].Kill();
                    }
                }
            }
            
            
            return new BoundaryLessGrid(nextGen, _gameRules);
        }

        private int HandleEdgeIfNeeded(int position, int dimension)
        {
            var gridHeight = _cellsGeneration.GetLength(dimension);
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

        public bool IsCellAliveAt(int x, int y)
        {
            return _cellsGeneration[x, y].IsAlive();
        }

        public bool IsCellDeadAt(int x, int y)
        {
            return _cellsGeneration[x, y].IsDead();
        }

       
    }
}