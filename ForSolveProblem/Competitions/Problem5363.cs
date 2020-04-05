using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5363 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxSatisfaction(int[] satisfaction)
        {
            var orderArr = satisfaction
                .OrderBy(i => i)
                .ToArray();

            var res = 0;
            var sum = 0;
            var curIncrease = 0;
            for (var j = orderArr.Length - 1; j >= 0; j--)
            {
                sum += orderArr[j];
                curIncrease += sum;
                res = Math.Max(res, curIncrease);
            }

            return res;
        }
    }
}
