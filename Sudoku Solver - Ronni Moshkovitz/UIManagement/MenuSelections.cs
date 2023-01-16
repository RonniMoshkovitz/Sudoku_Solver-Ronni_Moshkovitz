using System;
using System.Collections.Generic;


namespace Sudoku_Solver___Ronni_Moshkovitz.UIManagement
{
    // This class, MenuSelections, is in charge of directing the program according to a given selection string..
    internal class MenuSelections
    {
        // The main menu.
        private static Dictionary<string, Action> _programCommands = new Dictionary<string, Action>()
        {
            { "rules",  MenuActions.ShowRules},
            { "solve", MenuActions.RequestSource},
            { "example", MenuActions.ShowExample},
            { "exit", MenuActions.ExitProgram}
        };

        // The input source menu.
        private static Dictionary<string, Action> _sudokuSourceOptions = new Dictionary<string, Action>()
        {
            { "console", MenuActions.BoardFromConsole},
            { "file", MenuActions.BoardFromFile}
        };

        // This function follows the given command, and preforms it.
        internal static void FollowCommand(string command)
        {
            DirectRequest(command, _programCommands, $"There is no such command as \"{command}\", please try again");
        }

        // This function follows the selects the given sorce, and gets the sudoku string from there.
        internal static void ChooseSudokuSource(string source)
        {
            DirectRequest(source, _sudokuSourceOptions, $"There is no such sorce as \"{source}\", returning to main menu");
        }

        // This function matches between a request to it's matching function according to the given options.
        // It preforms the NotFound function, in case of unsupported request.
        private static void DirectRequest(string request, Dictionary<string, Action> options, string notFound)
        {
            if (options.ContainsKey(request))
            {
                options[request]();
            }
            // Request not in dictonary.
            else
            {
                MenuActions.NotFound(notFound);
            }
        }
    }
}
