using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    class DrawableCell
    {

        private Brush[] healthBrushes = new Brush[]
        {
            new SolidBrush(Color.Red),
            new SolidBrush(Color.Orange),
            new SolidBrush(Color.Yellow),
            new SolidBrush(Color.LimeGreen)
        };

        public Cell Cell { get; private set; }

        public event EventHandler UserChangedState;

        public Brush Brush
        {
            get
            {
                return healthBrushes[Cell.Health];
            }
        }

        public DrawableCell(Cell cell)
        {
            this.Cell = cell;
        }


        public void SetState(LifeStates state)
        {
            if(state != Cell.State)
            {
                Cell.State = state;
                RaiseUserChangedState();
            }
        }

        private void RaiseUserChangedState()
        {
            UserChangedState.Invoke(this, EventArgs.Empty);
        }


    }
}
