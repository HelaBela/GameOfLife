using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private readonly IConsoleOperations _consoleOperations;
        private IGrid _grid;

        public Game(IConsoleOperations consoleOperations, IGrid grid)
        {
            _consoleOperations = consoleOperations;
            _grid = grid;
        }

        public void PrintGrid()
        {
           // _consoleOperations.Clear();
            _consoleOperations.WriteLine(_grid.ToString());
        }

        public void Start()
        {
            PrintGrid();
            while (_grid.IsAlive())
            {
                Thread.Sleep(1000);
                _grid = _grid.CreateNextGen();
                PrintGrid();
            }
        }

    }
}