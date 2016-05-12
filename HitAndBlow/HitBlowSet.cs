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
        public bool IsHit
        {
            get
            {
                return this.HitCount > 0 || this.BlowCount > 0;
            }
        }

        public HitBlowSet(int hit, int blow)
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
