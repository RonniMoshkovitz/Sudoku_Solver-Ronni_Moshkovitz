using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver___Ronni_Moshkovitz.BoardSolving
{
    // This class defines a node for a four-way-linked DLX layout.
    internal class DancingNode
    {
        // Pointers to all neighboring linked nodes.
        internal DancingNode Left, Right, Up, Down;

        // Pointer to the node's column node.
        internal ColumnNode ColumnNode;

        // Constractor of DancingNode.
        internal DancingNode()
        {
            // initialize as single node (no side nodes, so sides point to self).
            Left = Right = Up = Down = this;
        }

        // Constractor of DancingNode. sets column node.
        internal DancingNode(ColumnNode column) : this() { ColumnNode = column; }

        // This function connects a node under this node.
        internal DancingNode ConnectDown(DancingNode downNode)
        {
            // Point to the node under the current and get pointed back. 
            downNode.Down = this.Down;
            downNode.Down.Up = downNode;
            // Point to the current node (new up) and get pointed back. 
            downNode.Up = this;
            this.Down = downNode;

            return downNode;
        }

        // This function connects a node to the right of this node.
        internal DancingNode ConnectRight(DancingNode rightNode)
        {
            // Point to the node to the right of the current and get pointed back. 
            rightNode.Right = this.Right;
            rightNode.Right.Left = rightNode;
            // Point to the current node (new left) and get pointed back. 
            rightNode.Left = this;
            this.Right = rightNode;
            return rightNode;
        }

        // This function unlinks the node from the four-way-linked list horizontally.
        // The right and left nodes no longer point at it, but it still points at them.
        internal void UnlinkLeftRight()
        {
            this.Left.Right = this.Right;
            this.Right.Left = this.Left;
        }

        // This function relinks the node to the four-way-linked list horizontally.
        // Sets the right and left nodes to point back at it (simple due to the fact that the node still points at them).
        internal void RelinkLeftRight()
        {
            this.Left.Right = this.Right.Left = this;
        }

        // This function unlinks the node from the four-way-linked list vertically.
        // The up and down nodes no longer point at it, but it still points at them.
        internal void UnlinkUpDown()
        {
            this.Up.Down = this.Down;
            this.Down.Up = this.Up;
        }

        // This function relinks the node to the four-way-linked list vertically.
        // Sets the up and down nodes to point back at it (simple due to the fact that the node still points at them).
        internal void RelinkUpDown()
        {
            this.Up.Down = this.Down.Up = this;
        }
    }


    // This class, ColumnNode, defines a column node for a four-way-linked DLX layout.
    internal class ColumnNode : DancingNode
    {
        // Number of nodes (1s) in current column.
        internal int Size;

        // Node name.
        internal readonly string Name;


        // Constructor for ColumnNode.
        internal ColumnNode(string name) : base()
        {
            Size = 0;
            Name = name;
            ColumnNode = this;
        }

        // This function covers all the nodes of this column and their side nodes (the whole options that appear on the column).
        internal void Cover()
        {
            // Unlink the satisfied column node from the layout.
            UnlinkLeftRight();

            // For each node in the column to be covered, cover the whole option (all its side linked nodes).
            for (DancingNode satisfiedColPart = this.Down; satisfiedColPart != this; satisfiedColPart = satisfiedColPart.Down)
            {
                for (DancingNode optionPart = satisfiedColPart.Right; optionPart != satisfiedColPart; optionPart = optionPart.Right)
                {
                    // Unlink nodes from their columns as part of an option in the coverd column.
                    optionPart.UnlinkUpDown();
                    optionPart.ColumnNode.Size--;
                }
            }
        }

        // This function uncovers all the nodes of this column and their side nodes (the whole options that appear on the column).
        internal void Uncover()
        {
            // For each node in the covered column, uncover the whole option (all its side linked nodes).
            for (DancingNode i = this.Up; i != this; i = i.Up)
            {
                for (DancingNode j = i.Left; j != i; j = j.Left)
                {
                    // Relink nodes to their columns (to the nodes above and below), as part of an option in the coverd column.
                    j.ColumnNode.Size++;
                    j.RelinkUpDown();
                }
            }
            // Relink the satisfied column node from the layout.
            RelinkLeftRight();
        }
    }
}
