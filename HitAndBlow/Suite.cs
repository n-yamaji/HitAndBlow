using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class Suite
    {
        private int[] number;
        private int hitBlow;

        public Suite(int arg0, int arg1, int arg2, int arg3)
        {
            this.number = new int[4];
            number[0] = arg0;
            number[1] = arg1;
            number[2] = arg2;
            number[3] = arg3;
            this.hitBlow = -1;
        }

        public int CheckHitBlow(int[] arg)
        {
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arg[i] == number[j])
                    {
                        if (i == j)
                        {
                            result += 10;
                            continue;
                        }

                        result++;
                    }
                }
            }

            this.hitBlow = result;
            return result;
        }

        public  int GetHitBlow()
        {
            return this.hitBlow;
        }

        public int[] ToIntArray()
        {
            return this.number;
        }
    }
}
