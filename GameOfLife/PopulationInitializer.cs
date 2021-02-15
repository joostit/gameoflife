using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class PopulationInitializer
    {


        public const int Width = 100;

        public const int Height = 100;


        public Population GetPopulation()
        {
            Population population = new Population(Width, Height);
            SetInitialCellStates(population);
            return population;
        }


        public void SetInitialCellStates(Population cells)
        {
            int cx = Width / 2;
            int cy = Height / 2;


            cells[cx + 3, cy - 2].State = LifeStates.Alive;
            cells[cx + 3, cy - 1].State = LifeStates.Alive;
            cells[cx + 3, cy].State = LifeStates.Alive;
            cells[cx + 2, cy].State = LifeStates.Alive;
            cells[cx + 1, cy].State = LifeStates.Alive;
            cells[cx, cy].State = LifeStates.Alive;
            cells[cx - 1, cy].State = LifeStates.Alive;
            cells[cx - 2, cy].State = LifeStates.Alive;
            cells[cx - 3, cy].State = LifeStates.Alive;
            cells[cx - 3, cy - 1].State = LifeStates.Alive;
            cells[cx - 3, cy - 2].State = LifeStates.Alive;

            cells[cx, cy - 3].State = LifeStates.Alive;
            cells[cx, cy - 2].State = LifeStates.Alive;
            cells[cx, cy - 1].State = LifeStates.Alive;
            cells[cx, cy + 1].State = LifeStates.Alive;
            cells[cx, cy + 2].State = LifeStates.Alive;
            cells[cx, cy + 3].State = LifeStates.Alive;

            cells[cx - 1, cy + 4].State = LifeStates.Alive;
        }


    }
}
