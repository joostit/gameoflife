using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameOfLife
{
    class DrawableCell
    {

        Brush aliveBrush = new SolidBrush(Color.LimeGreen);
        Brush deadBrush = new SolidBrush(Color.Red);

        private Cell cell;

        public Brush Brush
        {
            get
            {
                return cell.IsAlive? aliveBrush : deadBrush;
            }
        }

        public DrawableCell(Cell cell)
        {
            this.cell = cell;
        }

    }
}
