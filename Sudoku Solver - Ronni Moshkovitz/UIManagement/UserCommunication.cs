﻿using Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.UIManagement
{
    // This class, UserCommunication is a static class. It is in charge of all the input and output exchange with the user.
    internal static class UserCommunication
    {
        // IWriter to write output.
        private static IWriter _output = new ConsoleWriter();
        // IReader to read input.
        private static IReader _input = new ConsoleReader();

        // This function shows the wellcome message, the game puzzle, and an example for input.
        public static void ShowStartView()
        {
            _output.Write($"{ProgramDefaults.WELLCOME_MESSAGE}{ProgramDefaults.SUDOKU_RULES}{ProgramDefaults.EXAMPLE}");
        }

        // This function shows thw main menue and follows the command.
        public static void StartNewRound()
        {
            MenueSelections.FollowCommand(GetInfo(ProgramDefaults.MENUE).ToLower());
        }

        // This function requests the user for a file path and reads the sudoku string from there.
        // It returns the sudoku string (if reading fails, it prints the error message, and returns null).
        public static string GetBoardFromFile(out string FilePath)
        {
            TextFileAccess reader = new TextFileReader();

            reader.FilePath = FilePath = GetInfo("Please enter file path for a txt file with a sudoku board string in it: ");

            // Try reading, the data into the data variable.
            string data = "";
            if (!reader.ControlledAccess(ref data))
            {
                // Reading failed, print error message and return null.
                _output.Write(data);
                return null;
            }
            // Return the sudoku string.
            return data;
        }

        // This function inserts the solved sudoku string into a file. If writing fails, it shows the error message.
        public static void InsertResultToFile(string FilePath, string info)
        {
            TextFileAccess writer = new TextFileWriter();
            // Set file path to the solutions file (matches the input file, but with a "-solved.txt" ending.
            writer.FilePath = FilePath.Replace(".", "-solved."); ;

            // info contains the input string to write. if writing fails, it will contain the reasson for it (an error message).
            if (!writer.ControlledAccess(ref info))
            {
                _output.Write(info);
            }
        }


        // This function asks for a board from the user.
        public static string GetBoardFromConsole()
        {
            return GetInfo("\nPlease enter a board: ");
        }

        // This function shows information to the user.
        public static void ShowInfo(string info)
        {
            _output.Write(info);
        }

        // This function presents a request to the user, and returns his response input string.
        public static string GetInfo(string request)
        {
            _output.Write(request);
            return _input.Read();
        }
    }
}

