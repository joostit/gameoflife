using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class PopulationInitializer
    {


        public const int Width = 31;

        public const int Height = 31;


        public Population GetPopulation()
        {
            Population population = new Population(Width, Height);
            SetInitialCellStates(population);
            return population;
        }


        public void SetInitialCellStates(Population cells)
        {
            cells[18, 13].State = LifeStates.Alive;
            cells[18, 14].State = LifeStates.Alive;
            cells[18, 15].State = LifeStates.Alive;
            cells[17, 15].State = LifeStates.Alive;
            cells[16, 15].State = LifeStates.Alive;
            cells[15, 15].State = LifeStates.Alive;
            cells[14, 15].State = LifeStates.Alive;
            cells[13, 15].State = LifeStates.Alive;
            cells[12, 15].State = LifeStates.Alive;
            cells[12, 14].State = LifeStates.Alive;
            cells[12, 13].State = LifeStates.Alive;

            cells[15, 12].State = LifeStates.Alive;
            cells[15, 13].State = LifeStates.Alive;
            cells[15, 14].State = LifeStates.Alive;
            cells[15, 16].State = LifeStates.Alive;
            cells[15, 17].State = LifeStates.Alive;
            cells[15, 18].State = LifeStates.Alive;
            cells[14, 19].State = LifeStates.Alive;
        }



    }
}
