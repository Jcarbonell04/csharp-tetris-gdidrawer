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
        public Color[] colors; // get from color class later

        public Block(int id)
        {
            this.id = id;
            cells = new Position[4,4];
            cellSize = 30;
            rowOffset = 0;
            colOffset = 0;
            rotationState = 0;
            colors = new Color[] {RandColor.GetColor(), RandColor.GetColor(), RandColor.GetColor()
                                  , RandColor.GetColor(), RandColor.GetColor(), RandColor.GetColor()
                                  , RandColor.GetColor(),};
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

        void Rotate()
        {
            rotationState += 1;
            if (rotationState == cells.GetLength(0)) ; // cells.GetLength(0)) = num rotation states
            rotationState = 0;                         // cells.GetLength(1)) = num tiles per rotationd
        }

        void UndoRotation()
        {
            rotationState -= 1;
            if (rotationState == -1)
                rotationState = cells.GetLength(0) - 1;
        }

        public void Draw(CDrawer canvas, int offsetX, int offsetY)
        {
            foreach (Position tile in GetCellPositions())
            {
                canvas.AddRectangle(tile.Col * cellSize + offsetX, tile.Row * cellSize + offsetY
                                    , cellSize - 1, cellSize - 1, colors[id]);
            }
        }

    }
}