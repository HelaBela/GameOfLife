using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoundaryLessGrid : IGrid
    {
        private readonly Cell[,] _cellsGeneration;
        private readonly MutableCell[,] _mutableCells;
        private readonly IGameRules _gameRules;


        public BoundaryLessGrid(Cell[,] cellsGeneration, MutableCell[,] mutableCells, IGameRules gameRules)
        {
            _cellsGeneration = cellsGeneration;
            _mutableCells = mutableCells;
            _gameRules = gameRules;
        }

        public override string ToString()
        {
            var output = "";

            for (int i = 0; i < _mutableCells.GetLength(0); i++)
            {
                for (int j = 0; j < _mutableCells.GetLength(1); j++)
                {
                    output += $"{_mutableCells[i, j]}";
                }

                output += Environment.NewLine;
            }

            return output;
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

        public Cell[] GetNeighbours(int x, int y)
        {
            var neighbours = new List<Cell>
            {
                _cellsGeneration[x, HandleEdgeIfNeeded(y + 1, 1)],
                _cellsGeneration[HandleEdgeIfNeeded(x + 1, 0), y],
                _cellsGeneration[HandleEdgeIfNeeded(x - 1, 0), y],
                _cellsGeneration[HandleEdgeIfNeeded(x - 1, 0), HandleEdgeIfNeeded(y + 1, 1)],
                _cellsGeneration[HandleEdgeIfNeeded(x - 1, 0), HandleEdgeIfNeeded(y - 1, 1)],
                _cellsGeneration[HandleEdgeIfNeeded(x + 1, 0), HandleEdgeIfNeeded(y - 1, 1)],
                _cellsGeneration[x, HandleEdgeIfNeeded(y - 1, 1)],
                _cellsGeneration[HandleEdgeIfNeeded(x + 1, 0), HandleEdgeIfNeeded(y + 1, 1)]
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
            MutableCell[,] nextGen = Clone(_mutableCells);


            for (int i = 0; i < _cellsGeneration.GetLength(0); i++)
            {
                for (int j = 0; j < _cellsGeneration.GetLength(1); j++)
                {
                    var nextState = _gameRules.GetNextState(GetNeighbours(i, j));
                    if (nextState == State.Alive)
                    {
                        nextGen[i, j].Revive();
                    }
                    else if (nextState == State.Dead)
                    {
                        nextGen[i, j].Kill();
                    }
                }
            }
            
            
            return new BoundaryLessGrid(_cellsGeneration, nextGen, _gameRules);
        }


        private MutableCell[,] Clone(MutableCell[,] existingCells)
        {
            var rows = existingCells.GetLength(0);
            var cols = existingCells.GetLength(1);

            MutableCell[,] clonedCells = new MutableCell[rows, cols];
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