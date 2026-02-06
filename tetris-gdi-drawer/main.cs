//***********************************************************************************
// Program: main.cs
// Description: main windows form runnig the game using GDIDrawer
//              initializes game, handles game, update timers + rendering
// Author: Jaedyn Carbonell
//***********************************************************************************

using System;
using System.Windows.Forms;
using GDIDrawer;

namespace tetris_gdi_drawer
{
    public partial class main : Form
    {
        // VARIABLE DECLARATION
        private const int canvasHeight = 620;
        private const int canvasWidth = 500;
        private CDrawer canvas;
        private grid gameGrid = new grid();
        private game game = new game();
        private Timer UI_GameUpdate_Tmr;

        /// <summary>
        /// CTOR - initializes form
        /// </summary>
        public main()
        {
            InitializeComponent();
            KeyPreview = true;          // capture keyboard input
            Console.WriteLine("ctor");

            UI_GameUpdate_Tmr = new Timer();
            UI_GameUpdate_Tmr.Interval = 200;
            UI_GameUpdate_Tmr.Tick += UI_GameUpdate_Tmr_Tick;
        }

        /// <summary>
        /// Keyboard event handler for GDIDrawer
        /// </summary>
        /// <param name="bIsDown">true if key is pressed, false if released</param>
        /// <param name="keyCode">Key that was pressed</param>
        /// <param name="dr">GDIDrawer canvas</param>
        private void Canvas_KeyboardEvent(bool bIsDown, Keys keyCode, CDrawer dr)
        {
            // ignore key releases
            if (!bIsDown)
            {
                return;
            }

            // if game is over, reset the game on any key press
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

        /// <summary>
        /// Inits game and canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// updates game state every 200ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_GameUpdate_Tmr_Tick(object sender, EventArgs e)
        {
            // every 200mS move tetromino 
            Console.WriteLine("200");
            if (!game._gameOver) // game still running
                game.SoftDrop();
            Redraw();
        }

        /// <summary>
        /// clears and redraws the canvas
        /// </summary>
        private void Redraw()
        {
            canvas.Clear(); // like screen.fill()
            game.Draw(canvas); // custom draw logic for grid + block
            canvas.Render();
        }
    }
}
