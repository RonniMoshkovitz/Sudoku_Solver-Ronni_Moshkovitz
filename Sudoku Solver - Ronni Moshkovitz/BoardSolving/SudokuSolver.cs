using Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class, SudokuSolver represents a sudoku solver that gets a sudoku board and solves it.
    public class SudokuSolver
    {
        // A SolutionHandler to translate the exact cover solution to fill the board.
        private SolutionHandler _handler = new SolutionHandler();
        // A CoverMatrix to translate the board into an exact cover matrix.
        private CoverMatrix _coverMatrixGenerator = new CoverMatrix();
        // A DLXLayout to translate the exact cover matrix into a DLX layout (a four-way-linked list).
        private DLXLayout _dlxLayoutGenerator = new DLXLayout();

        // This function solves a given sudoku board.
        public bool Solve(Board sudoku)
        {
            // Generate the sudokus matching DLX layout (a four-way-linked list).
            ColumnNode dlxSudoku = _dlxLayoutGenerator.GenerateDLXLayout(_coverMatrixGenerator.GenerateCoverMatrix(sudoku));

            // Solve using the dancing links, algoritem x metode.
            DancingLinks dancingLinks = new DancingLinks(dlxSudoku);

            // Translate the solution only if there is one.
            if (dancingLinks.Solvable)
            {
                _handler.TranslateSolution(dancingLinks.Answer, sudoku);
            }

            return dancingLinks.Solvable;
        }
    }
}