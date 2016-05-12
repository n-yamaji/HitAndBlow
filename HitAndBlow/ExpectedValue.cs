using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class ExpectedValue
    {
        private Dictionary<int, double> expectedValue;

        public ExpectedValue()
        {
            this.expectedValue = new Dictionary<int, double>();
            for (int i = 1; i <= 9; i++)
            {
                this.expectedValue.Add(i, 0);
            }
        }

        public void Calculate(Number callNumber, HitBlowSet hitBlow)
        {
            int hitCount = hitBlow.HitCount;
            int blowCount = hitBlow.BlowCount;

            for (int digit = 1; digit <= callNumber.DigitLength; digit++)
            {
                int value = callNumber.GetValue(digit);

                if (hitCount == 0)
                {
                    this.expectedValue[value] = 0;
                    continue;
                }

                this.expectedValue[value] += (double)count / (double)callNumber.DigitLength;
            }
        }

        public IEnumerable<int> GetExpectedValuesByDesc()
        {
            return this.expectedValue.OrderByDescending(_ => _.Value).Select(_ => _.Key);
        }
    }
}
