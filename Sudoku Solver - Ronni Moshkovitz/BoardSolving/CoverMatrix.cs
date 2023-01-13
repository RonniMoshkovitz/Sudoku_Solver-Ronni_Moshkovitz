using Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class, CoverMatrix, defines an object that creates an exact cover matrix for a given board.
    internal class CoverMatrix
    {
        // There are 4 constraints for a sudoku puzzle (cell, row, column, box)
        private const int CONSTRAINTS = 4;

        // Sudoku board dimensions
        private int _side, _boxSide, _boardSize;

        // Exact cover matrix that is generated to match the sudoku (describes the sudoku board as an exact cover problem)
        private byte[,] _cover;

        // This function sets all the required dimension for the creation of the board's exact cover matrix.
        private void SetupDimensions(Board board, out int coverRows, out int coverColumns)
        {
            _side = board.Side;
            _boxSide = board.BoxSide;
            _boardSize = _side * _side;

            // In the cover matrix each empty cell gets all possible options (side amount of options), while the already filled cells get only one option (the given value).
            coverRows = board.EmptyCount * _side + _boardSize - board.EmptyCount;
            // Each constraint has an amount of fields (in the row) as the amount of cells on the board.
            coverColumns = _boardSize * CONSTRAINTS;
        }

        // This function creates an exact cover matrix that matchs the given sudoku board (describes the sudoku board as an exact cover problem).
        // It returns the generated cover matrix.
        internal byte[,] GenerateCoverMatrix(Board board)
        {
            SetupDimensions(board, out int coverRows, out int coverColumns);
            _cover = new byte[coverRows, coverColumns];

            // Indicates the row for the next option to be written (in the cover matrix).
            int optionsCount = 0;

            for (int row = 0; row < _side; row++)
            {
                for (int column = 0; column < _side; column++)
                {
                    if (board.IsEmptyCell(row, column))
                    {
                        AddOptionsConstraints(row, column, ref optionsCount);
                    }
                    else
                    {
                        AddOptionConstraintsLine(row, column, board[row, column] - 1, ref optionsCount);
                    }
                }
            }
            return _cover;
        }

        // This function adds all the possiblities for a single empty cell as multiple
        // constrainst lines in the cover matrix (one line for each possibility).
        private void AddOptionsConstraints(int row, int column, ref int rowForLineConstraint)
        {
            // Add all the "side" amount of options for the empty cell.
            for (int i = 0; i < _side; i++)
            {
                AddOptionConstraintsLine(row, column, i, ref rowForLineConstraint);
            }
        }

        // This Function adds a single constraints line to the cover matrix (a single option for a cell's value).
        private void AddOptionConstraintsLine(int row, int column, int valueOrder, ref int rowForLineConstraint)
        {
            // Get all 4 of the constraint's column indexes.
            int cellC = GetCellNumConstraint(row, column);
            int rowC = GetRowConstraint(row, valueOrder);
            int columnC = GetColumnConstraint(row, column, valueOrder);
            int boxC = GetBoxConstraint(row, column, valueOrder);

            // Mark all the constraints for this option (in the row).
            _cover[rowForLineConstraint, cellC] = _cover[rowForLineConstraint, rowC] = _cover[rowForLineConstraint, columnC] = _cover[rowForLineConstraint, boxC] = 1;

            // progress to the next row in the cover matrix.
            rowForLineConstraint++;
        }

        // This function calculates the cell constraint index (equal to the cell's number in order, counting a row after row starting from the left).
        // It returns the cell constraint index.
        private int GetCellNumConstraint(int row, int column)
        {
            return row * _side + column;
        }

        // This function calculates the row constraint index (starts after all the cell constraints fields, it represents the row number in order from the upper row down, and the cell's value).
        // It returns the row constraint index.
        private int GetRowConstraint(int row, int valueOrder)
        {
            return _boardSize + row * _side + valueOrder;
        }

        // This function calculates the column constraint index (starts after all the cell and the row constraints fields. It represents the column number in order from the left to the right, and the cell's value).
        // It returns the column constraint index.
        private int GetColumnConstraint(int row, int column, int valueOrder)
        {
            return _boardSize * 2 + column * _side + valueOrder;
        }

        // This function calculates the box constraint index (starts after all the cell, row, and column constraints fields. It represents the box number in order from the upper left box to the lower right box, and the cell's value).
        // It returns the box constraint index.
        private int GetBoxConstraint(int row, int column, int valueOrder)
        {
            return _boardSize * 3 + (row / _boxSide * _boxSide + column / _boxSide) * _side + valueOrder;
        }

    }
}
