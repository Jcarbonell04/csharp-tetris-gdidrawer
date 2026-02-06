//***********************************************************************************
// Program: color.cs
// Description: Defines the Block class used for Tetris tetrominoes, including
//              tile positions, rotation states, movement, and drawing logic.
// Author: Jaedyn Carbonell
//***********************************************************************************

using System.Collections.Generic;
using System.Drawing;

namespace tetris_gdi_drawer
{
    public class colors
    {
        // VARIBLE DECLARATIONS
        private Color darkGrey = Color.FromArgb(26, 31, 40);
        private Color orange = Color.FromArgb(226, 116, 17);
        private Color darkBlue = Color.FromArgb(44, 44, 127);
        private Color lightBlue = Color.FromArgb(59, 85, 162);
        private Color yellow = Color.FromArgb(237, 234, 4);
        private Color green = Color.FromArgb(47, 230, 23);
        private Color purple = Color.FromArgb(166, 0, 247);
        private Color red = Color.FromArgb(232, 18, 18);

        /// <summary>
        /// Returns a list of all block colors in order.
        /// The order can be used as IDs when drawing tetrominoes.
        /// </summary>
        /// <returns>List of Colors for each tetromino</returns>
        public List<Color> getCellColors()
        {
            return new List<Color>
            {
                darkGrey, orange, darkBlue, lightBlue, yellow, green, purple, red
            };
        }
    }
}

