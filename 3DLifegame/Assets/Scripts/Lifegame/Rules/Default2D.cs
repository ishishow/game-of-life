using System.Collections;
using System.Collections.Generic;
using Lifegame;

namespace Lifegame.Rules
{
    public class Default2D : IRule
    {
        public bool NextAlive(Cell cell)
        {
            var count = 0;
            foreach (var aroundCell in cell.AroundCells)
            {
                count += (aroundCell.IsAlive) ? 1 : 0;
            }
            if(cell.IsAlive)
            {
                return (2 == count || 3 == count);
            }
            else
            {
                return (count == 3);
            }
        }
    }
}