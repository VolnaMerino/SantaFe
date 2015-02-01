using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SantaFe.EvolutionaryProgram.Exceptions;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Functions
{
    class IfFoodAhead : Function
    {

        public override TreeNode evaluate()
        {
            if (TreeNode.inputData.foodAhead)
                return left.evaluate();
            else
                return right.evaluate();
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new IfFoodAhead();
            newNode.parent = parent;
            newNode.left = left.clone(newNode);
            newNode.right = right.clone(newNode);
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "ifFoodAhead";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("ifFoodAhead", font).Width);
        }

        public override Color getColor()
        {
            return Color.DarkCyan;
        }
    }
}
