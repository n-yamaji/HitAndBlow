using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitAndBlow
{
    class Program
    {
        static void Main(string[] args)
        {
            HitAndBlow hab = new HitAndBlow();
            Suite answer = new Suite(5, 0, 6, 7);
            for (int i = 0; i < 100; i++)
            {
                int[] tempAnswer = hab.Answer();
                int tempHb = answer.CheckHitBlow(tempAnswer);
                if (tempHb == 40)
                {
                    break;
                }

                hab.SetResult(tempHb);
            }

            //var patterns = new Patterns();
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= 9; j++)
            //    {
            //        if (i == j) continue;
            //        for (int k = 1; k <= 9; k++)
            //        {
            //            if (i == k) continue;
            //            if (j == k) continue;
            //            for (int l = 1; l <= 9; l++)
            //            {
            //                if (i == l) continue;
            //                if (j == l) continue;
            //                if (k == l) continue;
            //                int pattern = (i * 1000) + (j * 100) + (k * 10) + l;
            //                patterns.Add(new Pattern(pattern));
            //                Console.WriteLine(pattern);
            //            }
            //        }
            //    }
            //}

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    string[] parameters = input.Split(' ');
            //    int number = int.Parse(parameters[0]);
            //    int hit = int.Parse(parameters[1]);
            //    int blow = int.Parse(parameters[2]);
            //    patterns.Filter(number,hit,blow);
            //    Console.WriteLine(patterns);
            //}

            Console.ReadLine();
        }
    }

    public class Patterns
    {
        private List<Pattern> items;

        public Patterns()
        {
            this.items = new List<Pattern>();
        }

        public void Add(Pattern pattern)
        {
            this.items.Add(pattern);
        }

        public Patterns Filter(int number, int hit, int blow)
        {
            var filtedPatterns = new Patterns();
            filtedPatterns.items = this.items.Where(_ => _.IsMatch(number, hit, blow)).ToList();
            return filtedPatterns;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var pattern in items)
            {
                builder.AppendLine(pattern.ToString());
            }

            return builder.ToString();
        }
    }

    public class Pattern
    {
        private int number;
        public Pattern(int number)
        {
            this.number = number;
        }

        public bool IsMatch(int number, int hit, int blow)
        {
            if (blow == 0)
            {
                if (this.number == number) { return false; }
                //int one = number % 10;
                //int two = number / 10;
                //int two = number / 100;
                //int two = number / 1000;

                //if (this.number )
                //{

                //}

                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return this.number.ToString();
        }
    }
}
