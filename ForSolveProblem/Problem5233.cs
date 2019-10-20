using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5233 : IProblem
    {
        public void RunProblem()
        {
            var temp = JobScheduling(new int[] { 1, 2, 3, 3 }, new int[] { 3, 4, 5, 6 }, new int[] { 50, 10, 40, 70 });
            if (temp != 120) throw new Exception();

            temp = JobScheduling(new int[] { 1, 2, 3, 4, 6 }, new int[] { 3, 5, 10, 6, 9 }, new int[] { 20, 20, 100, 70, 60 });
            if (temp != 150) throw new Exception();

            temp = JobScheduling(new int[] { 1, 1, 1 }, new int[] { 2, 3, 4 }, new int[] { 5, 6, 4 });
            if (temp != 6) throw new Exception();

            temp = JobScheduling(new int[] { 4, 2, 4, 8, 2 }, new int[] { 5, 5, 5, 10, 8 }, new int[] { 1, 2, 8, 10, 4 });
            if (temp != 18) throw new Exception();
        }

        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            var maxValue = int.MinValue;
            var endIndexDic = new Dictionary<int, List<int>>();
            for (int i = 0; i < endTime.Length; i++)
            {
                var endTimeTemp = endTime[i];
                maxValue = Math.Max(maxValue, endTimeTemp);

                if (!endIndexDic.ContainsKey(endTimeTemp)) endIndexDic[endTimeTemp] = new List<int>();
                endIndexDic[endTimeTemp].Add(i);
            }

            var forReturn = 0;
            var dp = new int[maxValue + 1];
            for (int i = 1; i < maxValue + 1; i++)
            {
                dp[i] = dp[i - 1];
                if (endIndexDic.ContainsKey(i))
                    foreach (var endIndexItem in endIndexDic[i])
                        dp[i] = Math.Max(dp[i], dp[startTime[endIndexItem]] + profit[endIndexItem]);

                forReturn = Math.Max(forReturn, dp[i]);
            }

            return forReturn;
        }
    }
}
