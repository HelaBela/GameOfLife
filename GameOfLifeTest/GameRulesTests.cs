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
            var gameRules = new GameRules();

            var neighbours = new IReadOnlyCell[] { new Cell(State.Alive), new Cell(State.Dead),  new Cell(State.Dead), new Cell(State.Dead), new Cell(State.Dead), new Cell(State.Dead), new Cell(State.Dead), new Cell(State.Dead)};
           
            
            //act
            
            var cell = gameRules.GetNextState(neighbours);


            //assert
            Assert.IsTrue(cell == State.Dead);
        }
    }
}