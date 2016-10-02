using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTheFirst
{
    class GenomInstance
    {
        public readonly Genom GenomT;
        public readonly List<BaseInstance> Bases;

        public GenomInstance(Genom GenomT)
        {
            this.GenomT = GenomT;
            Bases = new List<BaseInstance>(GenomT.BasesCount);
        }

        public void Randomize()
        {
            GenomT.Randomize(this);
        }

        public GenomInstance Clone()
        {
            return GenomT.Clone(this);
        }

        public void Mutate()
        {
            GenomT.Mutate(this);
        }

        public GenomInstance Cross(GenomInstance Other)
        {
            return GenomT.Cross(this, Other);
        }

        public static GenomInstance operator *(GenomInstance A, GenomInstance B)
        {
            return A.Cross(B);
        }
    }
}
