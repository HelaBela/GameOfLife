using System;
using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridTests
{
    public class GridTests
    {
        [SetUp]
        public void Setup()
        {
            //var consoleOperations = new Mock<IConsoleOperations>(); -> how to set it up here?
        }

        [Test] public void CanDisplayGrid()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cells = new Cell[4, 4];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                    cells[i, j] = new Cell(State.Dead);
            }

            var grid = new Grid(cells, consoleOperations.Object);

            //act
            grid.DisplayGrid();


            //assert

            consoleOperations.Verify(
                m => m.WriteLine(It.Is<string>(c => c == "....\n....\n....\n....\n")), Times.Exactly(1));
          
        }
        
        [Test] public void CanFindOneNeighbour()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cellsState = new[,]{{0,0,0,1},{1,1,0,1}, {1, 0, 1, 1},{1, 1,0,0}};
            var grid = GridFactory.CreateGrid(cellsState, consoleOperations.Object);
         

            //act
      
            
            //assert

           
          
        }
        
       
    }
}