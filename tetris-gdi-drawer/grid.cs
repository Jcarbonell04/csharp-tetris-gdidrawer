using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris_gdi_drawer
{
    public class grid
    {
        private int[,] gameGrid;
        private Color[] colors;

        public int numRows { get; private set; } = 20;
        public int numCols { get; private set; } = 10;
        public int cellSize { get; private set; } = 30;

        public grid(int rows, int cols)
        {
            numRows = rows;
            numCols = cols;
            gameGrid = new int[rows, cols];

        }
    }
}
