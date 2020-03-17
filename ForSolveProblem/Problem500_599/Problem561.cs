using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem561 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int ArrayPairSum(int[] nums)
        {
            var forReturn = 0;

            var listTemp = nums.OrderBy(i => i).ToList();
            for (var i = 0; i < nums.Length; i += 2)
                forReturn += listTemp[i];

            return forReturn;
        }
    }
}
