using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        private readonly ICommunicationOperations _communicationOperations;
        private IGrid _grid;
        private readonly IGameRules _gameRules;


        public Game(ICommunicationOperations communicationOperations, IGrid grid, IGameRules gameRules)
        {
            _communicationOperations = communicationOperations;
            _grid = grid;
            _gameRules = gameRules;
        }

        public void PrintGrid()
        {
            _communicationOperations.Clear();
            _communicationOperations.WriteLine(StringFormatter.Format(_grid));
            
        }
        
        public void Start()
        {
            PrintGrid();
            
            while (_grid.IsAlive())
            {
                Thread.Sleep(1000);
                _grid = _grid.CreateNextGeneration(_gameRules);

                PrintGrid();

            }

        }
    }
}