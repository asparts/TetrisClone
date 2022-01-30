using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock {

            get => currentBlock;
            private set {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++) {
                    //FOR BETTER BLOCK SPAWNING
                    currentBlock.Move(1, 0);

                    if (!BlockFits()) {

                        currentBlock.Move(-1, 0);
                    }
                }

            }


        }
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public int score { get; private set; }

        public Block HeldBlock { get; private set; } 
        public bool CanHold { get; private set; }
        public GameState() {

            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }
        private bool BlockFits() {
            //Loop over positions of currentblock, if any of them is outside the grid or overlapping with other tile, we return false. Otherwise we return true.
            foreach (Position p in CurrentBlock.TilePositions()) {

                if (!GameGrid.IsEmpty(p.Row, p.Column)) { 
                    return false; 
                }
            
            }

            return true;
        }
        public void HoldBlock() {

            if (!CanHold) {
                return;
            }
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else { //swapping the heldblock
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }
            //So we cant just spam the hold
            CanHold = false;
        }
        public void RotateBlockCW() {

            CurrentBlock.RotateCW();
            if (!BlockFits()) { 
            CurrentBlock.RotateCCW();
            }

        }
        public void RotateBlockCCW()
        {

            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }

        }
        public void MoveBlockLeft() {

            CurrentBlock.Move(0, -1);
            if (!BlockFits()) {
                MoveBlockRight();
            }
        }
        public void MoveBlockRight() {

            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                MoveBlockLeft();
            }
        }
        private bool IsGameOver() { 
        
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        private void PlaceBlock() {

            foreach (Position p in CurrentBlock.TilePositions()) {

                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }
            score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }


        }
        public void MoveBlockDown() { 
            CurrentBlock.Move(1,0);

            if (!BlockFits()) { 
            
            CurrentBlock.Move(-1,0);
                PlaceBlock();
            }

        }
        public void MoveBlockDownFast()
        {


            for (int i = 0; i < 22; i++) {


                CurrentBlock.Move(1, 0);
                if (!BlockFits())
                {

                    CurrentBlock.Move(-1, 0);
                    PlaceBlock();
                    break;
                }
            }
            
        }


    }
}
