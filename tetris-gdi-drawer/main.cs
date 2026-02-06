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
    public partial class main : Form // printes scaled idk why
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

        private void Canvas_KeyboardEvent(bool bIsDown, Keys keyCode, CDrawer dr)
        {
            if (!bIsDown) 
            { 
                return; 
            }

            //Console.WriteLine("keydown");
            // MessageBox.Show($"Pressed: {e.KeyCode}");
            if (game._gameOver)
            {
                game._gameOver = false;
                game.Reset();
                return;
            }

            switch (keyCode)
            {
                case Keys.Left:
                    game.MoveLeft();
                    Console.WriteLine("left");
                    break;
                case Keys.Right:
                    game.MoveRight();
                    Console.WriteLine("right");
                    break;
                case Keys.Down:
                    game.SoftDrop();
                    //game.UpdateScore(0, 1);
                    Console.WriteLine("down");
                    break;
                case Keys.Up:
                    game.Rotate();
                    Console.WriteLine("rotATW");
                    break;
            }

            Redraw(); // like pygame.display.update()

            
        }

        private void UI_Start_Btn_Click(object sender, EventArgs e)
        {
            canvas = new CDrawer(canvasWidth, canvasHeight);
            UI_GameUpdate_Tmr.Start();

            canvas.Clear();
            // canvas.AddText("testing", 40, Color.Red);
            canvas.Render();
            gameGrid.PrintGrid();   // method in grid class
            gameGrid.Draw(canvas);

            canvas.KeyboardEvent += Canvas_KeyboardEvent;
        }

        private void UI_GameUpdate_Tmr_Tick(object sender, EventArgs e)
        {
            // every 200mS move tetromino 
            Console.WriteLine("200");
            if (!game._gameOver) // game still running
                game.SoftDrop();
            Redraw();
        }

        private void Redraw()
        {
            canvas.Clear(); // like screen.fill()
            game.Draw(canvas); // custom draw logic for grid + block
            canvas.Render();
        }

      
    }
}
