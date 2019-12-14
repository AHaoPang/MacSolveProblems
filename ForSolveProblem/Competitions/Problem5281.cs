using System;
namespace ForSolveProblem
{
    public class Problem5281 : IProblem
    {
        public void RunProblem()
        {
            var temp = SmallestDivisor(new int[] { 1, 2, 5, 9 }, 6);
            if (temp != 5) throw new Exception();

            temp = SmallestDivisor(new int[] { 2, 3, 5, 7, 11 }, 11);
            if (temp != 3) throw new Exception();

            temp = SmallestDivisor(new int[] { 19 }, 5);
            if (temp != 4) throw new Exception();

            temp = SmallestDivisor(new int[] { 962551, 933661, 905225, 923035, 990560 }, 10);
            if (temp != 495280) throw new Exception();
        }

        public int SmallestDivisor(int[] nums, int threshold)
        {
            var minValue = 1;
            var maxValue = (int)1e6;

            while (minValue <= maxValue)
            {
                var midValue = minValue + ((maxValue - minValue) >> 2);
                var midNum = SumArray(nums, midValue);

                if (midNum > threshold)
                    minValue = midValue + 1;
                else
                    maxValue = midValue - 1;
            }

            return minValue;
        }

        private int SumArray(int[] nums, int num)
        {
            var forReturn = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var tempValue = nums[i] / num;
                if (nums[i] % num != 0) tempValue += 1;

                forReturn += tempValue;
            }

            return forReturn;
        }
    }
}
