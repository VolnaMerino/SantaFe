using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaFe.EvolutionaryProgram.Exceptions
{
    class MiddleNodeException : Exception
    {
        private string p;

        public MiddleNodeException(string p)
        {
            this.p = p;
        }
    }
}
