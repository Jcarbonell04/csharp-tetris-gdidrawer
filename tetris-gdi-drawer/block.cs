//***********************************************************************************
// Program: blocks.cs
// Description: Defines the Block class used for Tetris tetrominoes, including
//              tile positions, rotation states, movement, and drawing logic.
// Author: Jaedyn Carbonell
//***********************************************************************************

using GDIDrawer;
using System;
using System.Drawing;
using System.Linq;

namespace tetris_gdi_drawer
{
    /// <summary>
    /// Represents a single Tetris block (tetromino)
    /// </summary>
    public class Block
    {
        public int id;
        public Position[,] cells;
        public int cellSize;
        public int rowOffset;
        public int colOffset;
        public int rotationState;
        public Color[] color; // get from color class later

        /// <summary>
        /// CTOR - initialize block with its ID
        /// </summary>
        /// <param name="id"></param>
        public Block(int id)
        {
            this.id = id;
            cells = new Position[4,4]; //4 x4
            cellSize = 30;
            rowOffset = 0;
            colOffset = 0;
            rotationState = 0;
            colors colorsList = new colors();
            color = colorsList.getCellColors().ToArray(); // is this evenr ight

        }

        /// <summary>
        /// Move the block by specified rows and columns
        /// </summary>
        /// <param name="rows">row</param>
        /// <param name="cols">column</param>
        public void Move(int rows, int cols)
        {
            rowOffset = rows;
            colOffset = cols;
        }

        /// <summary>
        /// Get the current positions of the 4 tiles with applied offsets
        /// </summary>
        /// <returns>movedTiles</returns>
        public Position[] GetCellPositions()
        {
            Position[] movedTiles = new Position[4];
            for (int i = 0; i < 4; i++) // 4 tiles per tetromino
            {
                Position position = cells[rotationState, i]; // cells[x, y]
                position.Row += rowOffset;
                position.Col += colOffset;
                movedTiles[i] = position;
            }
            return movedTiles;
        }

        /// <summary>
        /// Rotate the block clockwise
        /// </summary>
        public void Rotate()
        {
            rotationState += 1;
            if (rotationState == cells.GetLength(0))   // cells.GetLength(0)) = num rotation states
                rotationState = 0;                         // cells.GetLength(1)) = num tiles per rotationd
        }

        /// <summary>
        /// Rotate the block counter-clockwise
        /// </summary>
        public void UndoRotation()
        {
            rotationState -= 1;
            if (rotationState == -1)
                rotationState = cells.GetLength(0) - 1;
        }

        /// <summary>
        /// Draw the block on the given canvas
        /// </summary>
        /// <param name="canvas">canvas to draw on</param>
        /// <param name="offsetX">xPos to draw block</param>
        /// <param name="offsetY">yPos to draw block</param>
        public void Draw(CDrawer canvas, int offsetX, int offsetY)
        {
            foreach (Position tile in GetCellPositions())
            {
                int x = tile.Col * cellSize + offsetX;  // calculate pixel X
                int y = tile.Row * cellSize + offsetY;  // calculate pixel Y
                int w = cellSize - 1;                   // width (small gap for grid effect)
                int h = cellSize - 1;                   // height (small gap)

                // check if tile is within canvas bounds before drawing
                if (x > 0 && x + w <= canvas.ScaledWidth && y > 0 && y + h <= canvas.ScaledHeight)
                {
                    canvas.AddRectangle(x, y, w, h, color[id]); // draw tile
                }
            }

            Console.WriteLine($"y: {GetCellPositions().First().Row}");
        }
    }
}