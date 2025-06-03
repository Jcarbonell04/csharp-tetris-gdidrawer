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
    public partial class main : Form
    {
        private const int canvasHeight = 620;
        private const int canvasWidth = 500;
        private CDrawer canvas; 
        private Timer gameTimer = new Timer();
        

        public main()
        {
            InitializeComponent();
            canvas = new CDrawer(canvasWidth, canvasHeight);
            gameTimer.Interval = 200; // 200mS
            // gameTimer.Tick += GameUpdate_Tick;
            // gameTimer.Start();

            canvas.Clear();
            // canvas.AddText("testing", 40, Color.Red);
            DrawGrid(canvas);
            canvas.Render();
        }

        public void DrawGrid(CDrawer canvas)
        {
            int cols = 10;
            int rows = 20;
            int cellSize = 30;  
            int offsetX = 50;   
            int offsetY = 150;  

            Color gridColor = Color.LightBlue;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // int cellValue = grid[row, col]; colors[cellValue])
                    canvas.AddRectangle(col * cellSize + 10 + 1, 
                                        row * cellSize + 10 + 1, cellSize - 1, 
                                        cellSize - 1, 
                                        gridColor);
                }
            }
        }
    }
}
