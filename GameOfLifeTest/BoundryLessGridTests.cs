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
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState);
            
            //act
            
            var strigToTest = grid.ToString();

            //assert
            
            Assert.AreEqual("....\n....\n....\n....\n", strigToTest);
            
        }

    }
}