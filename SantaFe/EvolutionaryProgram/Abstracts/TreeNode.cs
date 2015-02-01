using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaFe.EvolutionaryProgram;
using System.Drawing;
using System.Windows.Forms;

namespace SantaFe
{
    abstract class TreeNode
    {
        public static InputData inputData;
        public static Ant ant;

        public TreeNode left =null;
        public TreeNode middle = null;
        public TreeNode right = null;
        public TreeNode parent = null;
        public PointF position;

        public void swapNode(TreeNode toSwap, TreeNode swapWith)
        {
            if (left.Equals(toSwap))
                left = swapWith;
            else if (right.Equals(toSwap))
                right = swapWith;
            else if (middle != null && middle.Equals(toSwap))
                middle = swapWith;
        }

        public void setParent(TreeNode parent)
        {
            this.parent = parent;
        }

        public TreeNode getMiddle()
        {
            return middle;
        }

        public TreeNode getLeft()
        {
            return left;
        }
        public TreeNode getRight()
        {
            return right;
        }

        public abstract TreeNode evaluate();
        public abstract string getTextRepresentation();
        public abstract int getTextRepresentationWidth(Font font, PaintEventArgs e);
        public abstract Color getColor();
        public abstract TreeNode clone(TreeNode parent);
    }
}
