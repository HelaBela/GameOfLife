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
        public void CanDisplayGrid()
        {
            //arrange
            var stringToTest = "....\n....\n....\n....\n";
            var consoleOperations = new Mock<IConsoleOperations>();

            var grid = new Mock<IGrid>();
            grid.Setup(s => s.ToString()).Returns(stringToTest);
            var game = new Game(consoleOperations.Object, grid.Object);

            //act

            game.PrintGrid();


            //assert

            consoleOperations.Verify(m => m.WriteLine(stringToTest), Times.Exactly(1));
        }
        
        
        [Test]
        public void d()
        {
            //arrange
         
            //act

           

            //assert

         
        }
    }
}