using GDIDrawer;
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
        public int[,] gameGrid;
        public Color[] colors;

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

            colors colorList = new colors();              // create instance
            colors = colorList.getCellColors().ToArray(); // assign list in color class
            cellColor = colors[0]; // default color
        }

        public void PrintGrid()
        {
            for (int row = 0; row < numRows; row++)
            {
                for(int col = 0; col < numCols; col++)
                {
                    Console.Write(gameGrid[row,col]);
                }
                Console.WriteLine();
            }
        }

        bool IsInside(int row, int col)
        {
            if (row >= 0 && row < numRows && col >= 0 && col < numCols)
                return true;
            return false;
        }

        bool IsEmpty(int row, int col)
        {
            if (gameGrid[row, col] == 0)
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

        void MoveRowDown(int row, int movedRows)
        {
            for(int col = 0; col < numCols; col++)
            {
                gameGrid[row + movedRows, col] = gameGrid[row, col]; // copy to new row
                gameGrid[row, col] = 0;                              // clear original row
            }
        }

        int ClearFullRow()
        {
            int completed = 0;
            for (int row = numRows - 1; row >= 0; row--) // starts at the bottom goes to top
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    completed++;
                } 
                else if (completed > 0)
                {
                    MoveRowDown(row, completed);
                }
            }
            return completed;
        }

        public void Reset()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    gameGrid[row, col] = 0;
                }
            }
        }

        public void Draw(CDrawer canvas)
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    int cellValue = gameGrid[row, col];
                    Color cellColor = colors[cellValue];  // not impletmented yet
                    canvas.AddRectangle(col * cellSize + 10 + 1, row * cellSize + 10 + 1,
                                        cellSize - 1, cellSize - 1, cellColor);

                }
            }
        }
    }
}
