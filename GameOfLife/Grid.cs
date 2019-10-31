using System;

namespace GameOfLife
{
    public class Grid
    {
        private Cell[,] _cells;
        private IConsoleOperations _consoleOperations;

        public Grid(Cell[,] cells, IConsoleOperations consoleOperations)
        {
            _cells = cells;
            _consoleOperations = consoleOperations;
        }

        public void DisplayGrid()
        {
            var output = "";
            
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    output += $"{_cells[i, j]}";
                    //_consoleOperations.Write($"{_cells[i, j]}");
                }

                output += Environment.NewLine;
                //_consoleOperations.WriteLine("");
            }

            _consoleOperations.WriteLine(output);
        }

        private void FindCellNeighbours()
        {
            
        }
    }
}