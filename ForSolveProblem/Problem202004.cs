using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem202004 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinJump(new[] { 2, 5, 1, 1, 1, 1 });
        }

        public int MinJump(int[] jump)
        {
            var res = 0;

            var dp = Enumerable.Repeat(-1, jump.Length).ToArray();
            for (var i = 0; i < jump.Length; i++)
            {
                var tarPos = i + jump[i];
                if (tarPos >= jump.Length)
                {
                    dp[i] = jump.Length;
                    continue;
                }

                if (dp[tarPos] != -1) continue;

                dp[tarPos] = i;
            }
            var minLength = jump.Length - 1;
            for (var j = jump.Length - 1; j >= 0; j--)
            {
                if (dp[j] == -1)
                    dp[j] = minLength;
                else
                    minLength = j;
            }


            var targetPos = new List<int>();
            for (var i = 0; i < dp.Length; i++)
            {
                if (dp[i] == jump.Length)
                    targetPos.Add(i);
            }

            while (true)
            {
                res++;

                var newSet = new List<int>();
                foreach (var i in targetPos)
                {
                    var minValueTemp = dp[i];
                    if (minValueTemp == 0)
                        return res;

                    if (minValueTemp < jump.Length)
                        newSet.Add(minValueTemp);
                }

                targetPos = newSet;
            }

            //return res;
        }

        public int MinJump1(int[] jump)
        {
            var res = 1;

            var targetPos = new HashSet<int>();
            var minPos = jump.Length - 1;
            for (var i = minPos - 1; i >= 0 && i >= minPos - 10000; i--)
            {
                if (jump[i] + i >= jump.Length)
                {
                    if (i == 0)
                        return res;

                    targetPos.Add(i);
                    minPos = i;
                }
            }

            while (true)
            {
                res++;

                var newHashSet = new HashSet<int>();
                var newMin = minPos;
                for (var i = minPos - 1; i >= 0 && i >= minPos - 10000; i--)
                {
                    var tarNum = jump[i] + i;
                    if (targetPos.Contains(tarNum))
                    {
                        if (i == 0)
                            return res;

                        newHashSet.Add(i);
                        newMin = i;
                    }
                    else if (tarNum > minPos)
                    {
                        if (i == 0)
                            return res + 1;
                    }
                }

                //for (var i = minPos + 1; i < jump.Length && i < minPos + 10000; i++)
                //{
                //    if (visited[i] == 1) continue;
                //
                //    newHashSet.Add(i);
                //    visited[i] = 1;
                //}

                targetPos = newHashSet;
                minPos = newMin;
            }
        }
    }
}
