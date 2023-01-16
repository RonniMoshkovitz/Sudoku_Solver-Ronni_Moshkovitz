
namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class, BoardTranslator, is a Utility class.
    // It is in charge of converting the cell's value from int to its matching char, and so the other way.
    internal static class BoardTranslator
    {
        // Empty cell character value
        internal const char EMPTY_CHAR = '0';

        // This function converts an int value into it's matching character value.
        internal static char ToMatchingChar(int value)
        {
            return (char)(EMPTY_CHAR + value);
        }

        // This function converts a character value into it's matching int value.
        internal static int ToMatchingInt(char value)
        {
            return value - EMPTY_CHAR;
        }
    }
}
