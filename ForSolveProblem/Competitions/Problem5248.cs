using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5248 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumberOfSubarrays(new int[] { 1, 1, 2, 1, 1 }, 3);
            if (temp != 2) throw new Exception();

            temp = NumberOfSubarrays(new int[] { 2, 4, 6 }, 1);
            if (temp != 0) throw new Exception();

            temp = NumberOfSubarrays(new int[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 }, 2);
            if (temp != 16) throw new Exception();
        }

        public int NumberOfSubarrays(int[] nums, int k)
        {
            var numIndex = new List<int>(50000);
            for (int i = 0; i < nums.Length; i++)
                if ((nums[i] & 1) == 1)
                    numIndex.Add(i);

            if (numIndex.Count < k) return 0;

            var forReturn = 0;
            for (int i = 0; i <= numIndex.Count - k; i++)
            {
                var leftCount = 1;
                if (i > 0)
                    leftCount = numIndex[i] - numIndex[i - 1];
                else
                    leftCount = numIndex[i] + 1;

                var rigthIndex = i + k - 1;

                var rightCount = 1;
                if (rigthIndex < numIndex.Count - 1)
                    rightCount = numIndex[rigthIndex + 1] - numIndex[rigthIndex];
                else
                    rightCount = nums.Length - numIndex[rigthIndex];

                forReturn += leftCount * rightCount;
            }

            return forReturn;
        }
    }
}
