using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var cellsState = new[,]{{0,0,0,1},{1,1,0,1}, {1, 0, 1, 1},{1, 1,0,0}};
            var grid = GridFactory.CreateGrid(cellsState, new ConsoleOperations());

//            var game = new GameOfLife(grid);
//            game.Start(); 


        }
    }
}