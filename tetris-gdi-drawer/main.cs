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
        private grid gameGrid = new grid();
        private game game =  new game();

        public main()
        {
            InitializeComponent();
            KeyPreview = true;
            Console.WriteLine("ic");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("keydown");
            // MessageBox.Show($"Pressed: {e.KeyCode}");
            if (game.gameOver)
            {
                game.gameOver = false;
                game.Reset();
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Left:
                    game.MoveLeft();
                    Console.WriteLine("left");
                    break;
                case Keys.Right:
                    game.MoveRight();
                    break;
                case Keys.Down:
                    game.MoveDown();
                    game.UpdateScore(0, 1);
                    break;
                case Keys.Up:
                    game.Rotate();
                    break;
            }

            Redraw(); // like pygame.display.update()
        }


        public void DrawGrid(CDrawer canvas)
        {
            int cols = 10;
            int rows = 20;
            int cellSize = 30;  
            int offsetX = 10;   
            int offsetY = 10;  

            Color gridColor = Color.LightBlue;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // int cellValue = grid[row, col]; colors[cellValue])
                    canvas.AddRectangle(offsetX + col * cellSize + 1,
                    offsetY + row * cellSize + 1,
                    cellSize - 1, cellSize - 1,
                    gridColor);

                }
            }
        }

        private void UI_Start_Btn_Click(object sender, EventArgs e)
        {
            canvas = new CDrawer(canvasWidth, canvasHeight);
            // gameTimer.Tick += GameUpdate_Tick;
            UI_GameUpdate_Tmr.Start();

            canvas.Clear();
            // canvas.AddText("testing", 40, Color.Red);
            // DrawGrid(canvas); hardcoded
            canvas.Render();
            gameGrid.PrintGrid();   // method in grid class
            gameGrid.Draw(canvas);
        }

        private void UI_GameUpdate_Tmr_Tick(object sender, EventArgs e)
        {
            // every 200mS move tetromino 
            if (!game.gameOver) // game still running
                game.MoveDown();
        }

        private void Redraw()
        {
            canvas.Clear(); // like screen.fill()
            game.Draw(canvas); // custom draw logic for grid + block
            canvas.Render();
        }

      
    }
}
