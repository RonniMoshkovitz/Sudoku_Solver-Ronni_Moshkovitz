using Sudoku_Solver___Ronni_Moshkovitz.Exceptions;
using Sudoku_Solver___Ronni_Moshkovitz.SudokuHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.UIManagement
{
    // This class, MenuActions is a static class. It contains the actions for the menu selections.
    internal static class MenuActions
    {
        // This function returns a string of the sudoku puzzle rules.
        internal static void ShowRules()
        {
            UserCommunication.ShowInfo(ProgramDefaults.SUDOKU_RULES);
        }

        // This function returns a string of the sudoku input string example.
        internal static void ShowExample()
        {
            UserCommunication.ShowInfo(ProgramDefaults.EXAMPLE);
        }

        // This function shows goodBye message and exits the program.
        internal static void ExitProgram()
        {
            UserCommunication.ShowInfo(ProgramDefaults.GOODBYE_MESSAGE);
            Environment.Exit(0);
        }

        // This function shows an input selection sorce menu and follows the user's choice.
        internal static void RequestSorce()
        {
            string sorceName = UserCommunication.GetInfo(ProgramDefaults.INPUT_SORCE_OPTIONS).ToLower();
            MenuSelections.ChooseSudokuSorce(sorceName);
        }

        // This function solves and presents a board from a file.
        internal static void BoardFromFile()
        {
            // Get the data from the file (sudoku string or null if exception accured), and set the file path variable.
            string data = UserCommunication.GetBoardFromFile(out string path);

            // If the data is not null the reading went well, and data contains the sudoku string.
            if (data != null)
            {
                string result = SolveBoard(ref data);

                // Insert the result sudoku string into the file
                UserCommunication.InsertResultToFile(path, data);

                UserCommunication.ShowInfo(result);
            }
        }

        // This function solves and presents a board from the console.
        internal static void BoardFromConsole()
        {
            // Get the data from the console (sudoku string).
            string data = UserCommunication.GetBoardFromConsole();

            UserCommunication.ShowInfo(SolveBoard(ref data));
        }

        // This function Shows a message if the matching command was not found.
        internal static void NotFound(string message)
        {
            UserCommunication.ShowInfo(message);
        }

        // This function solves the string sudoku, and updates the sudoku string to the solutions sudoku string.
        // It returns the solving result (either the solution, an error message, or a message for an unsolvable board).
        private static string SolveBoard(ref string data)
        {
            // Try to process the board, data will either contain the sudoku string (won't change) or an error message (if processing failed).
            if (ProcessBoard(out SudokuHandler handler, ref data))
            {
                UserCommunication.ShowInfo(handler.GetStartingSudoku());

                // data gets the solved sudoku's string (if unsolvable, an empty string), returns the solution.
                return handler.GetSolvedSudoku(ref data);
            }
            // returns the error message.
            return data;
        }

        // This function Tries to process and generate an handler for the user's sudoku string.
        // The data starts with the sudoku string in it, but will contain an error message if processing culdn't be compleate.
        // It returns true if processing went well, false otherwise.
        private static bool ProcessBoard(out SudokuHandler handler, ref string data)
        {
            try
            {
                handler = new SudokuHandler(data);
                return true;
            }
            // The sudoku string is invalid.
            catch (InvalidSudokuStringException invalidString)
            {
                data = invalidString.Message;
            }
            // The board bracks the sudoku rules.
            catch (IllegalBoardException ileagalBoard)
            {
                data = ileagalBoard.Message;
            }

            // Processing failed.
            handler = null;
            return false;
        }
    }
}
