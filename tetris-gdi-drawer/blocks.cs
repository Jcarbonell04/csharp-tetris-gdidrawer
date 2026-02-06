//***********************************************************************************
// Program: blocks.cs
// Description: Defines the 7 Tetris tetromino shapes and their rotation states
//              inherits from main block.cs 
// Author: Jaedyn Carbonell
//***********************************************************************************

namespace tetris_gdi_drawer
{
    public class lBlock : Block
    {
        public lBlock() : base(1)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(0,2), new Position(1,0), new Position(1,1), new Position(1,2) }, // Rotation 0
                new Position[] { new Position(0,1), new Position(1,1), new Position(2,1), new Position(2,2) }, // Rotation 1
                new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(2,0) }, // Rotation 2
                new Position[] { new Position(0,0), new Position(0,1), new Position(1,1), new Position(2,1) }  // Rotation 3
            };
            Move(0, 3);
        }
    }

    public class jBlock : Block
    {
        public jBlock() : base(2)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(0,0), new Position(1,0), new Position(1,1), new Position(1,2) },
                new Position[] { new Position(0,1), new Position(0,2), new Position(1,1), new Position(2,1) },
                new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(2,2) },
                new Position[] { new Position(0,1), new Position(1,1), new Position(2,0), new Position(2,1) }
            };
            Move(0, 3);
        }
    }

    public class iBlock : Block
    {
        public iBlock() : base(3)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(1,3) },
                new Position[] { new Position(0,2), new Position(1,2), new Position(2,2), new Position(3,2) },
                new Position[] { new Position(2,0), new Position(2,1), new Position(2,2), new Position(2,3) },
                new Position[] { new Position(0,1), new Position(1,1), new Position(2,1), new Position(3,1) }
            };
            Move(-1, 3);
        }
    }

    public class oBlock : Block
    {
        public oBlock() : base(4)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(0,0), new Position(0,1), new Position(1,0), new Position(1,1) },
                new Position[] { new Position(0,0), new Position(0,1), new Position(1,0), new Position(1,1) },
                new Position[] { new Position(0,0), new Position(0,1), new Position(1,0), new Position(1,1) },
                new Position[] { new Position(0,0), new Position(0,1), new Position(1,0), new Position(1,1) }
            };
            Move(0, 4);
        }
    }

    public class sBlock : Block
    {
        public sBlock() : base(5)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(0,1), new Position(0,2), new Position(1,0), new Position(1,1) },
                new Position[] { new Position(0,1), new Position(1,1), new Position(1,2), new Position(2,2) },
                new Position[] { new Position(1,1), new Position(1,2), new Position(2,0), new Position(2,1) },
                new Position[] { new Position(0,0), new Position(1,0), new Position(1,1), new Position(2,1) }
            };
            Move(0, 3);
        }
    }

    public class tBlock : Block
    {
        public tBlock() : base(6)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(0,1), new Position(1,0), new Position(1,1), new Position(1,2) },
                new Position[] { new Position(0,1), new Position(1,1), new Position(1,2), new Position(2,1) },
                new Position[] { new Position(1,0), new Position(1,1), new Position(1,2), new Position(2,1) },
                new Position[] { new Position(0,1), new Position(1,0), new Position(1,1), new Position(2,1) }
            };
            Move(0, 3);
        }
    }

    public class zBlock : Block
    {
        public zBlock() : base(7)
        {
            cells = new Position[4][]
            {
                new Position[] { new Position(0,0), new Position(0,1), new Position(1,1), new Position(1,2) },
                new Position[] { new Position(0,2), new Position(1,1), new Position(1,2), new Position(2,1) },
                new Position[] { new Position(1,0), new Position(1,1), new Position(2,1), new Position(2,2) },
                new Position[] { new Position(0,1), new Position(1,0), new Position(1,1), new Position(2,0) }
            };
            Move(0, 3);
        }
    }
}