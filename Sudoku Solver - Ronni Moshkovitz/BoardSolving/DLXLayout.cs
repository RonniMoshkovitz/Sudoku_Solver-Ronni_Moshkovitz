using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class DLXLayout, converts an exact cover matrix into a four-way-linked list representation of the exact cover problem.
    // In this representation each node is linked vertically and horizontally to create a layout where only the constraints (the 1ns) appear.
    internal class DLXLayout
    {
        // Dimensions of the exact cover problem.
        private int _rowsCount, _columnsCount;

        // This function sets the dimensions of the exact cover problem, required for converting it from its matrix forn to its four-way-linked list form.
        private void SetupDimensions(byte[,] cover)
        {
            _rowsCount = cover.GetLength(0);
            _columnsCount = cover.GetLength(1);
        }

        // This function creates the four-way-linked list form of a given exact cover matrix.
        public ColumnNode GenerateDLXLayout(byte[,] cover)
        {
            SetupDimensions(cover);

            // creates the header node for the four-way-linked list (also marks the starting point of the column nodes).
            ColumnNode headerNode = new ColumnNode("header");
            ColumnNode[] columnNodes = new ColumnNode[_columnsCount];

            GenerateColumnNodes(headerNode, columnNodes);
            AddDancingNodesToLayout(cover, columnNodes);

            headerNode.Size = _columnsCount;
            return headerNode;
        }

        // This Function creates the column nodes sub list, and holds each node in an array according to it's column number (to ease next step).
        private void GenerateColumnNodes(ColumnNode headerNode, ColumnNode[] columnNodes)
        {
            for (int i = 0; i < _columnsCount; i++)
            {
                // Naming each column by its serial number and adding it to an array by order.
                ColumnNode node = new ColumnNode(i.ToString());
                columnNodes[i] = node;

                // Use the header node to point to the last added column node.
                headerNode = (ColumnNode)headerNode.ConnectRight(node);
            }
            // Return the header node to point to the header node.
            headerNode = headerNode.Right.ColumnNode;
        }

        // This function converts the cover matrix into a four-way-linked list.
        // It adds the constraint nodes to the 
        private void AddDancingNodesToLayout(byte[,] cover, ColumnNode[] columnNodes)
        {
            // Go over each cell in the cover matrix array.
            for (int row = 0; row < _rowsCount; row++)
            {
                DancingNode prev = null;
                for (int column = 0; column < _columnsCount; column++)
                {
                    // Add constraint to the layout.
                    if (cover[row, column] == 1)
                    {
                        // Creates new node and finds its column node.
                        ColumnNode colNode = columnNodes[column];
                        DancingNode newNode = new DancingNode(colNode);

                        // If first in constraint to be found in the row (no previous in row), set current node to previous.
                        if (prev == null)
                        {
                            prev = newNode;
                        }

                        // Add to bottum of the column and to its row (right to previous node, and set to previous).
                        colNode.Up.ConnectDown(newNode);
                        prev = prev.ConnectRight(newNode);

                        colNode.Size++;
                    }
                }
            }
        }
    }
}
