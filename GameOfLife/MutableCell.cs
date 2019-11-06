using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class MutableCell
    {
        public State CellState;

        public MutableCell(State cellState)
        {
            CellState = cellState;
        }
        
        public override string ToString()
        {
            if (CellState == State.Dead)
                return ".";
            return "*";
        }


        public void Kill()

        {
            CellState = State.Dead;
        }

        public void Revive()
        {
            CellState = State.Alive;
        }

        public MutableCell Clone()
        {
            return new MutableCell(CellState);
        }
    }
}