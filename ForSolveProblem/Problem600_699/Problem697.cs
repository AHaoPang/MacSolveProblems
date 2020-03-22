using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem697 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindShortestSubArray(int[] nums)
        {
            var constNum = (int)5e5;
            var countArray = new ArrayItem[constNum];
            var maxCount = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                var curNum = nums[i];
                if (countArray[curNum] == null)
                    countArray[curNum] = new ArrayItem()
                    {
                        Count = 1,
                        LeftIndex = i,
                        RightIndex = i
                    };
                else
                {
                    countArray[curNum].Count++;
                    countArray[curNum].RightIndex = i;

                    maxCount = Math.Max(maxCount, countArray[curNum].Count);
                }
            }

            return countArray.Where(i => i != null && i.Count == maxCount).Min(i => i.RightIndex - i.LeftIndex + 1);
        }

        private class ArrayItem
        {
            public int Count { get; set; }
            public int LeftIndex { get; set; }
            public int RightIndex { get; set; }
        }
    }
}
