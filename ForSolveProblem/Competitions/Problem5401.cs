using System;
namespace ForSolveProblem
{
    public class Problem5401 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool KLengthApart(int[] nums, int k)
        {
            var l = -1;
            for (var r = 0; r < nums.Length; r++)
            {
                if (nums[r] == 1)
                {
                    if (l != -1 && r - l - 1 < k)
                        return false;
                    l = r;
                }
            }

            return true;
        }
    }
}
