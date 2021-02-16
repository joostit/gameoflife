using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    abstract class Cell
    {

        private int MAX_HEALTH = 3;
        private const int MIN_HEALTH = 0;

        public LifeStates State { get; set; }

        private LifeStates nextState = LifeStates.Dead;
        private int nextHealth = 0;
        private List<Cell> neighbors = new List<Cell>();

        public int X { get; set; }

        public int Y { get; set; }

        public int Health { get; private set; }

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
            LifeStates? calcState = CalculateNextState(neighbors);
            
            if(calcState != null)
            {
                nextHealth = calcState.Value == LifeStates.Alive ? MAX_HEALTH : MIN_HEALTH;
                nextState = calcState.Value;
            }
            else
            {
                int? calcHealth = CalculateNextHealth(neighbors);
                if(calcHealth == null)
                {
                    throw new InvalidOperationException("Either CalculateNextState() or CalculateNextHealth() needs to be overridden and return a value");
                }

                nextState = calcHealth > 0 ? LifeStates.Alive : LifeStates.Dead;
                nextHealth = calcHealth.Value;
            }


        }

        /// <summary>
        /// Applies the next state that was detemined earlier
        /// </summary>
        public void ApplyNextState()
        {
            State = nextState;
            Health = nextHealth;
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


        protected void SetHealth(int newHealth)
        {
            int toSet = newHealth < MAX_HEALTH ? newHealth : MAX_HEALTH;
            toSet = toSet > MIN_HEALTH ? toSet : MIN_HEALTH;


            Health = toSet;

            State = Health > 0 ? LifeStates.Alive : LifeStates.Dead;
        }


        protected virtual LifeStates? CalculateNextState(List<Cell> neighbors)
        {
            return null;
        }

        protected virtual int? CalculateNextHealth(List<Cell> neighbors)
        {
            return null;
        }

    }
}
