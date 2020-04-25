using System;
namespace ForSolveProblem
{
    public class Problem202001 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinCount(int[] coins)
        {
            var res = 0;
            foreach (var item in coins)
                res += item / 2 + item % 2;

            return res;
        }
    }
}
