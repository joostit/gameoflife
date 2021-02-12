using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    class PopulationPanel : PanelEnhanced
    {

        private Population population;

        private int xMargin = 2;
        private int yMargin = 2;

        public event EventHandler UserChangedState;

        public PopulationPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        
        public void SetPopulation(Population newPopulation)
        {
            this.SuspendLayout();

            this.Controls.Clear();
            this.population = newPopulation;

            population.ForEachCell(AddCellControl);

            this.ResumeLayout();
        }



        private void AddCellControl(Cell cell, int x, int y)
        {
            CellControl ctrl = new CellControl(cell);
            ctrl.UserChangedState += Ctrl_UserChangedState;

            int xPos = x * (ctrl.Width + xMargin);
            int yPos = y * (ctrl.Height + yMargin);

            ctrl.Location = new System.Drawing.Point(xPos, yPos);

            this.Controls.Add(ctrl);
        }

        private void Ctrl_UserChangedState(object sender, EventArgs e)
        {
            RaiseUserChangedState();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(Color.White);

        }

        private void RaiseUserChangedState()
        {
            UserChangedState.Invoke(this, EventArgs.Empty);
        }

    }
}
