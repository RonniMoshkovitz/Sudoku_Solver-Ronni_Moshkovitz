using Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class, SolutionHandler, converts an exact cover solution to a sudoku solution.
    internal class SolutionHandler
    {
        // This function translates the given solution to the exact cover problem into a solution and places it on the board.
        public void TranslateSolution(Stack<DancingNode> answer, Board board)
        {
            // We translate each empty cell until no empty cell is left on the board.
            while (board.EmptyCount > 0)
            {
                DancingNode RowConstraintNode = FindCellRowConstraintNode(answer.Pop(), out int cellNum);
                PlaceAnswerOnBoard(board, RowConstraintNode, cellNum);
            }
        }

        // This function finds the relevant answer parts and sets the cell's serial number on the board,
        // and returns the node that represent the row constraint (to be translated later into the cells value).
        private DancingNode FindCellRowConstraintNode(DancingNode cellSolutionStart, out int cellNum)
        {
            // initialize variables
            DancingNode cellNumNode = cellSolutionStart;
            cellNum = int.Parse(cellNumNode.ColumnNode.Name);

            // Look for the cell constraint index (in the lowest column name in the total option).
            for (DancingNode cellSolutionPart = cellSolutionStart.Right; cellSolutionPart != cellSolutionStart; cellSolutionPart = cellSolutionPart.Right)
            {
                // Update the cellNumNode to point at the currently lowest column, and update the cellNum accordingly.
                int columnInCover = int.Parse(cellSolutionPart.ColumnNode.Name);
                if (columnInCover < cellNum)
                {
                    cellNum = columnInCover;
                    cellNumNode = cellSolutionPart;
                }
            }
            // Return the node to the right to the cellNumNode. This node is the Row constraint.
            return cellNumNode.Right;
        }

        // This function checks if the cell with the serial number cellNum needs to be filled.
        // If it does, it translates the RowConstraintNode into the actual value and places it on the board.
        private void PlaceAnswerOnBoard(Board board, DancingNode RowConstraintNode, int cellNum)
        {
            int side = board.Side;

            // Translate cell num to its placement on the board.
            int row = cellNum / side, col = cellNum % side;

            // If need to be filled, translate and fill the cell.
            if (board.IsEmptyCell(row, col))
            {
                int cellValueWithRowNum = int.Parse(RowConstraintNode.ColumnNode.Name);

                // Separate cell value from the row num restriction.
                int cellValue = cellValueWithRowNum % side + 1;
                // Place cell on board
                board[row, col] = cellValue;

                // Update empty count (the current cell is no longer empty).
                board.EmptyCount--;
            }
        }
    }
}
