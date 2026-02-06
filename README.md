# csharp-tetris-gdidrawer
Using GDI Drawer and Windows Forms to make a Tetris Game

# Tetris Project Checklist/Goals

## Core (playable game)
- [x] Initialize GDIDrawer canvas  
- [x] Handle keyboard input  
- [x] Implement game loop with timer  
- [x] Position class (row, col)  
- [x] Grid class with bounds checking  
- [x] Base Block class  
- [x] Store block cells as `Position[4,4]`  
- [x] Implement all tetrominoes  
  - [x] I Block  
  - [x] O Block  
  - [x] T Block  
  - [x] S Block  
  - [x] Z Block  
  - [x] J Block  
  - [x] L Block  
- [ ] Implement rotation logic  
- [ ] Fix rotation state handling  
- [x] Implement left/right movement  
- [x] Fix Move() to use offsets  
- [x] Implement soft drop  
- [ ] Fix soft drop lock condition  
- [x] Implement collision detection  
- [ ] Ensure collision checks bounds  
- [x] Implement gravity (timer-based)  
- [ ] Lock block when it can’t move  
- [ ] Spawn next block  
- [ ] Detect game over condition  
- [ ] Implement line clear detection  
- [ ] Shift rows down after clear  
- [ ] Implement scoring system (basic points)  
- [x] Draw grid  
- [x] Draw active block  
- [ ] Fix draw offsets / alignment  

## Advanced (polish & extra gameplay)
- [ ] Show score dialog (current score)  
- [ ] Show next 3 upcoming blocks  
- [ ] Implement hard drop on spacebar  
- [ ] Show ghost block preview for hard drop  
- [ ] Real Tetris scoring  
  - 1 line = 100 points  
  - 2 lines = 300 points  
  - 3 lines = 500 points  
  - Tetris (4 lines) = 800 points  

## Stretch (high-level Tetris mechanics)
- [ ] Detect Mini T-Spin  
- [ ] Detect T-Spin single  
- [ ] Detect T-Spin double  
- [ ] Detect T-Spin triple  
- [ ] Additional scoring bonuses for T-Spins  

