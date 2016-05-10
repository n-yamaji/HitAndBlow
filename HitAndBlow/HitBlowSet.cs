using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class HitBlowSet
    {
        private int hit;
        private int blow;

        public HitBlowSet(int hit,int blow)
        {
            this.hit = hit;
            this.blow = blow;
        }

        public void Hit()
        {
            this.hit++;
        }

        public void Blow()
        {
            this.blow++;
        }
    }
}
