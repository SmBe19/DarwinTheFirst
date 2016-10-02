using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class Base
    {
        private int _Index;
        private string _Name;
        private double _Minvalue;
        private double _Maxvalue;
        private double _MutationRate;

        public int Index
        {
            get
            {
                return _Index;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public double Minvalue
        {
            get
            {
                return _Minvalue;
            }
        }

        public double Maxvalue
        {
            get
            {
                return _Maxvalue;
            }
        }

        public double MutationRate
        {
            get
            {
                return _MutationRate;
            }
        }


        public Base(int Index, string Name)
            : this(Index, Name, 0, 1)
        {
        }

        public Base(int Index, string Name, double Minvalue, double Maxvalue)
            : this(Index, Name, Minvalue, Maxvalue, 0.5)
        {
        }

        public Base(int Index, string Name, double Minvalue, double Maxvalue, double MutationRate)
        {
            this._Index = Index;
            this._Name = Name;
            this._Minvalue = Minvalue;
            this._Maxvalue = Maxvalue;
            this._MutationRate = MutationRate;
        }

        public void Randomize(BaseInstance Instance)
        {
            Instance.Value = Simulation.random.NextDouble() * (Maxvalue - Minvalue) + Minvalue;
        }

        public void Mutate(BaseInstance Instance)
        {
            Instance.Value += Simulation.random.NextDouble() * 2.0 * MutationRate - MutationRate;
            if (Instance.Value < Minvalue)
            {
                Instance.Value = Minvalue;
            }
            else if (Instance.Value > Maxvalue)
            {
                Instance.Value = Maxvalue;
            }
        }

    }
}
