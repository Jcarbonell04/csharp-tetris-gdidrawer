using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris_gdi_drawer
{
    public class colors
    {
        public Color darkGrey = Color.FromArgb(26, 31, 40);
        public Color orange = Color.FromArgb(226, 116, 17);
        public Color darkBlue = Color.FromArgb(44, 44, 127);
        public Color lightBlue = Color.FromArgb(59, 85, 162);
        public Color yellow = Color.FromArgb(237, 234, 4);
        public Color green = Color.FromArgb(47, 230, 23);
        public Color purple = Color.FromArgb(166, 0, 247);
        public Color red = Color.FromArgb(232, 18, 18);

        public List<Color> getCellColors()
        {
            return new List<Color>
            {
                darkGrey, orange, darkBlue, lightBlue, yellow, green, purple, red
            };
        }
    }
}

