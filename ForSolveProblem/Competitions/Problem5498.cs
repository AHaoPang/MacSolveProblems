using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5498 : IProblem
    {
        public void RunProblem()
        {
            var temp = StoneGameV(new[] { 1, 1, 2 });
            if (temp != 3) throw new Exception();
        }

        public int StoneGameV(int[] stoneValue)
        {
            var sumArr = new int[stoneValue.Length + 1];
            var sum = 0;
            for (var i = 0; i < stoneValue.Length; i++)
            {
                sum += stoneValue[i];
                sumArr[i + 1] = sum;
            }

            var dp = new int[stoneValue.Length, stoneValue.Length];
            for (var len = 1; len < stoneValue.Length; len++)
            {
                var start = 0;
                var stop = len;
                while (stop < stoneValue.Length)
                {
                    for (var i = start; i <= stop; i++)
                    {
                        var temp = 0;
                        var leftSum = GetSum(sumArr, start, i);
                        var rightSum = GetSum(sumArr, i + 1, stop);
                        if (leftSum > rightSum)
                        {
                            temp = rightSum;
                            if (i + 1 < stoneValue.Length)
                                temp += dp[i + 1, stop];
                        }
                        else if (leftSum < rightSum)
                        {
                            temp = leftSum + dp[start, i];
                        }
                        else
                        {
                            var maxValue = 0;
                            if (i + 1 < stoneValue.Length)
                                maxValue = Math.Max(dp[start, i], dp[i + 1, stop]);

                            temp = leftSum + maxValue;
                        }

                        dp[start, stop] = Math.Max(dp[start, stop], temp);
                    }

                    start++;
                    stop++;
                }
            }

            return dp[0, stoneValue.Length - 1];
        }

        private int GetSum(int[] sumArr, int start, int stop) => start > stop ? 0 : sumArr[stop + 1] - sumArr[start];
    }
}
