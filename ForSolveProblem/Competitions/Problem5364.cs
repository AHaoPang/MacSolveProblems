using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5364 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            var forReturn = new List<int>(nums.Length);
            for(var i = 0;i < nums.Length; i++)
                forReturn.Insert(index[i], nums[i]);

            return forReturn.ToArray();
        }
    }
}
