using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5404 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<string> BuildArray(int[] target, int n)
        {
            var res = new List<string>();

            var tIndex = 0;
            for (var i = 1; i <= n; i++)
            {
                if (i == target[tIndex])
                {
                    tIndex++;
                    res.Add("Push");

                    if (tIndex == target.Length)
                        break;
                    continue;
                }

                res.Add("Push");
                res.Add("Pop");
            }

            return res;
        }
    }
}
