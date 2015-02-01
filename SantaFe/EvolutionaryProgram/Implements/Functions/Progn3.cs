using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Functions
{
    class Progn3 : Function
    {
        public override TreeNode evaluate()
        {
            left.evaluate();
            middle.evaluate();
            return right.evaluate();
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new Progn3();
            newNode.parent = parent;
            newNode.left = left.clone(newNode);
            newNode.right = right.clone(newNode);
            newNode.middle = middle.clone(newNode);
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "progn3";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("progn3", font).Width);
        }

        public override Color getColor()
        {
            return Color.Salmon;
        }
    }
}
