using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class, TextFileReader, inherits TextFileAccess and implements the IReader inteface. It reads input from the file.
    public class TextFileReader : TextFileAccess, IReader
    {
        // This function preforms controled access to the file, and reads from it. 
        // It insetrs to data the file's contant as string (if possible), or the error message.
        public override bool ControlledAccess(ref string data)
        {
            try
            {
                data = Read();
                return true;
            }
            // File path empty or not in the right format.
            catch (TextFilePathException pathException)
            {
                data = pathException.Message;
            }
            // File path leads to a file that doesn't exist.
            catch (FileNotFoundException)
            {
                data = $"File: \"{FilePath}\" not found";
            }
            // File path leads to a directory that doesnt exist.
            catch (DirectoryNotFoundException)
            {
                data = $"Directory for: \"{FilePath}\" not found";
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

            data = $"Text file reading exception: {data}";
            return false;
        }

        // This function reads the input from the file.
        // Throws file related errors (as shown above).
        public string Read()
        {
            ValidatePath();
            return File.ReadAllText(FilePath);
        }
    }
}

