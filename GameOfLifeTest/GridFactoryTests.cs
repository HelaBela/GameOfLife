using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridTests
{
    public class GridFactoryTests
    {
         [Test]
        public void CanCreateGrid()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cellsState = new[,]{{0,0,0,1},{1,1,0,1}, {1, 0, 1, 1},{1, 1,0,0}};
           
            //act
           
            var grid = GridFactory.CreateGrid(cellsState, consoleOperations.Object);
            grid.DisplayGrid();


            //assert

            consoleOperations.Verify(
                m => m.WriteLine(It.Is<string>(c => c == "...*\n**.*\n*.**\n**..\n")), Times.Exactly(1));

        }
        
    }
}