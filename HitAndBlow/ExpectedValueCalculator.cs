using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class ExpectedValueCalculator
    {
        private Dictionary<int, ExpectedValue> eachDigit;
        private ExpectedValue value;
        private List<Number> calledNumbers;

        public ExpectedValueCalculator(int digitLength)
        {
            this.eachDigit = new Dictionary<int, ExpectedValue>();
            for (int digit = 1; digit <= digitLength; digit++)
            {
                this.eachDigit.Add(digit, new ExpectedValue());
            }

            this.value = new ExpectedValue();
            this.calledNumbers = new List<Number>();
        }

        public IEnumerable<Number> Calculate(Number callNumber,HitBlowSet hitBlow)
        {
            this.calledNumbers.Add(callNumber);
            this.eachDigit = new Dictionary<int, ExpectedValue>();
            for (int digit = 1; digit <= callNumber.DigitLength; digit++)
            {
                this.eachDigit[digit].Calculate(callNumber, hitBlow);
            }

            this.value.Calculate(callNumber, hitBlow);

            return this.CreateHighExpectedNumbers(callNumber.DigitLength);
        }

        private IEnumerable<Number> CreateHighExpectedNumbers(int digitLength)
        {
            var zeroExpectedValues = this.value.GetZeroExpectedValues();
            var eachDigitHighScoreValues = new Dictionary<int, IEnumerable<int>>();
            for (int digit = 1; digit <= digitLength; digit++)
            {
                var highOrderDigitExpextecValues = this.eachDigit[digit].GetExpectedValuesByDesc();
                var allowedValues = highOrderDigitExpextecValues.Except(zeroExpectedValues);
                eachDigitHighScoreValues.Add(digit, allowedValues);
            }

            // 期待値の高い Number を生成
            for (int digit = 1; digit <= digitLength; digit++)
            {
                foreach (var digit1 in eachDigitHighScoreValues[digit])
                {
                    int digit2 = eachDigitHighScoreValues[digit + 1].First(_ => _ != digit1);
                    int digit3 = eachDigitHighScoreValues[digit + 2].First(_ => _ != digit1 && _ != digit2);
                    int digit4 = eachDigitHighScoreValues[digit + 3].First(_ => _ != digit1 && _ != digit2 && _ != digit3);

                    var number = new Number(digit1, digit2, digit3, digit4);
                    if (this.calledNumbers.Contains(number))
                    {
                        continue;
                    }

                    yield return number;
                }
            }
        }
    }
}
