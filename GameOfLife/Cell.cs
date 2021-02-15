using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    abstract class Cell
    {

        public LifeStates State { get; set; }

        private LifeStates nextState = LifeStates.Dead;
        private List<Cell> neighbors = new List<Cell>();

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsAlive
        {
            get
            {
                return State == LifeStates.Alive;
            }
        }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void SetNeighbors(List<Cell> newNeighbors)
        {
            neighbors.Clear();
            neighbors.AddRange(newNeighbors);
        }

        /// <summary>
        /// Determines the next state by looking at the neighors' states
        /// </summary>
        public void DetermineNextState()
        {
            nextState = CalculateNextState(neighbors);
        }

        /// <summary>
        /// Applies the next state that was detemined earlier
        /// </summary>
        public void ApplyNextState()
        {
            State = nextState;
        }


        public override string ToString()
        {
            return $"Cell ({X}, {Y}): {State}";   
        }

        internal void ToggleState()
        {
            if(State == LifeStates.Alive)
            {
                State = LifeStates.Dead;
            }
            else
            {
                State = LifeStates.Alive;
            }
        }




        protected abstract LifeStates CalculateNextState(List<Cell> neighbors);

    }
}
