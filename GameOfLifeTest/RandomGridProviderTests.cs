using GameOfLife;
using Moq;
using NUnit.Framework;

namespace GridTests
{
    public class RandomGridProviderTests
    {
        [Test]
        public void Can_Provide_Random_Cell_State_For_New_Grid()
        {
            //arrange

            var randomNumber = new Mock<IRandomNumber>();
            

            var randomGridProvider = new RandomGridProvider(randomNumber.Object);


            randomNumber.SetupSequence(s => s.RandomNr(0, 2))
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(0);

            randomNumber.Setup(s => s.RandomNr(3, 10)).Returns(4);


            //act

            var gridState = randomGridProvider.GetGridState();
            var expectedState = new int[4, 4] {{0, 1, 1, 0}, {0, 1, 1, 0}, {0, 1, 1, 0}, {0, 1, 1, 0}};

            //assert

            Assert.AreEqual(expectedState, gridState);
        }
    }
}