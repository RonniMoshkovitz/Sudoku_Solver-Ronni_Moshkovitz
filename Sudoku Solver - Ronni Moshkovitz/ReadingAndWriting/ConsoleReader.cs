using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class, ConsoleReader implaments the IReader inteface. It reads input from the console.
    public class ConsoleReader : IReader
    {
        // This function reads input from the console.
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
