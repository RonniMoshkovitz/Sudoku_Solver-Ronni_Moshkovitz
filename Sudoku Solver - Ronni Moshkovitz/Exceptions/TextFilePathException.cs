using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.Exceptions
{
    // This Exception is an exception for when the given file path is invalid for text file access.
    public abstract class TextFilePathException : IOException
    {
        public TextFilePathException(string message) : base(message) { }
    }

    // This Exception is an exception for when the given file path is empty.
    public class EmptyPathException : TextFilePathException
    {
        public EmptyPathException() : base($"No path was entered") { }
    }

    // This Exception is an exception for when the given file path is invalid due to wrong file format (not *.txt).
    public class WrongFormatException : TextFilePathException
    {
        public WrongFormatException(string filePath) : base($"This program only supports text files (*.txt), you entered: \"{filePath}\"") { }
    }
}
