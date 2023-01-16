using Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing;
using System;


namespace Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling
{
    // This class, BoardDisplay, creates a sudoku display for its board.
    internal class BoardDisplay
    {
        // The display of the Board at the start.
        internal string StartBoard { get; private set; }

        // The board.
        private Board _board;

        // All the grid characters to create the sudoku board leyout:

        // The upper corrners chars:
        private const char UPPER_LEFT_CORNER = '┌';
        private const char UPPER_RIGHT_CORNER = '┐';

        // The lower corrners chars:
        private const char BUTTOM_LEFT_CORNER = '└';
        private const char BUTTOM_RIGHT_CORNER = '┘';

        // The connections chars:
        private const char UPPER_CONNECTION = '┬';
        private const char BUTTOM_CONNECTION = '┴';
        private const char LEFT_CONNECTION = '├';
        private const char RIGHT_CONNECTION = '┤';
        private const char MIDDLE_CONNECTION = '┼';

        // The simple lines:
        private const char HORIZONTAL_LINE = '─';
        private const char VERTICAL_LINE = '│';

        // Constructor for the BoardDisplay. 
        internal BoardDisplay(Board board)
        {
            _board = board;

            // Creates the starting display.
            StartBoard = CreateDisplay();
        }

        // This method creates the display for the board. In its current station. 
        internal string CreateDisplay()
        {
            string display = "";
            AddUpperFrameLine(ref display);

            // Creates each row at a time.
            for (int i = 0; i < _board.Side; i++)
            {
                // Add the outline according to the location:

                // Starts the board.
                if (i == 0)
                {
                    AddUpperLine(ref display);
                }

                // If its the connection of two boxes (end of one and the the start of the other),
                // Add box closer and box starter.
                else if (IsBoxEdge(i))
                {
                    AddButtomLine(ref display);
                    AddUpperLine(ref display);
                }

                // Add line between rows.
                else
                {
                    AddBetweenLine(ref display);
                }

                // Add the row with the values.
                AddSudokuRow(ref display, i);
            }

            // Add board end.
            AddButtomLine(ref display);
            AddButtomFrameLine(ref display);

            return display;
        }

        // This function adds the upper frame of the board.
        private void AddUpperFrameLine(ref string display)
        {
            AddFrameLine(ref display, UPPER_LEFT_CORNER, UPPER_RIGHT_CORNER);
        }

        // This function adds the buttom frame of the board.
        private void AddButtomFrameLine(ref string display)
        {
            AddFrameLine(ref display, BUTTOM_LEFT_CORNER, BUTTOM_RIGHT_CORNER);
        }

        // This function adds a frame with given corrners to the display.
        private void AddFrameLine(ref string display, char leftCorner, char rightCorner)
        {
            // add left corrner.
            display += leftCorner;

            // The frame uses 3 lines for each cell, 1 for each line between the cells, and 1 for each box connection.
            int lineCount = _board.Side * 4 + _board.BoxSide;

            for (int i = 0; i < lineCount; i++)
            {
                display += HORIZONTAL_LINE;
            }

            // Add right corner.
            display += $"{rightCorner}\n";
        }

        // This function adds a row with values from the board.
        private void AddSudokuRow(ref string display, int row)
        {
            // Add row for the outer border.
            display += VERTICAL_LINE;

            // For each index in board, add grid lines accordingly.
            for (int i = 0; i < _board.Side; i++)
            {
                // For box connections add another line.
                if (i != 0 && IsBoxEdge(i))
                {
                    display += $"{VERTICAL_LINE}";
                }

                char cellChar = _board.GetPresentabeValue(row, i);
                display += $"{VERTICAL_LINE} {cellChar} ";
            }

            // Adding ending line and outer border line.
            display += $"{VERTICAL_LINE}{VERTICAL_LINE}\n";
        }

        // This function adds an upper line above row.
        private void AddUpperLine(ref string display)
        {
            AddLine(ref display, UPPER_LEFT_CORNER, UPPER_RIGHT_CORNER, UPPER_CONNECTION);
        }

        // This function adds line between rows.
        private void AddBetweenLine(ref string display)
        {
            AddLine(ref display, LEFT_CONNECTION, RIGHT_CONNECTION, MIDDLE_CONNECTION);
        }

        // This function adds a buttom line under row.
        private void AddButtomLine(ref string display)
        {
            AddLine(ref display, BUTTOM_LEFT_CORNER, BUTTOM_RIGHT_CORNER, BUTTOM_CONNECTION);
        }

        // This function adds a line in the grid according to the left char, right char, and the connection char.
        private void AddLine(ref string display, char left, char right, char connection)
        {
            // Add line for the outer border.
            display += VERTICAL_LINE;

            // Create the line.
            for (int i = 0; i < _board.Side; i++)
            {
                // Add start of line char.
                if (i == 0)
                {
                    display += left;
                }

                // Add end of box and start of new box char.
                else if (IsBoxEdge(i))
                {
                    display += right;
                    display += left;
                }
                // Add connection char.
                else
                {
                    display += connection;
                }
                // Add cell line (top or buttom of the cell frame).
                display += $"{HORIZONTAL_LINE}{HORIZONTAL_LINE}{HORIZONTAL_LINE}";
            }
            // Finish line.
            display += $"{right}{VERTICAL_LINE}\n";
        }

        // This function checks if the index is the box's edge.
        private Boolean IsBoxEdge(int index)
        {
            double boxStart = (double)(index) / _board.BoxSide;
            return boxStart == Math.Floor(boxStart);
        }
    }
}