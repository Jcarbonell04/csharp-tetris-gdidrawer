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

        public int numRows { get; set; } = 20;
        public int numCols { get;  set; } = 10;
        public int cellSize { get; set; } = 30;

        public grid(int rows, int cols)
        {
            numRows = rows;
            numCols = cols;
            gameGrid = new int[rows, cols];

        }
    }
}
