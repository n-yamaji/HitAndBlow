using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class HitBlowSet
    {
        public int HitCount { get; private set; }
        public int BlowCount { get; private set; }

        public HitBlowSet(int hit,int blow)
        {
            this.HitCount = hit;
            this.BlowCount = blow;
        }

        public void Hit()
        {
            this.HitCount++;
        }

        public void Blow()
        {
            this.BlowCount++;
        }
    }
}
