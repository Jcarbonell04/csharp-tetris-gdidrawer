//***********************************************************************************
// Program: game.cs
// Description: handles the core game logic for Tetris, including the grid,
//              active and next blocks, movement, rotation, and scoring
// Author: Jaedyn Carbonell
//***********************************************************************************
using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace tetris_gdi_drawer
{
    public class game
    {
        private Random _rand = new Random();
        private grid _grid;
        private List<Block> _blockList = new List<Block>();
        private Block _currentBlock; // current block falling
        private Block _nextBlock; 
        public bool _gameOver;
        private int _score;

        /// <summary>
        /// CTOR -  initialize the grid, list holding tetrominoes, current block falling,
        /// next block, score and gameOver flag
        /// </summary>
        public game()
        {
            _grid = new grid(); // new game grid
            _blockList = new List<Block> // list to hold blocks
            {
                new iBlock(),
                new jBlock(),
                new lBlock(),
                new oBlock(),
                new sBlock(),
                new tBlock(),
                new zBlock()
            };
            _currentBlock = GetRandomBlock(); // get random block
            _nextBlock = GetRandomBlock(); // get random block
            _gameOver = false; // game is over
            _score = 0;
        }

        /// <summary>
        /// updates the current score based on how many line were cleared by the player
        /// </summary>
        /// <param name="linesCleared">lines cleared by the player</param>
        /// <param name="moveDownPoints"></param>
        public void UpdateScore(int linesCleared, int moveDownPoints)
        {
            if (linesCleared == 1)
                _score += 100;
            else if (linesCleared == 2)
                _score += 200;
            else if (linesCleared == 3)
                _score += 300;
            else if (linesCleared == 4) // tetris
                _score += 500;
            _score += moveDownPoints;    // 1 point 
        }

        /// <summary>
        /// every 7 blocks, generate 7 random tetromino, 7 bag system
        /// </summary>
        /// <returns>returns block for current block</returns>
        Block GetRandomBlock()
        {
            if (_blockList.Count() == 0) 
            {
                _blockList = new List<Block>
                {
                    new iBlock(),
                    new jBlock(),
                    new lBlock(),
                    new oBlock(),
                    new sBlock(),
                    new tBlock(),
                    new zBlock()
                };
            }
            
            Block block = _blockList[_rand.Next(_blockList.Count)];
            _blockList.Remove(block); // do not forget, remove the block from the list
            return block;
        }

        /// <summary>
        /// Move the tetrominio left
        /// </summary>
        public void MoveLeft()
        {
            _currentBlock.Move(0, -1);
            if (!InBounds() || !CollisionCheck()) // out of gamegrid and collides with other blocks
                _currentBlock.Move(0, 1);
        }

        /// <summary>
        /// Move the tetrominio right
        /// </summary>
        public void MoveRight()
        {
            _currentBlock.Move(0, 1);
            if (!InBounds() || !CollisionCheck())
                _currentBlock.Move(0, -1);
        }

        /// <summary>
        /// Move the tetrominio down
        /// </summary>
        public void SoftDrop()
        {
            Console.WriteLine("DOWN 1");
            _currentBlock.Move(1, 0);
            if (!InBounds() || !CollisionCheck())
                _currentBlock.Move(-1, 0);
            LockBlock();
        }

        /// <summary>
        /// - converts falling block intoa fixed block on the grid
        /// - add block id to game.gameGrid
        /// - spawn next block, and generate a new one
        /// - clear row
        /// - update score
        /// - checks for gameover
        /// </summary>
        void LockBlock()
        {
            // convert falling block into a fixed block
            Position[] tiles = _currentBlock.GetCellPositions();
            foreach (Position tile in tiles)
                _grid.gameGrid[tile.Row,tile.Col] = _currentBlock.id;
            
            // spawn next block and generate a new block
            _currentBlock = _nextBlock;
            _nextBlock = GetRandomBlock();
            
            // Clear rows
            int rowsCleared = _grid.ClearFullRow();

            // Update score 
            if (rowsCleared > 0)
                UpdateScore(rowsCleared, 0);
            
            // Check for game over
            if (!CollisionCheck())
                _gameOver = false;
        }

        /// <summary>
        /// RESET GAME STATE
        /// - Clear grid
        /// - Refill block list
        /// - Generate new current next block
        /// - Reset score
        /// </summary>
        public void Reset()
        {
            _grid.Reset(); // reset game grid

            _blockList = new List<Block> // refill blovk bag
            {
                new iBlock(),
                new jBlock(),
                new lBlock(),
                new oBlock(),
                new sBlock(),
                new tBlock(),
                new zBlock()
            };

            _currentBlock = GetRandomBlock();   // generate new block
            _nextBlock = GetRandomBlock();      // generate new block
            _score = 0;                         // reset score
        }

        /// <summary>
        /// Rotate _currentBlock if within grid bounds and causes no collisiom
        /// </summary>
        public void Rotate()
        {
            _currentBlock.Rotate();
            if (!InBounds() || !CollisionCheck())
                _currentBlock.UndoRotation();
        }

        /// <summary>
        /// 
        /// </summary>
        bool InBounds()
        {
            Position[] tiles = _currentBlock.GetCellPositions();
            foreach (var tile in tiles)
            {
                if (!_grid.IsInside(tile.Row, tile.Col))
                    return false;
            }
            return true;
        }

        // block fits
        bool CollisionCheck()
        {
            Position[] tiles = _currentBlock.GetCellPositions();
            foreach (var tile in tiles)
            {
                if (!_grid.IsEmpty(tile.Row, tile.Col))
                    return false;
            }
            return true;
        }

        // draw
        public void Draw(CDrawer canvas)
        {
            _grid.Draw(canvas);
            _currentBlock.Draw(canvas, 1 + 10, 1 + 10);

            if (_nextBlock.id == 3)      // iBlock
                _nextBlock.Draw(canvas, 255, 290);
            else if (_nextBlock.id == 4) // oBlock
                _nextBlock.Draw(canvas, 255, 280);
            else
                _nextBlock.Draw(canvas, 270, 270); // everythign else
        }

    }
}