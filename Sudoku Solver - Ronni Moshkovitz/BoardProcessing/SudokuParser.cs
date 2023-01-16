
namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class, SudokuParser defines an object that is in charge of
    // converting the input sudoku string to a 2D array of int values,
    // and deparsing an array to a string (the other way around).
    internal class SudokuParser
    {
        // This function parses the input string into a sudoku grid layout.
        // It returns the parsing result (2D array with int values).
        internal int[,] Parse(string inputSudoku, int size)
        {
            int[,] grid = new int[size, size];

            // Index of character in the string sudoku
            int inputIndex = 0;

            // Row and column indexes in the grid
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++, inputIndex++)
                {
                    grid[row, column] = BoardTranslator.ToMatchingInt(inputSudoku[inputIndex]);
                }
            }

            return grid;
        }

        // This function deparses a sudoku grid layout into a sudoku string.
        // It returns the deparsing result (sudoku string).
        internal string Deparse(int[,] board)
        {
            int size = board.GetLength(0);
            string deParsedBoard = "";

            // Row and column indexes in the grid
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    // Add cell to sudoku grid
                    deParsedBoard += BoardTranslator.ToMatchingChar(board[row, column]);
                }
            }

            return deParsedBoard;
        }
    }
}
