using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem912 : IProblem
    {
        public void RunProblem()
        {
            var temp = SortArray(new[] { 5, 2, 3, 1 });
        }

        private Random r = new Random(DateTime.Now.Second);

        public int[] SortArray(int[] nums)
        {
            Recursive(nums, 0, nums.Length - 1);
            return nums;
        }

        private void Recursive(int[] nums, int left, int right)
        {
            if (left >= right) return;

            int splitPoint = r.Next(left, right + 1);
            var t = nums[splitPoint];
            nums[splitPoint] = nums[right];
            nums[right] = t;

            var low = left;
            var fast = left;
            while (fast <= right)
            {
                if (nums[fast] <= t)
                {
                    var max = nums[low];
                    nums[low] = nums[fast];
                    nums[fast] = max;

                    low++;
                }

                fast++;
            }

            Recursive(nums, left, low - 2);
            Recursive(nums, low, right);
        }

        public int[] SortArray1(int[] nums)
        {
            return nums.OrderBy(i => i).ToArray();
        }
    }
}
