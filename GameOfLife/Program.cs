using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var cellsState = new[,]{{0,0,0,1},{1,1,0,1}, {1, 0, 1, 1},{1, 1,0,0}};
            var gameRules = new GameRules();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules);
            var consoleOperations = new ConsoleOperations();
            

            var game = new Game(consoleOperations, grid);
            game.Start(); 


        }
    }
}