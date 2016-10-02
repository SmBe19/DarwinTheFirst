using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class BasicGeneticSimulationDrawer : SimulationDrawer
    {
        public override void Draw(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipRegion)
        {
            graphics.Clear(Color.White);
        }
    }
}
