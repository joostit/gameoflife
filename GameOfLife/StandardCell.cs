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

            int liveNeighbors = 0;

            neighbors.ForEach((c) =>
            {
                if (c.State == LifeStates.Alive)
                {
                    liveNeighbors++;
                }
            }
            );


            if(base.State == LifeStates.Alive)
            {
                switch (liveNeighbors)
                {
                    case 2:
                    case 3:
                        result = LifeStates.Alive;
                        break;

                    default:
                        result = LifeStates.Dead;
                        break;
                }
            }
            else
            {
                switch (liveNeighbors)
                {
                    case 3:
                        result = LifeStates.Alive;
                        break;

                    default:
                        result = LifeStates.Dead;
                        break;
                }
            }

            return result;
        }

    }
}
