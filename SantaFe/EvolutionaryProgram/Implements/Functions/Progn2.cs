using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Functions
{
    class Progn2 : Function
    {

        public override TreeNode evaluate()
        {
            left.evaluate();
            return right.evaluate();
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new Progn2();
            newNode.parent = parent;
            newNode.left = left.clone(newNode);
            newNode.right = right.clone(newNode);
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "progn2";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("progn2", font).Width);
        }

        public override Color getColor()
        {
            return Color.Silver;
        }
    }
}
