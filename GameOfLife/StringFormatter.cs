using System;

namespace GameOfLife
{
    
    public static class StringFormatter
    {
        public  static  string Format(IGrid grid) 
        {
            var output = "";

            var cells = grid.GetCells();

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    output += $"{cells[x, y]}";
                }
                
                output += Environment.NewLine;
            }

            return output;
        }
        
    }
}