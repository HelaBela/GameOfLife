using System;
using System.Linq;

namespace GameOfLife
{
    public class GameRules : IGameRules
    {
        
        public CellState GetNextState(ReadOnlyCell currentCell, ReadOnlyCell[] neighbours)
        {
            var aliveNeighboursCount = neighbours.Count(n => n.IsAlive());
            
            
            if ( currentCell.IsAlive() && (aliveNeighboursCount < 2 || aliveNeighboursCount > 3))
            {
                return CellState.Dead;
                
            }

            if (currentCell.IsAlive() && (aliveNeighboursCount == 2 || aliveNeighboursCount == 3))
            {
                return CellState.Alive;

            }
            
            if (currentCell.IsDead() && aliveNeighboursCount == 3)
            {
                return CellState.Alive;
            }

            return CellState.Dead;
            
        }
    }
}