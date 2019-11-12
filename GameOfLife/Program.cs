using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleOperations = new ConsoleOperations();
            var gridProvider = new HardCodedGridProvider();

            var gridState = gridProvider.GetGridState();
            var gameRules = new GameRules();
            var grid = GridFactory.CreateBoundaryLessGrid(gridState);

            var game = new Game(consoleOperations, grid, gameRules);
            game.Start(); 


        }
    }
}