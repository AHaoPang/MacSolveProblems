using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5481 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinOperations(new[] { 1, 5 });
            if (temp != 5) throw new Exception();

            temp = MinOperations(new[] { 2, 2 });
            if (temp != 3) throw new Exception();

            temp = MinOperations(new[] { 4, 2, 5 });
            if (temp != 6) throw new Exception();

            temp = MinOperations(new[] { 3, 2, 2, 4 });
            if (temp != 7) throw new Exception();

            temp = MinOperations(new[] { 2, 4, 8, 16 });
            if (temp != 8) throw new Exception();
        }

        public int MinOperations(int[] nums)
        {
            var numCountDic = nums
                .GroupBy(i => i)
                .ToDictionary(i => i.Key, j => j.Count());

            var res = 0;
            var maxDouble = 0;
            foreach (var dicItem in numCountDic)
            {
                var maxAndOneCount = GetMaxDoubleAndOneCount(dicItem.Key);
                maxDouble = Math.Max(maxDouble, maxAndOneCount.Item1);
                res += maxAndOneCount.Item2 * dicItem.Value;
            }

            return res + maxDouble;
        }

        private Tuple<int, int> GetMaxDoubleAndOneCount(int n)
        {
            var maxDouble = 0;
            var oneCount = 0;

            while (n != 0)
            {
                if (n % 2 == 0)
                {
                    maxDouble++;
                    n >>= 1;
                }
                else
                {
                    oneCount++;
                    n--;
                }
            }

            return Tuple.Create(maxDouble, oneCount);
        }
    }
}
