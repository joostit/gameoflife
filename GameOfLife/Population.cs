using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    /// <summary>
    /// Defines a Cell action delegate
    /// </summary>
    /// <param name="cell">The cell</param>
    /// <param name="x">The X coordinate of the cell within the grid</param>
    /// <param name="y">the Y coordinate of the cell within the grid</param>
    delegate void CellAction(Cell cell, int x, int y);

    class Population
    {

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int GenerationNumber { get; private set; }
        public int AliveCount { get; set; }


        private Cell[,] Cells;

        /// <summary>
        /// Gets the cell at the specific coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Cell this[int x, int y]
        {
            get
            {
                return Cells[x, y];
            }
        }


        public Population(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            InitizalizeCells();
        }

        private void InitizalizeCells()
        {
            Cells = new Cell[Width, Height];

            CellAction createAction = (c, y, x) => Cells[x, y] = new HealthCell(x, y);
            CellAction assignNeighborsAction = AssignNeighbors;

            ForEachCell(createAction);
            ForEachCell(assignNeighborsAction);
        }


        /// <summary>
        /// Runs the action delegate for each cell in the grid
        /// </summary>
        /// <param name="action">The action that is executed for each cell</param>
        public void ForEachCell(CellAction action)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    action(Cells[x, y], x, y);
                }
            }
        }


        /// <summary>
        /// Finds and assigns his neighbors to the specified cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void AssignNeighbors(Cell cell, int x, int y)
        {
            List<Cell> neighbors = new List<Cell>();

            if (x > 0 && y > 0) neighbors.Add(Cells[x - 1, y - 1]);
            if (x > 0) neighbors.Add(Cells[x - 1, y]);
            if (x > 0 && y < Height -1) neighbors.Add(Cells[x - 1, y + 1]);

            if (y > 0) neighbors.Add(Cells[x, y - 1]);
            if (y < Height - 1) neighbors.Add(Cells[x, y + 1]);

            if (x < Width - 1 && y > 0) neighbors.Add(Cells[x + 1, y - 1]);
            if (x < Width - 1) neighbors.Add(Cells[x + 1, y]);
            if (x < Width - 1 && y < Height - 1) neighbors.Add(Cells[x + 1, y + 1]);

            cell.SetNeighbors(neighbors);
        }


        public void IncreaseGeneration()
        {
            ForEachCell((cell, x, y) => cell.DetermineNextState());
            ForEachCell((cell, x, y) => cell.ApplyNextState());

            int aliveCnt = 0;
            ForEachCell((cell, x, y) =>
            {
                if(cell.State == LifeStates.Alive)
                {
                    aliveCnt++;
                }
            });
            AliveCount = aliveCnt;

            GenerationNumber++;
        }

    }
}
