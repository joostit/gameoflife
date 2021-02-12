using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class PopulationInitializer
    {


        public const int Width = 21;

        public const int Height = 21;



        public Population GetPopulation()
        {
            Population population = new Population(Width, Height);
            SetInitialCellStates(population);
            return population;
        }



        public void SetInitialCellStates(Population cells)
        {
            cells[12, 10].State = LifeStates.Alive;
            cells[11, 10].State = LifeStates.Alive;
            cells[10, 10].State = LifeStates.Alive;
            cells[9, 10].State = LifeStates.Alive;
            cells[8, 10].State = LifeStates.Alive;

            cells[10, 8].State = LifeStates.Alive;
            cells[10, 9].State = LifeStates.Alive;
            cells[10, 11].State = LifeStates.Alive;
            cells[10, 12].State = LifeStates.Alive;
        }



    }
}
