using System;
using System.Linq;

namespace GameOfLife
{
    public class GameRules : IGameRules
    {
        
        public State GetNextState(IReadOnlyCell[] neighbours)
        {
            var aliveNeighboursCount = neighbours.Count(n => n.IsAlive());
            
            return (aliveNeighboursCount < 2 || aliveNeighboursCount > 3) ? State.Dead : State.Alive;
        }
    }
}