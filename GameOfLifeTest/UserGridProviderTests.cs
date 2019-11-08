using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridTests
{
    public class UserGridProviderTests
    {
        [Test]
        
        public void Can_Provide_Cell_State_For_New_Grid()
        {
            //arrange
            var consoleOperations = new Mock<ICommunicationOperations>();
            var userGridProvider = new UserGridProvider(consoleOperations.Object);
            consoleOperations.Setup(s=>s.Read()).Returns("0011,1100,0000,1010");

            //act

            var gridState = userGridProvider.GetGridState();
            var expectedState = new int[4, 4] {{0,0,1,1},{1,1,0,0}, {0, 0, 0, 0},{1, 0,1,0}};

            //assert
            
            Assert.AreEqual(expectedState, gridState);
            

        }
    }
}