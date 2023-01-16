using System;
using System.IO;


namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This class, ConsoleWriter implements the IWriter interface. It writes output to the console.
    public class ConsoleWriter : IWriter
    {
        // Constructor for ConsoleWriter, it enables the option to enter more then 254 charcters into the console.
        public ConsoleWriter() { Console.SetIn(new StreamReader(Console.OpenStandardInput(8192))); }

        // This function writes output to the console.
        public void Write(string info)
        {
            Console.WriteLine(info);
        }
    }
}
