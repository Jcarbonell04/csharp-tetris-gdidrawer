//***********************************************************************************
// Program: main.cs
// Description: main windows form runnig the game using GDIDrawer
//              initializes game, handles game, update timers + rendering
// Author: Jaedyn Carbonell
//***********************************************************************************

using System;
using System.Windows.Forms;
using GDIDrawer;
using System.Drawing;

namespace tetris_gdi_drawer
{
    public partial class main : Form
    {
        // VARIABLE DECLARATION
        private const int _canvasHeight = 620;
        private const int _canvasWidth = 500;
        private CDrawer _canvas;
        private grid _gameGrid = new grid();
        private game _game = new game();
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

            // Center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Shown += Main_Shown;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (_canvas == null)
                return;
            Activate(); 
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
            if (_game._gameOver)
            {
                _game._gameOver = false;
                _game.Reset();
                return;
            }

            switch (keyCode)
            {
                case Keys.Left:
                    _game.MoveLeft();
                    Console.WriteLine("left");
                    break;
                case Keys.Right:
                    _game.MoveRight();
                    Console.WriteLine("right");
                    break;
                case Keys.Down:
                    _game.SoftDrop();
                    //game.UpdateScore(0, 1);
                    Console.WriteLine("down");
                    break;
                case Keys.Up:
                    _game.Rotate();
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
            // Get the screen the form is currently on
            Screen currentScreen = Screen.FromControl(this);
            Rectangle workArea = currentScreen.WorkingArea;

            _canvas = new CDrawer(_canvasWidth, _canvasHeight);

            // Center canvas on THIS screen
            int canvasX = workArea.Left + (workArea.Width - _canvasWidth) / 2;
            int canvasY = workArea.Top + (workArea.Height - _canvasHeight) / 2;
            _canvas.Position = new Point(canvasX, canvasY);

            // Place form to the left of the canvas
            int gap = 20;
            int formX = canvasX - this.Width - gap;
            int formY = canvasY;

            // Clamp so it never leaves the monitor
            formX = Math.Max(workArea.Left, formX);
            formY = Math.Max(workArea.Top, formY);

            this.Location = new Point(formX, formY);

            //// Center canvas on screen
            //int canvasX = (screenWidth - _canvasWidth) / 2;
            //int canvasY = (screenHeight - _canvasHeight) / 2;
            //_canvas.Position = new Point(canvasX, canvasY);

            //// Move form to the LEFT of the canvas
            //int gap = 20; // space between form and canvas
            //int formX = canvasX - this.Width - gap;
            //int formY = canvasY; // align tops (or tweak if you want)

            //this.Location = new Point(formX, formY);

            //int x = (screenWidth - _canvasWidth) / 2;
            //int y = (screenHeight - _canvasHeight) / 2;
            //_canvas.Position = new Point(x, y);

            ////this.Location = new Point(_canvasWidth, _canvasHeight);

            UI_GameUpdate_Tmr.Start();

            _canvas.Clear();
            // canvas.AddText("testing", 40, Color.Red);
            _canvas.Render();
            _gameGrid.PrintGrid();   // method in grid class
            _gameGrid.Draw(_canvas);

            _canvas.KeyboardEvent += Canvas_KeyboardEvent;
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
            if (!_game._gameOver) // game still running
                _game.SoftDrop();
            Redraw();
        }

        /// <summary>
        /// clears and redraws the canvas
        /// </summary>
        private void Redraw()
        {
            _canvas.Clear(); // like screen.fill()
            _game.Draw(_canvas); // custom draw logic for grid + block
            _canvas.Render();
        }
    }
}
