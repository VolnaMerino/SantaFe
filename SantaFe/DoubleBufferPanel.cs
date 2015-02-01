using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SantaFe
{
    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel():base()
        {
            DoubleBuffered = true;
        }
    }
}
