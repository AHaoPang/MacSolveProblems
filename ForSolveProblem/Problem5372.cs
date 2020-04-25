using System;
namespace ForSolveProblem
{
    public class Problem5372 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinStartValue(int[] nums)
        {
            var res = 1;
            var sum = res;
            foreach (var numItem in nums)
            {
                sum += numItem;
                if (sum <= 0)
                {
                    var newSum = 1 - sum;
                    sum = 1;
                    res += newSum;
                }
            }

            return res;
        }
    }
}
