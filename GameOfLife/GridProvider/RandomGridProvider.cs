using System;
using System.Threading.Tasks.Dataflow;

namespace GameOfLife
{
    public class RandomGridProvider : IGridStateProvider
    {
        private IRandomNumber _random;

        public RandomGridProvider(IRandomNumber random)
        {
            _random = random;
        }

        public int[,] GetGridState()
        {

            var randowArrayLengthAndHeight = _random.RandomNr(3,10) ;

            var gridState = new int[randowArrayLengthAndHeight, randowArrayLengthAndHeight];

            for (int i = 0; i < gridState.GetLength(0); i++)
            {
                for (int j = 0; j < gridState.GetLength(1); j++)
                {
                    gridState[i, j] = _random.RandomNr(0,2);
                }
            }

            return gridState;
        }
    }
}