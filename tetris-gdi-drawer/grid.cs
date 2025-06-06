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
        public int numCols { get; set; } = 10;
        public int cellSize { get; set; } = 30;
        public Color cellColor { get; set; }

        public grid()
        {
            numRows = 20;
            numCols = 10;
            cellSize = 30;
            gameGrid = new int[numRows, numCols];
            cellColor = Color.White; // chnage later , no definition for getcellcolors yet
        }

        bool IsInside(int row, int col)
        {
            if (row >= 0 && row < numRows && col >= 0 && col < numCols)
                return true;
            return false;
        }

        bool IsEmpty(int row, int col)
        {
            if (gameGrid[row, col] == 9)
                return true;
            return false;
        }

        bool IsRowFull(int row)
        {
            for (int col = 0; col < numCols; col++)
                if (gameGrid[row, col] == 0)
                    return false;
            return true;
        }

        void ClearRow(int row)
        {
            for (int col = 0; col < numCols; col++)
            {
                gameGrid[row, col] = 0;
            }
        }
    }
}
