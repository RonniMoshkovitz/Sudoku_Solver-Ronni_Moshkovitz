using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class, TextFileWriter, inherits TextFileAccess and implements the IWriter inteface. It writes output to the file.
    internal class TextFileWriter : TextFileAccess, IWriter
    {
        // This function preforms controled access to the file, and writes to it. 
        // It insetrs to data the error message if writting is impossible.
        public override bool ControlledAccess(ref string data)
        {
            try
            {
                Write(data);
                return true;
            }
            // File path empty or not in the right format.
            catch (TextFilePathException pathException)
            {
                data = pathException.Message;
            }
            // File path leads to a file that is unauthorized.
            catch (UnauthorizedAccessException)
            {
                data = "Permission to: \"{FilePath}\" denied";
            }
            // Entered File path is too long.
            catch (PathTooLongException)
            {
                data = $"The path: \"{FilePath}\" is too long";
            }
            data = $"Text file writing exception: {data}";
            return false;
        }

        // This function writes output to the file.
        // Throws file related errors (as shown above).
        public void Write(string info)
        {
            File.WriteAllText(FilePath, info);
        }
    }
}
