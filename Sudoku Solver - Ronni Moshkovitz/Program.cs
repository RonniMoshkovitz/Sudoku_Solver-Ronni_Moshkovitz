using Sudoku_Solver___Ronni_Moshkovitz.UIManagement;


namespace Sudoku_Solver___Ronni_Moshkovitz
{
    // The Program's main class. It only contains 1 function, the program's main function.
    internal class Program
    {
        // This function is the program's main function. It shows the user a start view (wellcome message, rules, and an example),
        // and starts new rounds of main menu command selections over and over again.
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
