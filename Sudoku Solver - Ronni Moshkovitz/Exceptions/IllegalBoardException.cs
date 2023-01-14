using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.Exceptions
{
    // This Exception is an exception for when the given board is illegal (contredicts the sudoku rules).
    public abstract class IllegalBoardException : Exception
    {
        public IllegalBoardException(string message) : base($"Illegal board: {message}.") { }
    }

    // This Exception is an exception for when the given board is illegal due to multiple appearences of the same value in the same house.
    public abstract class IllegalHouseException : IllegalBoardException
    {
        public IllegalHouseException(char cellValue, int houseNum, string houseType) : base($"The value:  \"{cellValue}\"  appraes more then once in {houseType}: {houseNum}") { }
    }

    // This Exception is an exception for when the given board is illegal due to multiple appearences of the same value in the same row.
    public class IllegalRowException : IllegalHouseException
    {
        public IllegalRowException(char cellValue, int rowNum) : base(cellValue, rowNum, "row") { }
    }

    // This Exception is an exception for when the given board is illegal due to multiple appearences of the same value in the same column.
    public class IllegalColumnException : IllegalHouseException
    {
        public IllegalColumnException(char cellValue, int columnNum) : base(cellValue, columnNum, "column") { }
    }

    // This Exception is an exception for when the given board is illegal due to multiple appearences of the same value in the same box.
    public class IllegalBoxException : IllegalHouseException
    {
        public IllegalBoxException(char cellValue, int boxNum) : base(cellValue, boxNum, "box") { }
    }
}
