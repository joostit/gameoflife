using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class HealthCell : Cell
    {
        public HealthCell(int x, int y)
            : base(x, y)
        {
        }


        protected override int? CalculateNextHealth(List<Cell> neighbors)
        {
            int? currentHealth = Health;

            int liveNeighbors = 0;

            neighbors.ForEach((c) =>
            {
                if (c.State == LifeStates.Alive)
                {
                    liveNeighbors++;
                }
            }
            );


            if (base.State == LifeStates.Alive)
            {
                switch (liveNeighbors)
                {
                    case 2:
                        // Don't increase with only two live neighbors
                        break;
                    case 3:
                        currentHealth++;
                        break;

                    default:
                        currentHealth--;
                        break;
                }
            }
            else
            {
                switch (liveNeighbors)
                {
                    case 4:
                        currentHealth++;
                        break;

                    default:
                        currentHealth--;
                        break;
                }
            }

            return currentHealth;
        }

    }
}
