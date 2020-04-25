using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5373 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindMinFibonacciNumbers(int k)
        {
            var list = GetNumsArray(k);
            var res = 0;

            for (var j = list.Count - 1; j >= 0; j--)
            {
                if (k >= list[j])
                {
                    res++;
                    k -= (int)list[j];
                }

                if (k == 0)
                    break;
            }

            return res;
        }

        private List<long> GetNumsArray(int maxNum)
        {
            var res = new List<long>();

            res.Add(1);
            res.Add(1);

            while (true)
            {
                var sum = res[res.Count - 1] + res[res.Count - 2];
                if (sum > maxNum)
                    break;

                res.Add(sum);
            }

            return res;
        }
    }
}
