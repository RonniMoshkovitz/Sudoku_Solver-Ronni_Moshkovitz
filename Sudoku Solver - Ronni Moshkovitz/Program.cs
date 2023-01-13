using Sudoku_Solver___Ronni_Moshkovitz.UIManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz
{
    // The Program's main class. It only contains 1 function, the program's main function.
    internal class Program
    {
        // This function is the program's main function. It shows the user a start view (wellcome message, rules, and wxample),
        // and starts new rounds of main menue command selections over and over again.
        static void Main(string[] args)
        {
            UserCommunication.ShowStartView();
            while (true)
            {
                UserCommunication.StartNewRound();
            }
        }
    }
}
