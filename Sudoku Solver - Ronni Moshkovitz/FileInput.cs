using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz
{
    internal class FileInput : IInput
    {
        public string GetInput()
        {
            string filePath = Console.ReadLine();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                    return reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The input file was not found.");
                return string.Empty;
            }
            catch (IOException)
            {
                Console.WriteLine("Error: An I/O error occurred while reading the input file.");
                return string.Empty;
            }

        }
    }
}
