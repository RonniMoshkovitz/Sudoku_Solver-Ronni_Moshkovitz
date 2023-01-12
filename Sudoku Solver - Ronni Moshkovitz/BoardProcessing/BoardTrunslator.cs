using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class, BoardTrunslator, is a Utility class.
    // It is in charge of converting the cell's value from int to it's matching char, and so the other way.
    internal static class BoardTrunslator
    {
        // Empty cell char value
        internal const char EMPTY_CHAR = '0';

        // This function converts an int value into it's matching char value.
        internal static char ToMatchingChar(int value)
        {
            return (char)(EMPTY_CHAR + value);
        }

        // This function converts a char value into it's matching int value.
        internal static int ToMatchingInt(char value)
        {
            return value - EMPTY_CHAR;
        }
    }
}
