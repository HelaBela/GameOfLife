using System;
using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GameTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Display_Grid()
        {
            //arrange
            var stringToTest = "....\n....\n....\n....\n";
            var consoleOperations = new Mock<ICommunicationOperations>();

            var grid = new Mock<IGrid>();
            grid.Setup(s => s.ToString()).Returns(stringToTest);
            var game = new Game(consoleOperations.Object, grid.Object);

            //act
            game.PrintGrid();


            //assert
            consoleOperations.Verify(m => m.WriteLine(stringToTest), Times.Exactly(1));
        }


        [Test]
        public void Should_Continue_For_4_Times_Given_The_State()
        {
            //arrange

            var cellsState = new[,] {{0, 0, 0, 1}, {1, 1, 0, 1}, {1, 0, 1, 1}, {1, 1, 0, 0}};
            var gameRules = new GameRules();

            var grid = GridFactory.CreateBoundaryLessGrid(cellsState, gameRules);
            var consoleOperations = new Mock<ICommunicationOperations>();

            //act

            var game = new Game(consoleOperations.Object, grid);
            game.Start();


            //assert

            consoleOperations.Verify(
                m => m.WriteLine("...*\n**.*\n*.**\n**..\n"));

            consoleOperations.Verify(
                m => m.WriteLine(It.Is<string>(c =>
                    c == "...*\n.*..\n....\n.*..\n")));

            consoleOperations.Verify(
                m => m.WriteLine(It.Is<string>(c =>
                    c == "*.*.\n....\n....\n....\n")));

            consoleOperations.Verify(
                m => m.WriteLine(It.Is<string>(c =>
                    c == "....\n....\n....\n....\n")));
        }
    }
}