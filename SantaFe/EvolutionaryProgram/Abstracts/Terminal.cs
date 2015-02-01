using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaFe
{
    abstract class Terminal :TreeNode
    {
        public abstract override TreeNode evaluate();
    }
}
