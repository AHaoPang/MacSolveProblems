using System;
namespace ForSolveProblem
{
    public class Problem330 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinPatches(new[] { 1, 3 }, 6);
            if (temp != 1) throw new Exception();

            temp = MinPatches(new[] { 1, 5, 10 }, 20);
            if (temp != 2) throw new Exception();

            temp = MinPatches(new[] { 1, 2, 2 }, 5);
            if (temp != 0) throw new Exception();

            temp = MinPatches(new[] { 1, 2, 31, 33 }, 2147483647);

        }

        public int MinPatches(int[] nums, int n)
        {
            var res = 0;

            var curValue = 1l;
            var index = 0;
            while (curValue <= n)
            {
                if (index < nums.Length && nums[index] <= curValue)
                {
                    curValue += nums[index];
                    index++;
                }
                else
                {
                    res++;
                    curValue *= 2;
                }
            }

            return res;
        }
    }
}
