using System.Collections.Generic;


namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class, DancingLinks, defines an object that solves an exact cover problem, represented by a four-way-linked list (dancing links layout), based on Donald E. Knuth's algorithm X.
    internal class DancingLinks
    {
        // The header of the four-way-linked list representation of the exact cover problem.
        private ColumnNode _header;

        // Stack with the answer parts to the problem (the "rows" that were selected).
        internal Stack<DancingNode> Answer { get; private set; }

        // Says if the exact cover problem has a solution or not.
        internal bool Solvable { get; private set; }

        // Constructor for DancingLinks object.
        internal DancingLinks(ColumnNode header)
        {
            _header = header;
            Answer = new Stack<DancingNode>();

            // Tries to solve the given exact cover problem.
            Solvable = SearchForSolution();
        }

        // This function finds the first complete answer to the exact cover problem (if there is one). It is based on Donald E. Knuth's algorithm  DLX (dancing links algoritem X).
        // The main idea is to "cover" each satisfied column (a column with a 1 in it), until all columns are satisfied.
        // It returns True if a solution was found, false otherwise.
        private bool SearchForSolution(int k = 0)
        {
            if (_header.Right == _header)
            {
                // All the columns are removed, therefore all of them are satisfies (solution found).
                return true;
            }

            else
            {
                // Select the column with the least possibilities and cover it.
                ColumnNode currentColumn = SelectColumnWithLeastOptions();
                currentColumn.Cover();

                // Try all options to satisfy this column.
                for (DancingNode OptionStart = currentColumn.Down; OptionStart != currentColumn; OptionStart = OptionStart.Down)
                {
                    // Add option to answers.
                    Answer.Push(OptionStart);

                    // Cover all related options.
                    for (DancingNode OptionPart = OptionStart.Right; OptionPart != OptionStart; OptionPart = OptionPart.Right)
                    {
                        OptionPart.ColumnNode.Cover();
                    }

                    // Try to solve smaller cover problem (with less option, asumming selected row is currect).
                    if (SearchForSolution(k + 1))
                    {
                        return true;
                    }

                    // Assumption was wrong, remove from answer stack.
                    OptionStart = Answer.Pop();
                    currentColumn = OptionStart.ColumnNode;

                    // Uncover and return to former state
                    for (DancingNode CanceledOptionPart = OptionStart.Left; CanceledOptionPart != OptionStart; CanceledOptionPart = CanceledOptionPart.Left)
                    {
                        CanceledOptionPart.ColumnNode.Uncover();
                    }
                }
                currentColumn.Uncover();
            }
            // Went through all possible options, no solution was found.
            return false;
        }

        // This function selects the column with the least options from the dancing links layout.
        private ColumnNode SelectColumnWithLeastOptions()
        {
            // Set initial values to the column node with the lowest amount of options (to be changed).
            int min = int.MaxValue;
            ColumnNode leastOptionsCol = null;

            for (ColumnNode colNode = (ColumnNode)_header.Right; colNode != _header; colNode = (ColumnNode)colNode.Right)
            {
                // Update leastOptionsCol to contain the column node with the lowest amount of options so far.
                if (colNode.Size < min)
                {
                    min = colNode.Size;
                    leastOptionsCol = colNode;
                }
            }
            return leastOptionsCol;
        }

    }
}
