using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GameRulesTests
{
    public class GameRulesTests
    {
        private GameRules _gameRules;

        [SetUp]
        public void Setup()
        {
            _gameRules = new GameRules();
        }

        [Test]
        public void Alive_Cell_With_1_Alive_Neighbour_Will_Die()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };

            //act

            var currentCell = new ReadOnlyCell(State.Alive);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Dead);
        }

        [Test]
        public void Alive_Cell_With_0_Alive_Neighbours_Will_Die()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Alive);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Dead);
        }

        [Test]
        public void Alive_Cell_With_2_Alive_Neighbours_Will_Stay_Alive()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Alive);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Alive);
        }


        [Test]
        public void Dead_Cell_With_2_Alive_Neighbours_Will_Stay_Dead()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Dead);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Dead);
        }
        
        
        [Test]
        public void Dead_Cell_With_1_Alive_Neighbours_Will_Stay_Dead()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Dead);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Dead);
        }
        
        [Test]
        public void Dead_Cell_With_0_Alive_Neighbours_Will_Stay_Dead()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Dead);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Dead);
        }


        [Test]
        public void Alive_Cell_With_3_Alive_Neighbours_Will_Stay_Alive()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Alive);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Alive);
        }

        [Test]
        public void Alive_Cell_With_4_Alive_Neighbours_Will_Die()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive),
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act
            var currentCell = new ReadOnlyCell(State.Alive);

            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Dead);
        }


        [Test]
        public void Dead_Cell_With__3_Alive_Neighbours_Will_Revive()
        {
            //arrange

            var neighbours = new ReadOnlyCell[]
            {
                new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive), new ReadOnlyCell(State.Alive),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead),
                new ReadOnlyCell(State.Dead), new ReadOnlyCell(State.Dead)
            };


            //act

            var currentCell = new ReadOnlyCell(State.Alive);
            var nextState = _gameRules.GetNextState(currentCell, neighbours);


            //assert
            Assert.IsTrue(nextState == State.Alive);
        }
    }
}