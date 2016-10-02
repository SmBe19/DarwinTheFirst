using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class Genom
    {
        private List<Base> Bases;
        private Dictionary<string, int> NameToBase;

        public int BasesCount
        {
            get
            {
                return Bases.Count;
            }
        }

        public Genom()
        {
            Bases = new List<Base>();
            NameToBase = new Dictionary<string, int>();
        }

        public Genom(string file)
            : this()
        {
            InitFromFile(file);
        }

        public void AddBase(string Name)
        {
            NameToBase[Name] = Bases.Count;
            Bases.Add(new Base(Bases.Count, Name));
        }

        public void AddBase(string Name, double Minvalue, double Maxvalue, double MutationRate)
        {
            NameToBase[Name] = Bases.Count;
            Bases.Add(new Base(Bases.Count, Name, Minvalue, Maxvalue, MutationRate));
        }

        public void InitFromFile(String File)
        {
            string[] lines = System.IO.File.ReadAllLines(File);
            foreach(string line in lines){
                if (!line.Trim().StartsWith("#"))
                {
                    string[] parts = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1)
                    {
                        AddBase(parts[0]);
                    }
                    else if (parts.Length == 4)
                    {
                        double minvalue = 0, maxvalue = 1, mutationrate = 0.5;
                        bool success = true;
                        success &= double.TryParse(parts[1], out minvalue);
                        success &= double.TryParse(parts[2], out maxvalue);
                        success &= double.TryParse(parts[3], out mutationrate);
                        AddBase(parts[0], minvalue, maxvalue, mutationrate);
                        if (!success)
                        {
                            Console.WriteLine("Could not read line {0}", line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Could not read line {0}", line);
                    }
                }
            }
        }

        public Base GetBase(string Name)
        {
            return Bases[NameToBase[Name]];
        }

        public Base GetBase(int Index)
        {
            return Bases[Index];
        }

        public int GetBaseIndex(string name)
        {
            return NameToBase[name];
        }

        public GenomInstance CreateInstance()
        {
            GenomInstance Instance = new GenomInstance(this);

            foreach (Base b in Bases)
            {
                Instance.Bases[b.Index] = new BaseInstance(b);
            }

            return Instance;
        }

        public GenomInstance Clone(GenomInstance Instance)
        {
            GenomInstance NewInstance = CreateInstance();
            foreach (Base b in Bases)
            {
                NewInstance.Bases[b.Index].Value = Instance.Bases[b.Index].Value;
            }
            return NewInstance;
        }

        public void Randomize(GenomInstance Instance)
        {
            foreach (Base b in Bases)
            {
                Instance.Bases[b.Index].Randomize();
            }
        }

        public void Mutate(GenomInstance Instance)
        {
            foreach (Base b in Bases)
            {
                Instance.Bases[b.Index].Mutate();
            }
        }

        public GenomInstance Cross(GenomInstance A, GenomInstance B)
        {
            GenomInstance Instance = CreateInstance();

            foreach (Base b in Bases)
            {
                if (Simulation.random.Next(2) == 0)
                {
                    Instance.Bases[b.Index].Value = A.Bases[b.Index].Value;
                }
                else
                {
                    Instance.Bases[b.Index].Value = B.Bases[b.Index].Value;
                }
            }

            return Instance;
        }
    }
}
