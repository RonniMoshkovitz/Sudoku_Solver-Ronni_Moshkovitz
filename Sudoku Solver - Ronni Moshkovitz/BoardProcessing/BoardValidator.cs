using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class, BoardValidator, is in charge of validating a given board. It makes sure the board doesn't contradict the sudoku rules.
    internal class BoardValidator
    {
        // The board to validate.
        private Board _board;

        // Hash set to keep all the rows that were already validated.
        private HashSet<int> _validRows = new HashSet<int>();

        // HashSet to keep all the columns that were already validated.
        private HashSet<int> _validColumns = new HashSet<int>();

        // HashSet to keep all the boxes that were already validated.
        private HashSet<int> _validBoxes = new HashSet<int>();

        // This function sets the HashSets and the board to the starting position.
        private void ClearSetup(Board board)
        {
            // Sets the HashSets to be empty.
            _validRows.Clear();
            _validColumns.Clear();
            _validBoxes.Clear();

            // Sets the board to the given board.
            _board = board;
        }

        // This function validates The board.
        // It throws an error if the board is illegal.
        internal void Validate(Board board)
        {
            // Set the variables to starting position of the invalidities search.
            ClearSetup(board);

            // Iterate over each cell on the board, if it has a value, validate its houses.
            for (int row = 0; row < _board.Side; row++)
            {
                for (int column = 0; column < _board.Side; column++)
                {
                    if (!_board.IsEmptyCell(row, column))
                    {
                        // Cell has a value, validate its houses.
                        ValidateRow(row);
                        ValidateColumn(column);
                        ValidateBox(row, column);
                    }
                }
            }
        }

        // This function validates a given row. It makes sure each value in the row only appears once.
        // If the validation fails, an exception is thrown. If validation is complete, it adds it to the valid rows (no need to check again).
        internal void ValidateRow(int row)
        {
            // If already validated, no need to validate again.
            if (_validRows.Contains(row))
            {
                return;
            }

            // Collect all seen values in the row into the seen HasSet.
            HashSet<int> seen = new HashSet<int>();

            // Iterate over each cell in the row, if it has a value, check if it was already seen.
            for (int column = 0; column < _board.Side; column++)
            {
                int cellValue = _board[row, column];
                if (!_board.IsEmptyCell(row, column))
                {
                    // If value was already seen throw an error (illeagal row), else add it to the seen set.
                    if (seen.Contains(cellValue))
                    {
                        throw new IllegalRowException(_board.GetPresentabeValue(row, column), row);
                    }
                    seen.Add(cellValue);
                }
            }
            // Validation complete. Add to validated set.
            _validRows.Add(row);
        }

        // This function validates a given column. It makes sure each value in the column only appears once.
        // If the validation fails, an exception is thrown. If validation is complete, it adds it to the valid columns (no need to check again).
        internal void ValidateColumn(int column)
        {
            // If already validated, no need to validate again.
            if (_validColumns.Contains(column))
            {
                return;
            }

            // Collect all seen values in the column into the seen HasSet.
            HashSet<int> seen = new HashSet<int>();

            // Iterate over each cell in the column, if it has a value, check if it was already seen.
            for (int row = 0; row < _board.Side; row++)
            {
                int cellValue = _board[row, column];
                if (!_board.IsEmptyCell(row, column))
                {
                    // If value was already seen throw an error (illeagal column), else add it to the seen set.
                    if (seen.Contains(cellValue))
                    {
                        throw new IllegalColumnException(_board.GetPresentabeValue(row, column), column);
                    }
                    seen.Add(cellValue);
                }
            }
            // Validation complete. Add to validated set.
            _validColumns.Add(column);
        }

        // This function validates a given box (according to the given cell's index). It makes sure each value in the box only appears once.
        // If the validation fails, an exception is thrown. If validation is complete, it adds it to the valid boxes (no need to check again).
        internal void ValidateBox(int row, int column)
        {
            // Get box' starting index.
            int startRow = ToBoxIndex(row);
            int startCol = ToBoxIndex(column);

            // Get box number (in boxes order).
            int boxNum = startRow % _board.BoxSide + startCol / _board.BoxSide;

            // If already validated, no need to validate again.
            if (_validBoxes.Contains(boxNum))
            {
                return;
            }

            // Collect all seen values in the box into the seen HasSet.
            HashSet<int> seen = new HashSet<int>();

            // Iterate over each cell in the box, if it has a value, check if it was already seen.
            for (int i = startRow; i < _board.BoxSide + startRow; i++)
            {
                for (int j = startCol; j < _board.BoxSide + startCol; j++)
                {
                    int cellValue = _board[i, j];
                    if (!_board.IsEmptyCell(i, j))
                    {
                        // If value was already seen throw an error (illeagal box), else add it to the seen set.
                        if (seen.Contains(cellValue))
                        {
                            throw new IllegalBoxException(_board.GetPresentabeValue(i, j), boxNum);
                        }
                        seen.Add(cellValue);
                    }
                }
            }
            // Validation complete. Add to validated set.
            _validBoxes.Add(boxNum);
        }

        // This function converts A given index (row/column) into the box' starting index.
        private int ToBoxIndex(int i) { return (i / _board.BoxSide) * _board.BoxSide; }
    }
}
