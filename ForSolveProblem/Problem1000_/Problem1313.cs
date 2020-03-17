using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1313 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] DecompressRLElist(int[] nums)
        {
            var forReturn = new List<int>();

            for (int i = 0; i < nums.Length - 1; i += 2)
            {
                var repeatTimes = nums[i];
                var repeatNum = nums[i + 1];

                for (int j = 0; j < repeatTimes; j++)
                    forReturn.Add(repeatNum);
            }

            return forReturn.ToArray();
        }
    }
}
