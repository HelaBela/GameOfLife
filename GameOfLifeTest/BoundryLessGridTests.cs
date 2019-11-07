using System;
using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridFactoryTests
{
    public class BoundryLessGridTests
    {
        private GameRules _gameRules;

        [SetUp]
        public void Setup()
        {
            
            _gameRules = new GameRules();
        }

        [Test]
        public void Can_Display_Grid()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);
            
            //act
            
            var strigToTest = grid.ToString();

            //assert
            
            Assert.AreEqual("....\n....\n....\n....\n", strigToTest);
            
        }

        [Test]
        public void Can_Find_8_Neighbours_For_Middle_Cell()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {1, 0, 1}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);


            //act

            var neighbours = grid.GetNeighbours(1,1);
         
            

            //assert
            Assert.AreEqual(8, neighbours.Length);
        }
        
        
        [Test]
        public void Cell_At_Position_00_Has_8_Neighbours_Because_It_Leaps_To_Another_Side()
        {
            //arrange
            var cellsState = new[,] {{0, 1, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 1, 0, 0}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);


            //act

            var neighbours = grid.GetNeighbours(0,0);
         
            

            //assert
            Assert.AreEqual(8, neighbours.Length);
        }

        
          
        [Test]
        public void Dead_Cell_With_3_Alive_Neighbours_Will_Revive_In_Next_Generation()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 0, 0}, {1, 0, 1}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);


            //act

            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellAliveAt(1,1));

        }
        
        [Test]
        public void Alive_Cell_Will_Die_From_Over_Population()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {1, 1, 1}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);


            //act
            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellDeadAt(1,1));

        }
        
        [Test]
        public void Alive_Cell_Will_Remain_Alive_When_Having_2_Alive_Neighbours()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {0, 1, 0}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);


            //act

            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellAliveAt(1,1));

        }
        
        [Test]
        public void Alive_Cell_Will_Die_When_There_Is_One_Alive_Neighbour()
        {
            //arrange
            var cellsState = new[,] {{0, 0, 0}, {1, 1, 0}, {0, 0, 0}};
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, _gameRules);


            //act

            var nextGenGrid = grid.CreateNextGen();

            //assert
            Assert.IsTrue(nextGenGrid.IsCellDeadAt(1,1));
            Assert.IsTrue(nextGenGrid.IsCellDeadAt(0,1));

        }
    }
}