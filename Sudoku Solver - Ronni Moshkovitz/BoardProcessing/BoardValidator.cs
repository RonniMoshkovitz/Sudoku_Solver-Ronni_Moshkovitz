using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    internal class BoardValidator
    {
        private Board _board;

        private HashSet<int> _validRows = new HashSet<int>();
        private HashSet<int> _validColumns = new HashSet<int>();
        private HashSet<int> _validBoxes = new HashSet<int>();

        private void ClearSetup(Board board)
        {
            _validRows.Clear();
            _validColumns.Clear();
            _validBoxes.Clear();

            _board = board;
        }
        internal void Validate(Board board)
        {
            ClearSetup(board);

            for (int i = 0; i < _board.Side; i++)
            {
                for (int j = 0; j < _board.Side; j++)
                {
                    if (!_board.IsEmptyCell(i, j))
                    {
                        ValidateRow(i);
                        ValidateColumn(j);
                        ValidateBox(i, j);
                    }
                }
            }
        }
        internal void ValidateRow(int row)
        {
            if (_validRows.Contains(row))
                return;
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < _board.Side; i++)
            {
                int cellValue = _board[row, i];
                if (!_board.IsEmptyCell(row, i))
                {
                    if (seen.Contains(cellValue))
                        throw new IllegalRowException(_board.GetPresentabeValue(row, i), row);
                    seen.Add(cellValue);
                }
            }
            _validRows.Add(row);
        }

        internal void ValidateColumn(int column)
        {
            if (_validColumns.Contains(column))
                return;
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < _board.Side; i++)
            {
                int cellValue = _board[i, column];
                if (!_board.IsEmptyCell(i, column))
                {
                    if (seen.Contains(cellValue))
                        throw new IllegalColumnException(_board.GetPresentabeValue(i, column), column);
                    seen.Add(cellValue);
                }
            }
            _validColumns.Add(column);
        }

        internal void ValidateBox(int row, int column)
        {
            int startRow = ToBoxIndex(row);
            int startCol = ToBoxIndex(column);

            int boxNum = startRow % _board.BoxSide + startCol / _board.BoxSide;

            if (_validBoxes.Contains(boxNum))
                return;
            HashSet<int> seen = new HashSet<int>();
            for (int i = startRow; i < _board.BoxSide + startRow; i++)
            {
                for (int j = startCol; j < _board.BoxSide + startCol; j++)
                {
                    int cellValue = _board[i, j];
                    if (!_board.IsEmptyCell(i, j))
                    {
                        if (seen.Contains(cellValue))
                            throw new IllegalBoxException(_board.GetPresentabeValue(i, j), boxNum);
                        seen.Add(cellValue);
                    }
                }
            }
            _validBoxes.Add(boxNum);
        }

        private int ToBoxIndex(int i) { return (i / _board.BoxSide) * _board.BoxSide; }
    }
}
