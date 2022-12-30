using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz
{
    internal class ConsoleOutput : IOutput
    {
        public void ShowOutput(string info)
        {
            Console.WriteLine(info);
        }
    }
}
