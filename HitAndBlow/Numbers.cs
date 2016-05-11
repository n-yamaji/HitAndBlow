using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    public class Numbers
    {
        private List<Number> numbers;

        public Numbers(Number[] numbers)
        {
            this.numbers = new List<Number>(numbers);
        }

    }
}
