using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class HitAndBlow
    {
        private SetOfSuite sos;

        public HitAndBlow()
        {
            Suite[] tempSuite = new Suite[3024];
            int count = 0;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (i == j) continue;
                    for (int k = 1; k <= 9; k++)                
                    {
                        if (i == k) continue;
                        if (j == k) continue;
                        for (int l = 1; l <= 9; l++)
                        {
                            if (i == l) continue;
                            if (j == l) continue;
                            if (k == l) continue;
                            tempSuite[count] = new Suite(i, j, k, l);
                            count++;
                        }
                    }
                }
            }

            this.sos = new SetOfSuite(tempSuite);
        }

        public int GetNumberOfSuite()
        {
            return this.sos.GetNumberOfPossibleSuite();
        }

        public int[] Answer()
        {
            int[] result = new int[4];
            double min = 999999.0;
            if (this.sos.GetNumberOfPossibleSuite() == 1)
            {
                return this.sos.GetSuite();
            }

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (i == j) continue;
                    for (int k = 1; k <= 9; k++)
                    {
                        if (i == k) continue;
                        if (j == k) continue;
                        for (int l = 1; l <= 9; l++)
                        {
                            if (i == l) continue;
                            if (j == l) continue;
                            if (k == l) continue;
                            double tempDouble = this.sos.CheckHitBlow(new int[] { i, j, k, l });
                            if (tempDouble < min)
                            {
                                min = tempDouble;
                                result = new int[] { i, j, k, l };
                            }
                        }
                    }
                }
            }

            this.sos.CheckHitBlow(result);
            return result;
        }

        public void SetResult(int hb)
        {
            SetOfSuite tempSos = this.sos.GetPossibleSet(hb);
            this.sos = tempSos;
        }
    }
}
