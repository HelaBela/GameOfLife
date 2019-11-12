using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class ReadOnlyCell
    {
        private readonly CellState _cellCellState;

        public ReadOnlyCell(CellState cellCellState)
        {
            _cellCellState = cellCellState;
        }
        
        public override string ToString()
        {
            if (_cellCellState == CellState.Dead)
                return ".";
            return "*";
        }

        public bool IsAlive()
        {
            return _cellCellState == CellState.Alive;
        }

        public bool IsDead()
        {
            return !IsAlive();
        }
    }
}