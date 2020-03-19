using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem643 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            var sum = nums.Take(k).Sum();
            var forReturn = sum;

            var leftIndex = 0;
            var rightIndex = leftIndex + k - 1;
            while (rightIndex + 1 < nums.Length)
            {
                sum += nums[++rightIndex] - nums[leftIndex++];
                forReturn = Math.Max(forReturn, sum);
            }

            return 1.0 * forReturn / k;
        }

        public double FindMaxAverage1(int[] nums, int k)
        {
            var forReturn = 0d;
            var hasNum = false;
            var sum = 0;
            var leftIndex = 0;
            var rightIndex = 0;
            while (rightIndex < nums.Length)
            {
                sum += nums[rightIndex];

                var distance = rightIndex++ - leftIndex + 1;
                if (distance < k) continue;

                if (distance > k)
                    sum -= nums[leftIndex++];

                if (!hasNum)
                {
                    forReturn = 1.0 * sum / k;
                    hasNum = true;
                }
                else
                    forReturn = Math.Max(forReturn, 1.0 * sum / k);
            }

            return forReturn;
        }
    }
}
