using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    class MultiCellControl : UserControl
    {

        private int xMargin = 1;
        private int yMargin = 1;

        private int cellWidth = 6;
        private int cellHeight = 6;

        private Population population;

        private DrawableCell[,] cells;
        private LifeStates? mouseDownSetState = null;

        public event EventHandler UserChangedState;

        public MultiCellControl()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }


        public void SetPopulation(Population newPopulation)
        {
            this.SuspendLayout();

            this.Controls.Clear();
            this.population = newPopulation;

            cells = new DrawableCell[population.Width, population.Height];

            population.ForEachCell((c, x, y) =>
            {
                DrawableCell dCell = new DrawableCell(c);
                dCell.UserChangedState += DCell_UserChangedState;
                cells[x, y] = dCell;
            });


            this.ResumeLayout();
        }

        private void DCell_UserChangedState(object sender, EventArgs e)
        {
            this.Invalidate();
            RaiseUserChangedState();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Override the background erase function of the base class,
            return;
        }


        protected override void OnPaint(PaintEventArgs e)
        {

            if (this.DesignMode)
            {
                base.OnPaint(e);
                return;
            }

            Bitmap screenBuffer = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(screenBuffer);

            DrawableCell cell;
            Rectangle cellRect;

            for (int xi = 0; xi < population.Width; xi++)
            {
                for(int yi = 0; yi < population.Height; yi++)
                {
                    cell = cells[xi, yi];

                    cellRect = new Rectangle(
                        cellWidth * xi + xMargin, 
                        cellHeight * yi + yMargin, 
                        cellWidth - (xMargin * 2), 
                        cellHeight - (yMargin * 2));

                    g.FillRectangle(cell.Brush, cellRect);
                }
            }

            e.Graphics.DrawImage(screenBuffer, 0, 0);
        }

        private void RaiseUserChangedState()
        {
            UserChangedState.Invoke(this, EventArgs.Empty);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(mouseDownSetState != null)
            {
                DrawableCell cell = getCellAtPoint(e.X, e.Y);
                cell.SetState(mouseDownSetState.Value);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            DrawableCell cell = getCellAtPoint(e.X, e.Y);

            if (cell != null)
            {
                mouseDownSetState = cell.Cell.IsAlive ? mouseDownSetState = LifeStates.Dead : LifeStates.Alive;
                cell.SetState(mouseDownSetState.Value);
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDownSetState = null;
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            mouseDownSetState = null;
        }

        private DrawableCell getCellAtPoint(int x, int y)
        {
            int cX = x / cellWidth;
            int cY = y / cellHeight;

            if(cX < 0 || cY < 0)
            {
                return null;
            }

            if (cX >= population.Width || cY >= population.Height)
            {
                return null;
            }

            return cells[cX, cY];
        }

    }
}
