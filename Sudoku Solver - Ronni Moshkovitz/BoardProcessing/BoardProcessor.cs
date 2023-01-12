using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class, BoardProcessor, is an object that processes a board
    // from an input string that represents the sudoku board to a board object.
    internal class BoardProcessor
    {
        // Validator to validate the entered string (see if can be parsed)
        private StringValidator _strValidator = new StringValidator();

        // Parser to parse the string sudoku into a sudoku grid
        private SudokuParser _parser = new SudokuParser();

        // Validator to validate the generated sudoku board (make sure the board stands by the sudoku rules)
        private BoardValidator _validator = new BoardValidator();

        // This function generates a sudoku board from a given string.
        // may throw an error if the given string is invalid, or represents an invalid board
        public Board ProcessBoard(string boardStr)
        {
            // Validats the string and returns the board's side
            int boardSide = _strValidator.Validate(boardStr);

            // Parses the string into a sudoku grid
            int[,] boardGrid = _parser.Parse(boardStr, boardSide);

            Board board = new Board(boardGrid, boardSide);

            // Checks if the board is valid (stands by the sudoku rules)
            _validator.Validate(board);

            return board;
        }

        // This function returns the board's string representation.
        public string GetBoardStr(Board board)
        {
            return _parser.Deparse(board.Grid);
        }
    }
}
