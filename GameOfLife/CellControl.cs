using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{

    class CellControl : UserControl
    {

        bool canMouseToggle = false;

        private const int DefaultWidth = 15;
        private const int DefaultHeight = 15;

        private Cell cell;
        private Pen borderPen = new Pen(Color.LightGray, 1);

        Brush aliveBrush = new SolidBrush(Color.Green);
        Brush deadBrush = new SolidBrush(Color.Red);
        Brush noneBrush = new SolidBrush(Color.LightGray);

        public event EventHandler UserChangedState;

        public CellControl(Cell cell)
        {
            this.cell = cell;
            this.Width = DefaultWidth;
            this.Height = DefaultHeight;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// OnPaintBackground event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Override the background erase function of the base class,
            // Resolve the window refresh, zoom in, the image flickers
            return;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            Graphics g = e.Graphics;
            
            Brush fillBrush = GetFillBrush();

            g.FillRectangle(fillBrush, 0, 0, this.Width, this.Height);
        }


        private Brush GetFillBrush()
        {
            Brush retVal = noneBrush;

            if (cell != null)
            {
                switch (cell.State)
                {
                    case LifeStates.Dead:
                        retVal = deadBrush;
                        break;

                    case LifeStates.Alive:
                        retVal = aliveBrush;
                        break;

                    default:
                        throw new NotSupportedException("Unsupported alive state");
                }
            }

            return retVal;
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Capture = false;

            if (cell != null)
            {
                cell.ToggleState();
                canMouseToggle = false;
                RaiseUserChangedState();
            }

            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            canMouseToggle = true;
            base.OnMouseUp(e);
        }

        
        protected override void OnMouseEnter(EventArgs e)
        {
            canMouseToggle = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (canMouseToggle)
            {
                if(e.Button == MouseButtons.Left)
                {
                    cell.ToggleState();
                    canMouseToggle = false;
                    this.Invalidate();
                    RaiseUserChangedState();
                }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {

            base.OnMouseLeave(e);
        }


        private void RaiseUserChangedState()
        {
            UserChangedState.Invoke(this, EventArgs.Empty);
        }

    }
}
