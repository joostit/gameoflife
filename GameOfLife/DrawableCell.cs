using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    class DrawableCell
    {

        Brush aliveBrush = new SolidBrush(Color.LimeGreen);
        Brush deadBrush = new SolidBrush(Color.Red);

        public Cell Cell { get; private set; }
        bool canMouseToggle = false;

        public event EventHandler UserChangedState;

        public Brush Brush
        {
            get
            {
                return Cell.IsAlive? aliveBrush : deadBrush;
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

        public void DoMouseDown(MouseEventArgs e)
        {
            if (Cell != null)
            {
                Cell.ToggleState();
                canMouseToggle = false;
                RaiseUserChangedState();
            }
        }

        public void DoMouseMove(MouseEventArgs e)
        {

            Cell.ToggleState();

            RaiseUserChangedState();
        }


        public void DoMouseEnter()
        {
            RaiseUserChangedState();
        }

        public void DoMouseLeave()
        {
            RaiseUserChangedState();
        }

        public void DoMouseUp(MouseEventArgs e)
        {
            canMouseToggle = true;
        }

        private void RaiseUserChangedState()
        {
            UserChangedState.Invoke(this, EventArgs.Empty);
        }


    }
}
