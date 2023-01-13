using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.ReadingAndWriting
{
    // This interface, IWriter, supports writing output.
    public interface IWriter
    {
        // This function writes a given output.
        void Write(string info);
    }
}