using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class Number
    {
        private const int digitLength = 4;
        private int[] number;

        public int DigitLength
        {
            get
            {
                return digitLength;
            }
        }

        public Number(int digit1, int digit2, int digit3, int digit4)
        {
            this.number = new int[digitLength] { digit1, digit2, digit3, digit4 };
        }

        public HitBlowSet AnswerHitBlow(Number callNumber)
        {
            var hitBlow = new HitBlowSet(0, 0);
            for (int digit = 0; digit < this.DigitLength; digit++)
            {
                int value = callNumber.GetValue(digit);
                if (this.IsHit(digit, value))
                {
                    hitBlow.Hit();
                    continue;
                }

                if (this.IsBlow(value))
                {
                    hitBlow.Blow();
                }
            }

            return hitBlow;
        }

        private bool IsHit(int digit, int value)
        {
            return this.number[digit] == value;
        }

        private bool IsBlow(int value)
        {
            return this.number.Contains(value);
        }

        public int GetValue(int digit)
        {
            return this.number[digit];
        }

        public override string ToString()
        {
            string[] numberArray = this.number.Select(_ => _.ToString()).ToArray();
            return string.Join(string.Empty, numberArray);
        }
    }
}
