using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class SetOfSuite
    {
        private Suite[] suite;
        private int[] numberOfClassifiedSuite;

        public SetOfSuite(Suite[] suite)
        {
            this.suite = suite;
            this.numberOfClassifiedSuite = new int[41];
        }

        public double CheckHitBlow(int[] arg)
        {
            this.numberOfClassifiedSuite = new int[41];
            for (int i = 0; i < this.suite.Length; i++)
            {
                int temp = this.suite[i].CheckHitBlow(arg);
                this.numberOfClassifiedSuite[temp]++;
            }

            Array.Sort(this.numberOfClassifiedSuite);
            return this.GetExpectation();
        }

        private double GetExpectation()
        {
            double result = 0;
            for (int i = 0; i < 41; i++)
            {
                if (this.numberOfClassifiedSuite[i] == 0)
                {
                    continue;
                }

                result += (double)this.numberOfClassifiedSuite[i] * (double)this.numberOfClassifiedSuite[i] / (double)this.suite.Length;
            }

            return result;
        }

        public SetOfSuite GetPossibleSet(int hb)
        {
            Suite[] tempSuite = new Suite[this.suite.Length];
            int index = 0;
            for (int i = 0; i < this.suite.Length; i++)
            {
                if (this.suite[i].GetHitBlow() == hb)
                {
                    tempSuite[index] = this.suite[i];
                    index++;
                }
            }

            Suite[] resultSuite = new Suite[index];
            for (int i = 0; i < index; i++)
            {
                resultSuite[i] = tempSuite[i];
            }

            return new SetOfSuite(resultSuite);
        }

        public int GetNumberOfPossibleSuite()
        {
            return this.suite.Length;
        }

        public int[] GetSuite()
        {
            return this.suite[0].ToIntArray();
       }

    }
}
