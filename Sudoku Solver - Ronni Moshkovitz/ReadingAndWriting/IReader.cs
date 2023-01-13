using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This interface, IReader, supports reading input.
    public interface IReader
    {
        // This function reads input and returns the read input as a string.
        string Read();
    }
}
