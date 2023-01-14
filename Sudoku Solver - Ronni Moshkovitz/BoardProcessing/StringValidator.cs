using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardProcessing
{
    // This class, StringValidator defines an object that validates sudoku string representations.
    internal class StringValidator
    {
        // The biggest sudoku board side supported by this program
        private const int MAX_SIDE = 25;

        // The string sudoku
        private string _inputSudoku;

        // The amount of cells in each sudoku house (also called sudoku side)
        private int _cellsInHouse;

        // This function Validates the string sudoku and returns it's size.
        // may throw an exception if the given string has unvalid length, or charcters in it.
        internal int Validate(string inputSudoku)
        {
            _inputSudoku = inputSudoku;

            // looks for invalidities
            IsEmpty();
            IsValidLength();
            AreValidChars();

            return _cellsInHouse;
        }

        // This function Checks if the sudoku string was given.
        // may throw an exception if the given string is an empty string or a null.
        private void IsEmpty()
        {
            if (string.IsNullOrEmpty(_inputSudoku))
                throw new EmptyStringException();
        }

        // This function Checks if the sudoku string is contains enough charcters to define a sudoku board.
        // may throw an exception if the given string length is not in a valid size.
        private void IsValidLength()
        {
            double boardSide = Math.Sqrt(_inputSudoku.Length);
            double boxSide = Math.Sqrt(boardSide);

            // The closest possible board side size to the given sudoku string's side.
            // if is valid will be equal to boardSide
            int side = (int)Math.Pow(Math.Ceiling(boxSide), 2);

            // If Longer than max supported size
            if (side > MAX_SIDE)
                throw new StringTooLongException(side, MAX_SIDE);

            // If is missing charcters to complete the board
            if (!IsWholeNumber(boxSide))
            {
                int missing = side * side - _inputSudoku.Length;
                throw new InvalidSideException(_inputSudoku.Length, missing, side);
            }

            // set size to the validated size
            _cellsInHouse = side;
        }

        // This function Checks if the sudoku string has only valid charcters.
        // may throw an exception if the given string contains unsupported charcters.
        private void AreValidChars()
        {
            foreach (char cellValue in _inputSudoku)
                if (!IsValidChar(cellValue))
                    throw new UnsupportedValueException(cellValue);
        }

        // This function Checks if a certain charcter is valid.
        // It returns true if valid, false otherwise.
        private bool IsValidChar(char cellValue)
        {
            // last character is character in the matching value to the sudoku's side
            char lastValue = BoardTranslator.ToMatchingChar(_cellsInHouse);

            return cellValue >= BoardTranslator.EMPTY_CHAR && cellValue <= lastValue;
        }

        // This function checks if a double is a whole number or not. 
        // It returns true if valid, false otherwise.
        private static bool IsWholeNumber(double number)
        {
            return number == Math.Floor(number);
        }
    }
}

