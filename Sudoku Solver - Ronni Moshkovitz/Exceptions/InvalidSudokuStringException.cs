using System;


namespace Sudoku_Solver___Ronni_Moshkovitz.Exceptions
{
    // This Exception is an exception for when the given sudoku string is invalid.
    public abstract class InvalidSudokuStringException : Exception
    {
        public InvalidSudokuStringException(string message) : base($"Invalid Sudoku string: {message}.") { }
    }

    // This Exception is an exception for when the given sudoku string is invalid due to an appearance of a character (value) that is out of the range of the sudoku board's values.
    public class UnsupportedValueException : InvalidSudokuStringException
    {
        public UnsupportedValueException(char value) : base($"Unsupported value: \"{value}\" in the given sudoku string (out of range)") { }
    }

    // This Exception is an exception for when the given sudoku string is invalid due to invalid length of the string.
    public abstract class InvalidLengthException : InvalidSudokuStringException
    {
        public InvalidLengthException(string message) : base($"Invalid length: {message}") { }
    }

    // This Exception is an exception for when the given sudoku string is invalid due to too long sudoku string.
    public class StringTooLongException : InvalidLengthException
    {
        public StringTooLongException(int length, int max) : base($"Entered sudoku string is too long. This program supports up to sudokus with a size of {max}X{max} ({max * max} charcters overall), you entered {length} charcters") { }
    }

    // This Exception is an exception for when the given sudoku string is invalid due to missing characters (values) to complete a sudoku board.
    public class InvalidSideException : InvalidLengthException
    {
        public InvalidSideException(int enteredLength, int missing, int side) : base($"Missing {missing} charcters to compleat board. You entered {enteredLength} chars overall, you are missing charcters to compleate a board of size {side}X{side}") { }
    }

    // This Exception is an exception for when the given sudoku string is empty.
    public class EmptyStringException : InvalidSudokuStringException
    {
        public EmptyStringException() : base($"No sudoku string was entered...") { }
    }
}
