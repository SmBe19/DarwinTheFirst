using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class BaseInstance
    {
        public readonly Base BaseT;
        public double Value;

        public BaseInstance(Base BaseT)
        {
            this.BaseT = BaseT;
        }

        public void Randomize()
        {
            BaseT.Randomize(this);
        }

        public void Mutate()
        {
            BaseT.Mutate(this);
        }
    }
}
