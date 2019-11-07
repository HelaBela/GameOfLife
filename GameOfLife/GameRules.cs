using System;
using System.Linq;

namespace GameOfLife
{
    public class GameRules : IGameRules
    {
        
        public State GetNextState(ReadOnlyCell currentCell, ReadOnlyCell[] neighbours)
        {
            var aliveNeighboursCount = neighbours.Count(n => n.IsAlive());
            
            
            if ( currentCell.IsAlive() && (aliveNeighboursCount < 2 || aliveNeighboursCount > 3))
            {
                return State.Dead;
                
            }

            if (currentCell.IsAlive() && (aliveNeighboursCount == 2 || aliveNeighboursCount == 3))
            {
                return State.Alive;

            }
            
            if (currentCell.IsDead() && aliveNeighboursCount == 3)
            {
                return State.Alive;
            }

            return State.Dead;



           // return (aliveNeighboursCount < 2 || aliveNeighboursCount > 3) ? State.Dead : State.Alive;
            
            
        }
    }
}