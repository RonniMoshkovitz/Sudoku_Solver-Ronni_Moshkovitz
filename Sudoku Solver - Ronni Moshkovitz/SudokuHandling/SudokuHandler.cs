using Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing;
using Sudoku_Solver___Ronni_Moshkovitz.BoardSolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling
{
    // This class SudokuHandler, is in charge of handaling all the sudoku related opperations. 
    public class SudokuHandler
    {
        // BoardProcessor to process the entered string into a sudoku board.
        private BoardProcessor _processor = new BoardProcessor();

        // SudokuSolver to solve the sudoku board.
        private SudokuSolver _solver = new SudokuSolver();

        // Timer to time the sudoku solving process.
        private Timer _timer = new Timer();

        // BoardDisplay to create the display for the sudoku board.
        private BoardDisplay _boardDisplay;
        // The board to handle.
        private Board _board;

        // Constructor for SudokuHandler. initializes the sudoku board from the given sudoku string.
        // May throw an exception if the sudoku string cant be parsed into a board, or represents an illegal board.
        public SudokuHandler(string boardString)
        {
            _board = _processor.ProcessBoard(boardString);
            _boardDisplay = new BoardDisplay(_board);
        }

        // This function returns a string representation of the sudoku's starting state.
        public string GetStartingSudoku()
        {
            return _boardDisplay.StartBoard;
        }

        // This function solves the sudoku (at least tries to), and updates the board string.
        // It returns the result (solution + time if its a solvable sudoku, unsolvable message otherwise) as a string.
        public string GetSolvedSudoku(ref string boardString)
        {
            // time and solve
            _timer.StartTimer();
            bool solved = _solver.Solve(_board);
            _timer.StopTimer();

            // if solved create string of result
            if (solved)
            {
                boardString = _processor.GetBoardStr(_board);
                return $"Solved:\n{_boardDisplay.CreateDisplay()}\n\nTook: {_timer.TimeInMilli} milisecounds\n\nSolved Sudoku string: {boardString}";
            }

            // set solved board string to empty string, and return unsolvable message.
            boardString = "";
            return "\nThis board is Unsolvable";
        }
    }
}
