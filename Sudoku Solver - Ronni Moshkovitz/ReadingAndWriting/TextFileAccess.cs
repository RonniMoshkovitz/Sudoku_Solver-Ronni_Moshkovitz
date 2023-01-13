using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class, TextFileAccess, is an abstract class that represent file access object.
    public abstract class TextFileAccess
    {
        // The file format of text files.
        private const string TXT_FORMAT = ".txt";

        // The filepath to the accessed file
        public string FilePath;

        // This function validates the given path from aspects of existance and format match.
        protected void ValidatePath()
        {
            // Check if the file path was set.
            if (string.IsNullOrEmpty(FilePath))
                throw new EmptyPathException();

            // Check if the file path is in the right format.
            if (!FilePath.EndsWith(TXT_FORMAT))
                throw new WrongFormatException(FilePath);
        }

        // This function preforms controled access to the file.
        public abstract bool ControlledAccess(ref string data);
    }
}