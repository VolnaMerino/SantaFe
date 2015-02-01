using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Terminals
{
    class Left : Terminal
    {
        public override TreeNode evaluate()
        {
            ant.turnLeft();
            return this;
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new Left();
            newNode.parent = parent;
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "left";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("left", font).Width);
        }

        public override Color getColor()
        {
            return Color.Black;
        }
    }
}
