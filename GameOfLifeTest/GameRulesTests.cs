using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GameRulesTests
{
    public class GameRulesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_Less_Than_2_Alive_Neighbours_Will_Return_Dead_State()
        {
            //arrange
            var cellsState = new[,]{{0, 0, 0}, {1, 1, 0}, {0, 0, 0}};
            var gameRules = new Mock<IGameRules>();
            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules.Object);

            
            //act
            var nextGen = grid.CreateNextGen();


            //assert
            Assert.IsTrue(nextGen.IsCellDeadAt(1,1));
        }
    }
}