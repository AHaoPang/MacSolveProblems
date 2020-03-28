using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem747 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int DominantIndex(int[] nums)
        {
            var max = nums.Max();
            var isOk = nums.Any(i => i != max && i * 2 > max);
            return isOk ? -1 : Array.IndexOf(nums, max);
        }

        public int DominantIndex1(int[] nums)
        {
            if (nums.Length == 1) return 0;

            var desArray = nums
                .Select((item, i) => new { Index = i, Num = item })
                .OrderByDescending(i => i.Num)
                .ToArray();
            return desArray[0].Num >= desArray[1].Num * 2 ? desArray[0].Index : -1;
        }
    }
}
