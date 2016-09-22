using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    abstract class SimulationDrawer
    {
        public abstract void Draw(Graphics graphics, Rectangle clipRegion);
    }
}
