using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    abstract class Cell
    {

        private int MAX_HEALTH = 3;
        private const int MIN_HEALTH = 0;

        public LifeStates State
        {
            get
            {
                return Health > 0 ? LifeStates.Alive : LifeStates.Dead;
            }
            set
            {
                switch (value)
                {
                    case LifeStates.Dead:
                        Health = MIN_HEALTH;
                        break;

                    case LifeStates.Alive:
                        Health = MAX_HEALTH;
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported Health state: {value}");
                }
            }
        }

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
            }
            else
            {
                int? calcHealth = CalculateNextHealth(neighbors);
                if(calcHealth == null)
                {
                    throw new InvalidOperationException("Either CalculateNextState() or CalculateNextHealth() needs to be overridden and return a value");
                }
                nextHealth = calcHealth.Value;
            }


        }

        /// <summary>
        /// Applies the next state that was detemined earlier
        /// </summary>
        public void ApplyNextState()
        {
            Health = nextHealth;
        }


        public override string ToString()
        {
            return $"Cell ({X}, {Y}): {State}";   
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
