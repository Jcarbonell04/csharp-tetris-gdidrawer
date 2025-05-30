using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace tetris_gdi_drawer
{
    public partial class Form1 : Form
    {
        private const int canvasHeight = 600;
        private const int canvasWidth = 800;
        private CDrawer canvas; 
        Timer gameTimer = new Timer();
        gameTimer.Interval = 200; // 200 ms like `pygame.time.set_timer`
        gameTimer.Tick += GameUpdate_Tick;
        gameTimer.Start();

        public Form1()
        {
            InitializeComponent();
            canvas = new CDrawer(canvasWidth, canvasHeight);
        }
    }
}
