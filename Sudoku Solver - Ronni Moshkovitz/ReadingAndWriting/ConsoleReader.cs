using System;


namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class implements the IReader interface. It reads input from the console.
    public class ConsoleReader : IReader
    {
        // Constructor for ConsoleReader.
        public ConsoleReader(Action beforeClosing)
        {
            // Handling "Ctrl + C" or "Ctrl + Break" defult console exit commands by adding finishing steps to it.
            Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs args) => beforeClosing();
        }

        // This function reads input from the console.
        public string Read()
        {
            string input = Console.ReadLine();

            // If null input, we treat it as no input (empty string).
            return input != null ? input : "";
        }
    }
}
