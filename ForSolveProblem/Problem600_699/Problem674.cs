using System;
namespace ForSolveProblem
{
    public class Problem674 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            var forReturn = 0;

            var firstIndex = 0;
            var secondIndex = 1;
            while (secondIndex < nums.Length)
            {
                if (nums[secondIndex] <= nums[secondIndex - 1])
                {
                    forReturn = Math.Max(forReturn, secondIndex - firstIndex);
                    firstIndex = secondIndex;
                }

                secondIndex++;
            }

            forReturn = Math.Max(forReturn, secondIndex - firstIndex);
            return forReturn;
        }
    }
}
