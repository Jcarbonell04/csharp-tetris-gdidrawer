using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris_gdi_drawer
{
    // internal class block
    // {
    // }

    public class Block
    {
        protected int x;
        protected int y;

        public Block(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}