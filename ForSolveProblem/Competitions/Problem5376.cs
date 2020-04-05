using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5376 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> MinSubsequence(int[] nums)
        {
            var res = new List<int>();
            var halfSum = nums.Sum() / 2;

            var orderArray = nums.OrderByDescending(i => i).ToArray();
            var s = 0;
            for (var i = 0; i < orderArray.Length; i++)
            {
                s += orderArray[i];
                res.Add(orderArray[i]);

                if (s > halfSum)
                    break;
            }

            return res;
        }
    }
}
