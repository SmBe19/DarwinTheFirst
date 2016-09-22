using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class BasicSimulation : Simulation
    {
        private List<int> Values;
        private Random random;

        public List<int> ValuesT
        {
            get
            {
                return Values;
            }
        }

        protected override void Init()
        {
            Values = new List<int>();
            for (var i = 0; i < 10; i++)
            {
                Values.Add(i);
            }
            random = new Random();
        }

        protected override SimulationDrawer CreateSimulationDrawer()
        {
            return new BasicSimulationDrawer(this);
        }

        protected override void Step()
        {
            for (var i = 0; i < Values.Count; i++)
            {
                Values[i] += random.Next(-1, 2);
                if (Values[i] < 0)
                {
                    Values[i] = 0;
                }
                else if (Values[i] > Values.Count)
                {
                    Values[i] = Values.Count;
                }
            }
        }
    }
}
