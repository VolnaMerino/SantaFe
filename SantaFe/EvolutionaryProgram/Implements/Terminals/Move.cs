using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Terminals
{
    class Move : Terminal
    {
        public override TreeNode evaluate()
        {
            ant.goForward();
            return this;
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new Move();
            newNode.parent = parent;
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "move";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("move", font).Width);
        }

        public override Color getColor()
        {
            return Color.Blue;
        }
    }
}
