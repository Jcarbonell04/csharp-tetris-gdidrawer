using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris_gdi_drawer
{
    public class game
    {
        Random rand = new Random();
        grid grid;
        List<Block> blocks = new List<Block>();
        Block currentBlock; // get random block
        Block nextBlock; // get random block
        public bool gameOver;
        int score;

        public game()
        {
            grid = new grid();
            blocks = new List<Block> 
            {
                new iBlock(),
                new jBlock(),
                new lBlock(),
                new oBlock(),
                new sBlock(),
                new tBlock(),
                new zBlock()
            };
            currentBlock = GetRandomBlock(); // get random block
            nextBlock = GetRandomBlock(); // get random block
            gameOver = false;
            score = 0;
        }

        public void UpdateScore(int linesCleared, int moveDownPoints)
        {
            if (linesCleared == 1)
                score += 100;
            else if (linesCleared == 2)
                score += 200;
            else if (linesCleared == 3)
                score += 300;
            else if (linesCleared == 4)
                score += 500;
            score += moveDownPoints;
        }

        Block GetRandomBlock()
        {
            if (blocks.Count() == 0)
            {
                blocks = new List<Block>
                {
                    new iBlock(),
                    new jBlock(),
                    new lBlock(),
                    new oBlock(),
                    new sBlock(),
                    new tBlock(),
                    new zBlock()
                };
            }
            Block block = blocks[rand.Next(blocks.Count)];
            blocks.Remove(block); // do not forget, remove the block from the lsit
            return block;
        }

        public void MoveLeft()
        {
            currentBlock.Move(0, -1);
            if (!BlockInside() || !BlockFits())
                currentBlock.Move(0, 1);
        }

        // move right
         public void MoveRight()
        {
            currentBlock.Move(0, 1);
            if (!BlockInside() || !BlockFits())
                currentBlock.Move(0, -1);
        }

        // move down
        public void MoveDown()
        {
            currentBlock.Move(1, 0);
            if (!BlockInside() || !BlockFits())
                currentBlock.Move(-1, 0);
        }

        // lock block
        void LockBlock()
        {
            Position[] tiles = currentBlock.GetCellPositions();
            foreach (Position tile in tiles)
                grid.gameGrid[tile.Row,tile.Col] = currentBlock.id;
            currentBlock = nextBlock;
            nextBlock = GetRandomBlock();
            int rowsCleared = grid.ClearFullRow();

            if (rowsCleared > 0)
                UpdateScore(rowsCleared, 0);
            if (!BlockFits())
                gameOver = false;
        }

        // reset
        public void Reset()
        {
            grid.Reset();
            blocks = new List<Block>
            {
                new iBlock(),
                new jBlock(),
                new lBlock(),
                new oBlock(),
                new sBlock(),
                new tBlock(),
                new zBlock()
            };
            currentBlock = GetRandomBlock();
            nextBlock = GetRandomBlock();
            score = 0;

        }

        // block fits
        bool BlockFits()
        {
            Position[] tiles = currentBlock.GetCellPositions();
            foreach (var tile in tiles) {
                if (!grid.IsEmpty(tile.Row, tile.Col))
                    return false;
            }
            return true;
        }

        // rotate
        public void Rotate()
        {
            currentBlock.Rotate();
            if (!BlockInside() || !BlockFits())
                currentBlock.UndoRotation();
        }

        // blcok inside
        bool BlockInside()
        {
            Position[] tiles = currentBlock.GetCellPositions();
            foreach (var tile in tiles)
            {
                if (!grid.IsInside(tile.Row, tile.Col))
                    return false;
            }
            return true;
        }

        // draw
        public void Draw(CDrawer canvas)
        {
            grid.Draw(canvas);
            currentBlock.Draw(canvas, 1 + 10, 1 + 10);

            if (nextBlock.id == 3)      // iBlock
                nextBlock.Draw(canvas, 255, 290);
            else if (nextBlock.id == 4) // oBlock
                nextBlock.Draw(canvas, 255, 280);
            else
                nextBlock.Draw(canvas, 270, 270); // everythign else
        }

    }
}
