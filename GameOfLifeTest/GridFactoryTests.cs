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
            var cellsState = new[,] {{0, 0, 0, 1}, {1, 1, 0, 1}, {1, 0, 1, 1}, {1, 1, 0, 0}};

            //act

            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, new GameRules());


            //assert
            Assert.IsNotNull(grid);
        }
    }
}