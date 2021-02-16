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
            int maxHealthNeighbors = 0;
            int goodHealthNeighbors = 0;

            neighbors.ForEach((c) =>
            {
                if (c.IsAlive)
                {
                    liveNeighbors++;
                }

                if (c.IsMaxHealth)
                {
                    maxHealthNeighbors++;
                }

                if (c.IsGoodHealth)
                {
                    goodHealthNeighbors++;
                }
            }
            );


            if (base.IsAlive)
            {
                switch (liveNeighbors)
                {

                    case 2:
                        // Only increase to Max_Health if we have lots of healthy neigbors
                        if (goodHealthNeighbors >= 1)
                        {
                            currentHealth++;
                        }
                        else
                        {
                            currentHealth = 1;
                        }
                        break;
                    case 3:

                        // Only increase to Max_Health if we have lots of healthy neighbors
                        if(maxHealthNeighbors == 3)
                        {
                            currentHealth++;
                        }
                        else
                        {
                            // The health doesn't increase
                        }
                        break;

                    case 4:
                    case 5:
                        currentHealth -= 2;
                        break;

                    default:
                        currentHealth = 0;
                        break;
                }
            }
            else
            {
                switch (liveNeighbors)
                {
                    case 3:
                        if(goodHealthNeighbors >= 2)
                        {
                            currentHealth = 2;
                        }
                        break;

                    default:
                        
                        break;
                }
            }

            return currentHealth;
        }

    }
}
