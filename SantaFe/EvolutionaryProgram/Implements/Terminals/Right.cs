using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SantaFe.EvolutionaryProgram.Implements.Terminals
{
    class Right : Terminal
    {
        public override TreeNode evaluate()
        {
            ant.turnRight();
            return this;
        }

        public override TreeNode clone(TreeNode parent)
        {
            TreeNode newNode = new Right();
            newNode.parent = parent;
            return newNode;
        }

        public override string getTextRepresentation()
        {
            return "right";
        }

        public override int getTextRepresentationWidth(System.Drawing.Font font, PaintEventArgs e)
        {
            return Convert.ToInt32(e.Graphics.MeasureString("right", font).Width);
        }

        public override Color getColor()
        {
            return Color.Brown;
        }
    }
}
