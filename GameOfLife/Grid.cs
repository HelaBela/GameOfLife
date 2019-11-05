using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid:IGrid
    {
        private Cell[,] _cellsGeneration;
        private IConsoleOperations _consoleOperations;

        public Grid(Cell[,] cellsGeneration, IConsoleOperations consoleOperations)
        {
            _cellsGeneration = cellsGeneration;
            _consoleOperations = consoleOperations;
        }
        
        
        public string ToString()
        {
            throw new NotImplementedException();
        }

        public void DisplayGrid()
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

            _consoleOperations.WriteLine(output);
        }


        private int ProcessXDimention(int x)
        {
            var cellHeight = _cellsGeneration.GetLength(0);
            if (x >= cellHeight)
            {
                return 0;
            }

            if (x < 0)
            {
                return cellHeight - 1;
            }

            return x;
        }

        private int ProcessYDimention(int y)
        {
            var cellWidth = _cellsGeneration.GetLength(1);
            if (y >= cellWidth)
            {
                return 0;
            }

            if (y < 0)
            {
                return cellWidth - 1;
            }

            return y;
        }


        public int GetNumberOfAliveNeighbours(int i, int j)
        {
            i = ProcessXDimention(i);

            j = ProcessYDimention(j);

            int NumOfAliveNeighbors = 0;


            if (_cellsGeneration[i, ProcessYDimention(j + 1)].IsAlive())
                NumOfAliveNeighbors++;

            if (_cellsGeneration[ProcessXDimention(i + 1), j].IsAlive())
                NumOfAliveNeighbors++;


            if (_cellsGeneration[ProcessXDimention(i - 1), j].IsAlive())
                NumOfAliveNeighbors++;
            if (_cellsGeneration[ProcessXDimention(i - 1), ProcessYDimention(j + 1)].IsAlive())
                NumOfAliveNeighbors++;


            if (_cellsGeneration[ProcessXDimention(i - 1), ProcessYDimention(j - 1)].IsAlive())
                NumOfAliveNeighbors++;


            if (_cellsGeneration[ProcessXDimention(i + 1), ProcessYDimention(j - 1)].IsAlive())
                NumOfAliveNeighbors++;
            if (_cellsGeneration[i, ProcessYDimention(j - 1)].IsAlive())
                NumOfAliveNeighbors++;


            if (_cellsGeneration[ProcessXDimention(i + 1), ProcessYDimention(j + 1)].IsAlive())
                NumOfAliveNeighbors++;


            return NumOfAliveNeighbors;
        }

        private Cell[,] Clone(Cell[,] existingCells)
        {
            var rows = existingCells.GetLength(0);
            var cols = existingCells.GetLength(1);
            
            Cell[,] clonedCells = new Cell[rows, cols];
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

        public Grid CreateNexGen()
        {
            Cell[,] nextGen = Clone(_cellsGeneration);
            

            for (int i = 0; i < _cellsGeneration.GetLength(0); i++)
            {
                for (int j = 0; j < _cellsGeneration.GetLength(1); j++)
                {
                    var currentGenCell = _cellsGeneration[i, j];
                    var aliveNeighbours = GetNumberOfAliveNeighbours(i, j);
                    if (currentGenCell.IsAlive())
                    {
                        if (aliveNeighbours < 2)
                        {
                            nextGen[i, j].Kill(this);
                        }
                        else if (aliveNeighbours == 2 || aliveNeighbours == 3)
                        {
                            nextGen[i, j].Revive(this);
                        }
                        else if (aliveNeighbours > 3)
                        {
                            nextGen[i, j].Kill(this);
                        }
                    }

                    else if (!currentGenCell.IsAlive() && aliveNeighbours == 3)
                    {
                        nextGen[i, j].Revive(this);
                    }
                }
            }

            return new Grid(nextGen, _consoleOperations);
        }

        public bool IsCellAliveAt(int x, int y)
        {
            return _cellsGeneration[x, y].IsAlive();
        }

        public bool Contains(Cell cell)
        {
            var rows = _cellsGeneration.GetLength(0);
            var cols = _cellsGeneration.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (_cellsGeneration[i, j] == cell)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetNeigbours()
        {
            throw new NotImplementedException();
        }

        public void CreateNextGeneration()
        {
            throw new NotImplementedException();
        }
        
    
    }
}