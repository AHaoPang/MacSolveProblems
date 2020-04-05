using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem042 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int Trap(int[] height)
        {
            if (height.Length <= 1) return 0;

            var res = 0;
            var leftIndex = 0;
            var leftMax = height.First();
            var rightIndex = height.Length - 1;
            var rightMax = height.Last();
            while (leftIndex < rightIndex)
            {
                leftMax = Math.Max(leftMax, height[leftIndex]);
                rightMax = Math.Max(rightMax, height[rightIndex]);

                res += leftMax >= rightMax ? rightMax - height[rightIndex--] : leftMax - height[leftIndex++];
            }

            return res;
        }

        public int Trap2(int[] height)
        {
            if (height.Length <= 1) return 0;

            var max = height.First();
            var leftToRightArray = height
                .Select(i => { max = Math.Max(i, max); return max; })
                .ToArray();

            var rMax = height.Last();
            var rightToLeftArray = height
                .Reverse()
                .Select(i => { rMax = Math.Max(i, rMax); return rMax; })
                .Reverse()
                .ToArray();

            return height
                .Select((item, index) => Math.Min(leftToRightArray[index], rightToLeftArray[index]) - item)
                .Sum();
        }

        public int Trap1(int[] height)
        {
            if (height.Length <= 1) return 0;

            var leftToRightArray = new int[height.Length];
            var max = height.First();
            for (var i = 0; i < height.Length; i++)
            {
                max = Math.Max(max, height[i]);
                leftToRightArray[i] = max;
            }

            var rightToLeftArray = new int[height.Length];
            var rMax = height.Last();
            for (var j = height.Length - 1; j >= 0; j--)
            {
                rMax = Math.Max(rMax, height[j]);
                rightToLeftArray[j] = rMax;
            }

            var res = 0;
            for (var i = 0; i < height.Length; i++)
                res += Math.Min(leftToRightArray[i], rightToLeftArray[i]) - height[i];

            return res;
        }
    }
}
