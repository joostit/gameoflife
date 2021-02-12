using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    /// <summary>
    /// Enhanced Panel
    /// </summary>
    class PanelEnhanced : Panel
    {
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

        /// <summary>
        /// OnPaint event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // use double buffering
            this.DoubleBuffered = true;
            // Background redraw moves to this
            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(
                    this.BackgroundImage,
                    new System.Drawing.Rectangle(0, 0, this.Width, this.Height),
                    0,
                    0,
                    this.BackgroundImage.Width,
                    this.BackgroundImage.Height,
                    System.Drawing.GraphicsUnit.Pixel);
            }
            

            base.OnPaint(e);
        }
    }
}
