using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Functions
{
    class IfWallAhead : Function
    {
        public override TreeNode evaluate()
        {
            if (TreeNode.inputData.wallAhead)
                return left.evaluate();
            else
                return right.evaluate();
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new IfWallAhead();
            newNode.parent = parent;
            newNode.left = left.clone(newNode);
            newNode.right = right.clone(newNode);
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "ifWallAhead";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("ifWallAhead", font).Width);
        }

        public override Color getColor()
        {
            return Color.DarkMagenta;
        }
    }
}
