using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private readonly ICommunicationOperations _communicationOperations;
        private IGrid _grid;

        public Game(ICommunicationOperations communicationOperations, IGrid grid)
        {
            _communicationOperations = communicationOperations;
            _grid = grid;
        }

        public void PrintGrid()
        {
           // _consoleOperations.Clear();
            _communicationOperations.WriteLine(_grid.ToString());
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