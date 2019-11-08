using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleOperations = new ConsoleOperations();
            var random = new RandomNumber();
            var gridProvider = new RandomGridProvider(random);

            var gridState = gridProvider.GetGridState();
            var gameRules = new GameRules();
            var grid = GridFactory.CreateBoundaryLessGrid(gridState, gameRules);

            var game = new Game(consoleOperations, grid);
            game.Start(); 


        }
    }
}