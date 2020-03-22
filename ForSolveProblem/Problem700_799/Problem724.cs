using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem724 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int PivotIndex(int[] nums)
        {
            var sum = nums.Sum();

            var sumTemp = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var numItem = nums[i];

                var remain = sum - numItem;
                if ((remain & 1) == 0 && (remain >> 1) == sumTemp)
                    return i;

                sumTemp += numItem;
            }

            return -1;
        }
    }
}
