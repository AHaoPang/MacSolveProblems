using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5360 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountLargestGroup(int n)
        {
            static int GetSum(int num)
            {
                var res = 0;
                while (num > 0)
                {
                    res += num % 10;
                    num /= 10;
                }

                return res;
            }

            var arr = Enumerable
                .Range(1, n)
                .GroupBy(i => GetSum(i))
                .OrderByDescending(i => i.Count())
                .ToArray();

            var maxCount = arr.First().Count();
            return arr.TakeWhile(i => i.Count() >= maxCount).Count();
        }
    }
}
