using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.UIManagement
{
    // This class, MenueSelections, is in charge of directing the program according to a given setection string.
    internal class MenueSelections
    {
        // The main menue.
        private static Dictionary<string, Action> _programCommands = new Dictionary<string, Action>()
        {
            { "rules",  MenueActions.ShowRules},
            { "solve", MenueActions.RequestSorce},
            { "example", MenueActions.ShowExample},
            { "exit", MenueActions.ExitProgram}
        };

        // The input sorce menu.
        private static Dictionary<string, Action> _sudokuSorceOptions = new Dictionary<string, Action>()
        {
            { "console", MenueActions.BoardFromConsole},
            { "file", MenueActions.BoardFromFile}
        };

        // This function follows the given command, and preforms it.
        internal static void FollowCommand(string command)
        {
            DirectRequest(command, _programCommands, $"There is no such command as \"{command}\", please try again");
        }

        // This function follows the selects the given sorce, and gets the sudoku string from there.
        internal static void ChooseSudokuSorce(string sorce)
        {
            DirectRequest(sorce, _sudokuSorceOptions, $"There is no such sorce as \"{sorce}\", returning to main menue");
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
                MenueActions.NotFound(notFound);
            }
        }
    }
}
