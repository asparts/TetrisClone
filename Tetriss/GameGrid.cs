using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameGrid
    {

        private readonly int[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        public int this[int rows, int columns] {

            get => grid[rows, columns];
            set => grid[rows, columns] = value;
        }
        public GameGrid(int rows, int columns) {

            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];

        }
        public bool IsInside(int row, int column) {
            //To check if given row and column are inside the grid
           if(row >= 0 && row < Rows && column >= 0 && column < Columns)
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty(int row, int column) {
            //to check if given row/column is empty == 0
            //and also that the given row/column is inside the gamegrid

            return IsInside(row, column) && grid[row, column] == 0;
        }
        public bool IsRowFull(int row) {

            for (int column = 0; column < Columns; column++) {
                //Check the row value here column by column. If equals to 0, row is not full
                if (grid[row, column] == 0) {
                    return false;
                }

            }
            return true;
        }
        public bool IsRowEmpty(int row) {

            for (int column = 0; column < Columns; column++)
            {
                //Check the row value here column by column. If equals something else than 0, row is not full
                if (grid[row, column] != 0)
                {
                    return false;
                }

            }
            return true;
        }
        private void ClearRow(int row) {

            for (int column = 0; column < Columns; column++) {

                grid[row, column] = 0;
            }

        }
        private void MoveRowDown(int row, int numRows) {
            for (int column = 0; column < Columns; column++)
            {
                grid[row + numRows, column] = grid[row, column];
                grid[row, column] = 0;
            }
        }
        public int ClearFullRows() {

            int cleared = 0;

            for (int row = Rows - 1; row >= 0; row--) {

                if (IsRowFull(row))
                {

                    ClearRow(row);
                    cleared++;
                }
                else if (cleared > 0) {
                    MoveRowDown(row, cleared);
                }

            }
            return cleared;

        }
    }
}
