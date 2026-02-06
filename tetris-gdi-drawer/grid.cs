//***********************************************************************************
// Program: grid.cs
// Description: game grid representing the Tetris board
//              Handles grid init, checking for full/empty cells, row clearing, 
//              and drawing the grid using GDIDrawer
// Author: Jaedyn Carbonell
//***********************************************************************************

using GDIDrawer;
using System;
using System.Drawing;

namespace tetris_gdi_drawer
{
    public class grid
    {
        // VARIABLE DECLARATION
        public int[,] gameGrid;        // 2D array storing the state of each cell (0 = empty, >0 = block ID)
        public Color[] cellColors;     // Array of colors for each type of block

        // Automatic Properties
        public int numRows { get; set; } = 20;
        public int numCols { get; set; } = 10;
        public int cellSize { get; set; } = 30;
        public Color cellColor { get; set; }

        /// <summary>
        /// Custom CTOR - inits grid
        /// </summary>
        public grid()
        {
            numRows = 20;
            numCols = 10;
            cellSize = 30;

            // init game grid with empty cells
            gameGrid = new int[numRows, numCols];

            // init colours from color.cs
            colors colorList = new colors();                  // create instance
            cellColors = colorList.getCellColors().ToArray(); // assign list in color class
            cellColor = cellColors[0];                        // default color
        }

        /// <summary>
        /// 
        /// </summary>
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

        public bool IsInside(int row, int col)
        {
            if (row >= 0 && row < numRows && col >= 0 && col < numCols)
                return true;
            return false;
        }

        public bool IsEmpty(int row, int col)
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

        public int ClearFullRow()
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
                    Color cellColor = cellColors[cellValue];  // not impletmented yet
                    canvas.AddRectangle(col * cellSize + 10 + 1, row * cellSize + 10 + 1,
                                        cellSize - 1, cellSize - 1, cellColor);

                }
            }
        }
    }
}
