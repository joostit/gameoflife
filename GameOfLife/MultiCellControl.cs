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

        private int cellWidth = 10;
        private int cellHeight = 10;

        private Population population;

        public event EventHandler UserChangedState;

        Brush aliveBrush = new SolidBrush(Color.LimeGreen);
        Brush deadBrush = new SolidBrush(Color.Red);

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

            //population.ForEachCell(AddCellControl);

            this.ResumeLayout();
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Override the background erase function of the base class,
            return;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (this.DesignMode)
            {
                base.OnPaint(e);
                return;
            }

            Bitmap screenBuffer = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(screenBuffer);

            //g.Clear(Color.Black);

            Brush cellBrush;
            Cell cell;
            Rectangle cellRect;

            for (int xi = 0; xi < population.Width; xi++)
            {
                for(int yi = 0; yi < population.Height; yi++)
                {
                    cell = population[xi, yi];
                    cellBrush = cell.IsAlive ? aliveBrush : deadBrush;

                    cellRect = new Rectangle(
                        cellWidth * xi + xMargin, 
                        cellHeight * yi + yMargin, 
                        cellWidth - (xMargin * 2), 
                        cellHeight - (yMargin * 2));

                    g.FillRectangle(cellBrush, cellRect);
                }
            }

            e.Graphics.DrawImage(screenBuffer, 0, 0);
        }

        private void RaiseUserChangedState()
        {
            UserChangedState.Invoke(this, EventArgs.Empty);
        }

    }
}
