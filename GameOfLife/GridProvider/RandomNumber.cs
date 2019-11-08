using System;

namespace GameOfLife
{
    public class RandomNumber:IRandomNumber
    {
        public int RandomNr(int min, int max)
        {
            var number = new Random().Next(min, max);

            return number;
        }
    }
}