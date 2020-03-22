using System;
namespace ForSolveProblem
{
    public class Problem704 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int Search(int[] nums, int target)
        {
            /*
             * 算法复杂度:
             *  1.时间复杂度:O(logn)
             *  2.空间复杂度:O(1)
             */

            var leftIndex = 0;
            var rightIndex = nums.Length - 1;

            while (leftIndex <= rightIndex)
            {
                var mid = leftIndex + (rightIndex - leftIndex) / 2;

                if (nums[mid] == target) return mid;

                if (nums[mid] > target)
                    rightIndex = mid - 1;
                else
                    leftIndex = mid + 1;
            }

            return -1;
        }
    }
}
