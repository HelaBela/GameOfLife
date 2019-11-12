using System;

namespace GameOfLife
{
    public class HardCodedGridProvider:IGridStateProvider
    {
        public  int[,] GetGridState()
        {
            var gridState = new[,]{{0,0,0,1,0,1,1},{1,1,0,1,0,0,0}, {1, 0, 1, 1,0,0,0 },{1, 1,0,0,1,0,0}, {1,0,0,1,0,0,0}, {1, 0,0, 1,0,0,0 },{0, 0,0,0,1,0,0} };

            return gridState;
        }
    }
}