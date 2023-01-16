using System;


namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class implements the IReader interface. It reads input from the console.
    public class ConsoleReader : IReader
    {
        // Constructor for ConsoleReader.
        public ConsoleReader()
        {
            // Disables the option to enter "Ctrl + C" or "Ctrl + Break" to terminate the program.
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancleTarmination);
        }

        // This function reads input from the console.
        public string Read()
        {
            string input = Console.ReadLine();

            // If null input, we treat it as no input (empty string).
            return input != null ? input : "";
        }

        // This function is called every time "Ctrl + C" or "Ctrl + Break" is pressed.
        // It prevents the program from terminating.
        protected static void CancleTarmination(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
        }
    }
}
