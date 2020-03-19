using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem581 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindUnsortedSubarray(new int[] { 2, 1 });
            ProblemHelper.AEqual(temp, 2);

            temp = FindUnsortedSubarray(new int[] { 2, 3, 3, 2, 4 });
        }

        public int FindUnsortedSubarray(int[] nums)
        {
            var orderNums = nums.OrderBy(i => i).ToArray();

            var leftIndex = -1;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != orderNums[i])
                    break;

                leftIndex = i;
            }

            var rightIndex = nums.Length;
            for (var j = nums.Length - 1; j >= 0; j--)
            {
                if (nums[j] != orderNums[j])
                    break;

                rightIndex = j;
            }

            return rightIndex - leftIndex < 0 ? 0 : rightIndex - leftIndex - 1;
        }

        public int FindUnsortedSubarray1(int[] nums)
        {
            var leftIndex = 0;
            while (leftIndex < nums.Length - 1)
            {
                if (nums[leftIndex] > nums[leftIndex + 1])
                    break;

                leftIndex++;
            }

            var leftAddIndex = leftIndex + 1;
            while (leftAddIndex < nums.Length)
            {
                while (leftIndex >= 0 && nums[leftIndex] > nums[leftAddIndex])
                    leftIndex--;

                if (leftIndex == -1)
                    break;

                leftAddIndex++;
            }

            var rightIndex = nums.Length - 1;
            while (rightIndex > 0)
            {
                if (nums[rightIndex - 1] > nums[rightIndex])
                    break;

                rightIndex--;
            }

            var rightAddIndex = rightIndex - 1;
            while (rightAddIndex >= 0)
            {
                while (rightIndex < nums.Length && nums[rightIndex] < nums[rightAddIndex])
                    rightIndex++;

                if (rightIndex == nums.Length)
                    break;

                rightAddIndex--;
            }

            return rightIndex - leftIndex - 1 < 0 ? 0 : rightIndex - leftIndex - 1;
        }
    }
}
