using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarwinTheFirst
{
    public partial class MainForm : Form
    {
        Simulation simulation;

        public MainForm()
        {
            InitializeComponent();

            String[] args = Environment.GetCommandLineArgs();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "basic":
                        simulation = new BasicSimulation();
                        break;
                    case "bg":
                    case "basicgenetic":
                        simulation = new BasicGeneticSimulation();
                        break;
                }
            }
            if (simulation == null)
            {
                simulation = new BasicGeneticSimulation();
            }
            simulation.StartSimulation();

            repaintTimer.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            simulation.SimulationDrawerT.Draw(e.Graphics, e.ClipRectangle);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            simulation.StopSimulation();
        }

        private void repaintTimer_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
