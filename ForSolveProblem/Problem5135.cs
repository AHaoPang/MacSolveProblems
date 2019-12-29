using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5135 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindBestValue(new int[] { 4, 9, 3 }, 10);
        }

        public int FindBestValue(int[] arr, int target)
        {
            var maxNum = arr.Max();

            var numArray = new int[maxNum + 1];
            foreach (var arrItem in arr)
                numArray[arrItem]++;

            var forReturn = 0;
            var minValue = int.MaxValue;

            var preSum = 0;
            var preCount = 0;
            for (int i = 0; i <= maxNum; i++)
            {
                if(i != 0)
                {
                    preSum += numArray[i - 1] * (i - 1);
                    if (numArray[i - 1] != 0) preCount += numArray[i - 1];
                }

                var curSum = i * (arr.Length - preCount);

                var minTemp = Math.Abs(target - (curSum + preSum));
                if (minTemp < minValue)
                {
                    forReturn = i;
                    minValue = minTemp;
                }
            }

            return forReturn;
        }
    }
}
