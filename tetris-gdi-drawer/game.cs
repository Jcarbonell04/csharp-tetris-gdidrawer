using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris_gdi_drawer
{
    public class game
    {
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
            Block currentBlock; // get random block
            Block nextBlock; // get random block
            bool gameOver = false;
            int score = 0;
        }
    }
}
