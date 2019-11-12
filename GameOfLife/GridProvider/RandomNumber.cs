using System;

namespace GameOfLife
{
    public class RandomNumber:IRandomNumber
    {
        public int RandomNr(int min, int oneBiggerThanMax)
        {
            var number = new Random().Next(min, oneBiggerThanMax);

            return number;
        }
    }
}