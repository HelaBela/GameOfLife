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

        [Test]
        public void CanDisplayGrid()
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

        [Test]
        public void CanFindAliveNeighboursForMiddleCell()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {1, 0, 1}};
            var grid = GridFactory.CreateGrid(cellsState, consoleOperations.Object);


            //act

            var neighbours = grid.GetNumberOfAliveNeighbours(1,1);

            //assert
            Assert.AreEqual(3, neighbours);
        }
        
        [Test]
        public void WhenThereAreNoNeighboursResultIsZero()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cellsState = new[,] {{0, 0, 0}, {0, 1, 0}, {0, 0, 0}};
            var grid = GridFactory.CreateGrid(cellsState, consoleOperations.Object);


            //act

            var neighbours = grid.GetNumberOfAliveNeighbours(1,1);

            //assert
            Assert.AreEqual(0, neighbours);
        }
        
        [Test]
       // [Ignore("for now")]
        public void CellAtPosition00_Has2AliveNeighbours_CozItLeapsToAnotherSide()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cellsState = new[,] {{0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 1, 0, 0}};
            var grid = GridFactory.CreateGrid(cellsState, consoleOperations.Object);


            //act

            var neighbours = grid.GetNumberOfAliveNeighbours(1,1);

            //assert
            Assert.AreEqual(2, neighbours);
        }

        
          
        [Test]
        public void DeadCell_With_3AliveNeigbours_Should_Revive()
        {
            //arrange
            var consoleOperations = new Mock<IConsoleOperations>();
            var cellsState = new[,] {{0, 0, 0}, {1, 0, 0}, {1, 0, 1}};
            var grid = GridFactory.CreateGrid(cellsState, consoleOperations.Object);


            //act

            var nextGenGrid = grid.CreateNexGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellAliveAt(1,1));

        }
    }
}