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
        public int _id;
        public Position[][] _cells;
        public int _cellSize;
        public int _rowOffset;
        public int _colOffset;
        public int _rotationState;
        public Color[] _color; // get from color class later

        /// <summary>
        /// CTOR - initialize block with its ID
        /// </summary>
        /// <param name="id"></param>
        public Block(int id)
        {
            this._id = id;
            _cells = new Position[4][]; //4 x4
            _cellSize = 30;
            _rowOffset = 0;
            _colOffset = 0;
            _rotationState = 0;
            colors colorsList = new colors();
            _color = colorsList.getCellColors().ToArray(); // is this evenr ight

        }

        /// <summary>
        /// Move the block by specified rows and columns
        /// </summary>
        /// <param name="rows">row</param>
        /// <param name="cols">column</param>
        public void Move(int rows, int cols)
        {
            _rowOffset += rows;
            _colOffset += cols;
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
                Position original = _cells[_rotationState][i];
                movedTiles[i] = new Position(original.Row + _rowOffset, original.Col + _colOffset);
            }
            return movedTiles;
        }

        /// <summary>
        /// Rotate the block clockwise
        /// </summary>
        public void Rotate()
        {
            _rotationState += 1;
            if (_rotationState == _cells.GetLength(0))   // cells.GetLength(0)) = num rotation states
                _rotationState = 0;                         // cells.GetLength(1)) = num tiles per rotationd
        }

        /// <summary>
        /// Rotate the block counter-clockwise
        /// </summary>
        public void UndoRotation()
        {
            _rotationState -= 1;
            if (_rotationState == -1)
                _rotationState = _cells.GetLength(0) - 1;
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
                int x = tile.Col * _cellSize + offsetX;  // calculate pixel X
                int y = tile.Row * _cellSize + offsetY;  // calculate pixel Y
                int w = _cellSize - 1;                   // width (small gap for grid effect)
                int h = _cellSize - 1;                   // height (small gap)

                // check if tile is within canvas bounds before drawing
                if (x > 0 && x + w <= canvas.ScaledWidth && y > 0 && y + h <= canvas.ScaledHeight)
                {
                    canvas.AddRectangle(x, y, w, h, _color[_id]); // draw tile
                }
            }

            Console.WriteLine($"y: {GetCellPositions().First().Row}");
        }
    }
}