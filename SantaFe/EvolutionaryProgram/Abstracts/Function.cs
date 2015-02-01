using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SantaFe.EvolutionaryProgram;

namespace SantaFe
{
    abstract class Function : TreeNode
    {
        public abstract override TreeNode evaluate();
    }
}
