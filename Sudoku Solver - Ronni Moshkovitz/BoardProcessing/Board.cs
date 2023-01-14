using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class,Board, represent a sudoku board.
    // On this board all empty cells contain the value zero. 
    // All cells with values contain a value between 1 to the board's side length.
    public class Board
    {
        // Defined values
        private const int EMPTY_VALUE = 0;
        public readonly int FirstValue = 1;

        // Board leyput grid
        internal readonly int[,] Grid;

        // Empty cells count.
        internal int EmptyCount;

        // Board side length
        public int Side { get; }

        // Box side length
        public int BoxSide { get; }

        // Indexer for the Board object.
        // This indexer gives you the cell value in the given index on the grid.
        public int this[int row, int column]
        {
            get { return Grid[row, column]; }
            set { Grid[row, column] = value; }
        }

        // Constructor that initializes the Board object.
        internal Board(int[,] layout, int boardSide)
        {
            Grid = layout;

            // Setting dimensions
            Side = boardSide;
            BoxSide = (int)Math.Sqrt(Side);

            // Setting empty count
            CountEmpty();
        }

        // This function checks if the cell in the given index is empty (contains empty value).
        public bool IsEmptyCell(int row, int column)
        {
            return Grid[row, column] == EMPTY_VALUE;
        }

        // This function returnes the presentable form of the cell's value in the given index (9 -> '9', 10 -> ':').
        public char GetPresentabeValue(int row, int column)
        {
            return BoardTranslator.ToMatchingChar(Grid[row, column]);
        }

        // This function counts the empty cells on the board and sets the EmptyCount value to the counting result.
        private void CountEmpty()
        {
            EmptyCount = 0;

            // Iterate over each cell on the board, if it is empty, add to count.
            for (int row = 0; row < Side; row++)
            {
                for (int column = 0; column < Side; column++)
                {
                    // Add empty cell to count.
                    if (IsEmptyCell(column, row))
                    {
                        EmptyCount++;
                    }
                }
            }
        }

    }
}

