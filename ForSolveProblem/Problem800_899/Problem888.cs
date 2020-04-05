using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem888 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] FairCandySwap(int[] A, int[] B)
        {
            var constNum = (A.Sum() - B.Sum()) / 2;
            var bSet = new HashSet<int>(B);
            foreach (var aItem in A)
            {
                var r = aItem - constNum;
                if (bSet.Contains(r))
                    return new[] { aItem, r };
            }

            return new[] { 0 };
        }

        public int[] FairCandySwap1(int[] A, int[] B)
        {
            var aSum = A.Sum();
            var bSum = B.Sum();
            var sub = aSum - (aSum + bSum) / 2;

            var aIndex = 0;
            var bIndex = 0;
            var orderA = A.OrderBy(i => i).ToArray();
            var orderB = B.OrderBy(i => i).ToArray();
            while (true)
            {
                var remain = orderA[aIndex] - orderB[bIndex];

                if (remain == sub)
                    return new[] { orderA[aIndex], orderB[bIndex] };

                if (remain > sub)
                    bIndex++;
                else
                    aIndex++;
            }
        }
    }
}
