using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class BasicGeneticSimulation : GeneticSimulation
    {
        Genom GenomT;

        protected override void Init()
        {
            GenomT = new Genom("BasicGeneticSimulationGenom.txt");
        }

        protected override SimulationDrawer CreateSimulationDrawer()
        {
            return new BasicGeneticSimulationDrawer();
        }

        protected override void Step()
        {
            // TODO
        }
    }
}
