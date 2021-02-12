using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class StandardCell : Cell
    {

        public StandardCell(int x, int y)
            : base(x, y)
        {
        }


        protected override LifeStates CalculateNextState(List<Cell> neighbors)
        {
            LifeStates result;
            if (State == LifeStates.Alive)
            {
                result = LifeStates.Dead;
            }
            else
            {
                result = LifeStates.Alive;
            }

            return result;
        }

    }
}
