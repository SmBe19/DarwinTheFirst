using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    abstract class Simulation
    {
        public int StepTime = 1000;
        private volatile bool SimulationRunning;
        private Thread SimulationThread;
        private SimulationDrawer SimulationDrawerBacking;
        private int LastStep;

        public static Random random = new Random();

        public SimulationDrawer SimulationDrawerT
        {
            get
            {
                return SimulationDrawerBacking;
            }
        }

        public void StartSimulation()
        {
            if (SimulationRunning)
            {
                return;
            }

            LastStep = Environment.TickCount;
            Init();
            SimulationDrawerBacking = CreateSimulationDrawer();

            SimulationThread = new Thread(this.Simulate);
            SimulationThread.Start();
        }

        public void StopSimulation()
        {
            SimulationRunning = false;
        }

        private void Simulate()
        {
            SimulationRunning = true;
            while (SimulationRunning)
            {
                LastStep = Environment.TickCount;
                lock (this)
                {
                    Step();
                }

                int passed = Environment.TickCount - LastStep;
                if (StepTime > passed && passed >= 0)
                {
                    Thread.Sleep(StepTime - passed);
                }
            }
        }

        protected abstract void Init();

        protected abstract SimulationDrawer CreateSimulationDrawer();

        protected abstract void Step();
    }
}
