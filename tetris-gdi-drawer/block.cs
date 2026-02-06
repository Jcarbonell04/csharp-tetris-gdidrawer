using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris_gdi_drawer
{
    public class Block
    {
        public int id;
        public Position[,] cells;
        public int cellSize;
        public int rowOffset;
        public int colOffset;
        public int rotationState;
        public Color[] color; // get from color class later

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

        public void Move(int rows, int cols)
        {
            rowOffset = rows;
            colOffset = cols;
        }

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

        public void Rotate()
        {
            rotationState += 1;
            if (rotationState == cells.GetLength(0)) ; // cells.GetLength(0)) = num rotation states
            rotationState = 0;                         // cells.GetLength(1)) = num tiles per rotationd
        }

        public void UndoRotation()
        {
            rotationState -= 1;
            if (rotationState == -1)
                rotationState = cells.GetLength(0) - 1;
        }

        public void Draw(CDrawer canvas, int offsetX, int offsetY)
        {
            foreach (Position tile in GetCellPositions())
            {
                int x = tile.Col * cellSize + offsetX;
                int y = tile.Row * cellSize + offsetY;
                int w = cellSize - 1;
                int h = cellSize - 1;
                if (x > 0 && x + w <= canvas.ScaledWidth && y > 0 && y + h <= canvas.ScaledHeight) // pygame prolly check and doesnt print outsdie so you gotta check if teh block fits in the canvas here
                {
                    canvas.AddRectangle(x, y, w, h, color[id]);    // draw tetrimino
                }

               
            }
            Console.WriteLine($"y: {GetCellPositions().First().Row}");
        }
    }
}