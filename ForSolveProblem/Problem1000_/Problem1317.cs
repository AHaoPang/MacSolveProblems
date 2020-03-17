using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1317 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] GetNoZeroIntegers(int n)
        {
            for (int i = 1; i <= n / 2 + 1; i++)
            {
                var j = n - i;

                var isMatch = !i.ToString().Contains('0') && !j.ToString().Contains('0');
                if (isMatch)
                    return new int[] { i, n - 1 };
            }

            return new int[2];
        }
    }
}
