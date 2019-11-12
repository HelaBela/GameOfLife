using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridTests
{
    public class GridFactoryTests
    {
        [Test]
        public void Can_Create_Grid()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0, 1}, {1, 1, 0, 1}, {1, 0, 1, 1}, {1, 1, 0, 0}};

            //act

            var grid = GridFactory.CreateBoundaryLessGrid(cellsState);


            //assert
            Assert.IsNotNull(grid);
        }
    }
}