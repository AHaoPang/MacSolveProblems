using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1200 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinimumAbsDifference(new int[] { 4, 2, 1, 3 });

            temp = MinimumAbsDifference(new int[] { 1, 3, 6, 10, 15 });

            temp = MinimumAbsDifference(new int[] { 3, 8, -10, 23, 19, -4, -14, 27 });
        }

        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            var constInt = (int)1e6;
            var constNum = constInt * 2 + 1;
            var countArray = new int[constNum];

            foreach (var arrItem in arr)
                countArray[arrItem + constInt] = 1;

            var forReturn = new List<IList<int>>();

            var startIndex = 0;
            while (startIndex < countArray.Length)
            {
                if (countArray[startIndex] != 0) break;
                startIndex++;
            }

            var minLength = int.MaxValue;
            var nextIndex = startIndex + 1;
            while (nextIndex < countArray.Length)
            {
                if (countArray[nextIndex] != 0)
                {
                    var minTemp = nextIndex - startIndex;
                    if (minTemp <= minLength)
                    {
                        if (minTemp < minLength) forReturn.Clear();

                        minLength = minTemp;
                        forReturn.Add(new List<int>() { startIndex - constInt, nextIndex - constInt });
                    }

                    startIndex = nextIndex;
                }

                nextIndex++;
            }

            return forReturn;
        }
    }
}
