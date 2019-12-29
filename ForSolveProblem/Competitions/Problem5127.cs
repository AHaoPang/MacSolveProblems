using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5127 : IProblem
    {
        public void RunProblem()
        {
            var temp = RemoveCoveredIntervals(new int[][]
            {
                new int[]{1,4},
                new int[]{3,6},
                new int[]{2,8},
            });
            if (temp != 2) throw new Exception();
        }

        public int RemoveCoveredIntervals(int[][] intervals)
        {
            var orderArray = intervals.OrderBy(i => i[0]);

            var forReturn = 1;
            var firstItem = orderArray.First();
            var startPos = firstItem[0];
            var stopPos = firstItem[1];
            foreach (var orderItem in orderArray)
            {
                if (startPos <= orderItem[0] && stopPos >= orderItem[1]) continue;

                if (startPos == orderItem[0] && stopPos < orderItem[1])
                    stopPos = orderItem[1];
                else
                {
                    startPos = orderItem[0];
                    stopPos = orderItem[1];
                    forReturn++;
                }
            }

            return forReturn;
        }
    }
}
