
using System.Data.Common;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class DLXLayout, converts an exact cover matrix into a four-way-linked list representation of the exact cover problem.
    // In this representation each node is linked vertically and horizontally to create a layout where only the constraints (the 1ns) appear.
    internal class DLXLayout
    {
        // Dimensions of the exact cover problem.
        private int _rowsCount, _columnsCount;

        private ColumnNode[] _columnNodes;

        // This function sets the dimensions of the exact cover problem, required for converting it from its matrix forn to its four-way-linked list form.
        private void SetupDimensions(byte[,] cover)
        {
            _rowsCount = cover.GetLength(0);
            _columnsCount = cover.GetLength(1);

            _columnNodes = new ColumnNode[_columnsCount];
        }

        // This function creates the four-way-linked list form of a given exact cover matrix.
        internal ColumnNode GenerateDLXLayout(byte[,] cover)
        {
            SetupDimensions(cover);

            // Creates the header node for the four-way-linked list (also marks the starting point of the column nodes).
            ColumnNode headerNode = new ColumnNode("header");
             
            GenerateColumnNodes(headerNode);
            AddDancingNodesToLayout(cover);

            headerNode.Size = _columnsCount;
            return headerNode;
        }

        // This Function creates the column nodes sub list, and holds each node in an array according to it's column number (to ease next step).
        private void GenerateColumnNodes(ColumnNode headerNode)
        {
            for (int i = 0; i < _columnsCount; i++)
            {
                // Naming each column by its serial number and adding it to an array by order.
                ColumnNode node = new ColumnNode(i.ToString());
                _columnNodes[i] = node;

                // Use the header node to point to the last added column node, and connect it to the right.
                headerNode = (ColumnNode)headerNode.ConnectRight(node);
            }
            // Return the header node to point to the header node.
            headerNode = headerNode.Right.ColumnNode;
        }

        // This function converts the cover matrix into a four-way-linked list.
        // It adds the constraint nodes to the 
        private void AddDancingNodesToLayout(byte[,] cover)
        {
            // Go over each cell in the cover matrix array.
            for (int row = 0; row < _rowsCount; row++)
            {
                DancingNode prev = null;
                for (int column = 0; column < _columnsCount; column++)
                {
                    // Add only constraints to the layout.
                    if (cover[row, column] == 1)
                    {
                        AddConstraintNode(ref prev, column);
                    }
                }
            }
        }

        // This function does the adding of a new dancing node to the dlx layout.
        private void AddConstraintNode(ref DancingNode prev, int column)
        {
            // Creates new node and finds its column node.
            ColumnNode colNode = _columnNodes[column];
            DancingNode newNode = new DancingNode(colNode);

            // If first constraint to be found in the row (no previous in row), set previous node (prev) to current.
            if (prev == null)
            {
                prev = newNode;
            }

            // Add to bottum of the column and to its row (right to previous node, and set previous to current).
            colNode.Up.ConnectDown(newNode);
            prev = prev.ConnectRight(newNode);

            colNode.Size++;
        }
    }
}
