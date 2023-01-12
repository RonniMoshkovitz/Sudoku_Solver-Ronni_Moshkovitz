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

        //
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

        // Constructor that initialises the Board object.
        internal Board(int[,] layout, int boardSide)
        {
            Grid = layout;

            Side = boardSide;
            BoxSide = (int)Math.Sqrt(Side);
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
            return BoardTrunslator.ToMatchingChar(Grid[row, column]);
        }

        private void CountEmpty()
        {
            EmptyCount = 0;
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (IsEmptyCell(j, i))
                        EmptyCount++;
                }
            }
        }

    }
}

