using System;
namespace ForSolveProblem
{
    public class Problem665 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 1) return true;

            var count = 0;
            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] <= nums[i + 1]) continue;

                if (++count > 1) return false;

                if (i == 0)
                    nums[i] = nums[i + 1];
                else
                    nums[i] = nums[i - 1];

                i -= 2;
                if (i < -1) i = -1;
            }

            return true;
        }
    }
}
