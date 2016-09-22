using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class BasicSimulationDrawer : SimulationDrawer
    {
        private BasicSimulation basicSimulation;
        private Brush brush;

        public BasicSimulationDrawer(BasicSimulation basicSimulation)
        {
            this.basicSimulation = basicSimulation;
            brush = new SolidBrush(Color.Red);
        }

        public override void Draw(System.Drawing.Graphics graphics, Rectangle clipRegion)
        {
            graphics.Clear(Color.White);

            lock (basicSimulation)
            {
                float width = graphics.VisibleClipBounds.Width;
                float height = graphics.VisibleClipBounds.Height;
                float oneWidth = width / basicSimulation.ValuesT.Count;
                float oneHeight = height / basicSimulation.ValuesT.Count;

                for (var i = 0; i < basicSimulation.ValuesT.Count; i++)
                {
                    graphics.FillRectangle(brush, i * oneWidth, 0, oneWidth, basicSimulation.ValuesT[i] * oneHeight);
                }
            }
        }
    }
}
