using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class ProblemSqrt : IProblem
    {
        public void RunProblem()
        {
            var t = Sqrt(3);

            t = Sqrt(10);

            t = Sqrt(20);

            t = Sqrt(10000);
        }

        private double Sqrt(double n)
        {
            var l = 0d;
            var r = n / 2;

            var m = l + (r - l) / 2;
            while (r - l > 0.000000001)
            {
                if (m * m > n)
                    r = m;
                else
                    l = m;

                m = l + (r - l) / 2;
            }

            return m;
        }
    }
}
