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
        bool gameOver;
        int score;

        public game()
        {
            grid grid = new grid();
            List<Block> blocks = new List<Block> 
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

        void UpdateScore(int linesCleared, int moveDownPoints)
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
            return block;
        }

        void MoveLeft()
        {
            currentBlock.Move(0, -1);
            // neeed to implement block fits and blockinside

        }

        // move right

        // move down

        // lock block

        // reset
        void Reset()
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
            Block tiles = currentBlock.GetCellPositions();
            for var tile in tiles {
                if grid.

            // having a brain fary i will come back to this
            }
            return true;
        }

        // rotate

        // blcok inside

        // draw
        void Draw(CDrawer canvas)
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
