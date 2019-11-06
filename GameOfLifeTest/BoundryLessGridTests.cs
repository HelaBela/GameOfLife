using System;
using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridFactoryTests
{
    public class BoundryLessGridTests
    {
        private Mock<IConsoleOperations> _consoleOperations;

        [SetUp]
        public void Setup()
        {
            _consoleOperations = new Mock<IConsoleOperations>();
        }

        [Test]
        public void CanDisplayGrid()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);
            
            //act
            
            var strigToTest = grid.ToString();

            //assert
            
            Assert.AreEqual("....\n....\n....\n....\n", strigToTest);
            
        }

        [Test]
        public void CanFind8NeighboursForMiddleCell()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {1, 0, 1}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);


            //act

            var neighbours = grid.GetNeighbours(1,1);
         
            

            //assert
            Assert.AreEqual(8, neighbours.Length);
        }
        
        
        [Test]
        public void CellAtPosition00_Has8Neighbours_CozItLeapsToAnotherSide()
        {
            //arrange
            var cellsState = new[,] {{0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 1, 0, 0}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);


            //act

            var neighbours = grid.GetNeighbours(0,0);
         
            

            //assert
            Assert.AreEqual(8, neighbours.Length);
        }

        
          
        [Test]
        public void DeadCell_With_3AliveNeigbours_Should_Revive_In_NextGeneration()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 0, 0}, {1, 0, 1}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);


            //act

            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellAliveAt(1,1));

        }
        
        [Test]
        public void AliveCell_WillDie_FromOverPopulation()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {1, 1, 1}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);


            //act
            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellDeadAt(1,1));

        }
        
        [Test]
        public void AliveCell_WillRemainAlive_WhenHaving2AliveNeighbours()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {0, 1, 0}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);


            //act

            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellAliveAt(1,1));

        }
        
        [Test]
        public void AliveCell_WillDie_WhenThereIsOneAliveNeighbour()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {0, 0, 0}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);


            //act

            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellDeadAt(1,1));
            Assert.IsTrue(nextGenGrid.IsCellDeadAt(0,1));

        }
    }
}