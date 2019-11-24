using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5274 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumWays(3, 2);
            if (temp != 4) throw new Exception();

            temp = NumWays(2, 4);
            if (temp != 2) throw new Exception();

            temp = NumWays(4, 2);
            if (temp != 8) throw new Exception();

            temp = NumWays(500, 969997);
            if (temp != 374847123) throw new Exception();
        }

        public int NumWays(int steps, int arrLen)
        {
            /*
             * 题目概述：一个指针,在多轮移动操作以后,还在指定位置上的方案有多少种
             * 
             * 思路：
             *  1.因为每次移动,最多移动 1 个单元格,因此最后的结果,取决于 3 个数值
             *      1.1 上一步在 0,本次没有移动还在 0 位置
             *      1.2 上一步在 1,本次移动 1 个位置到 0
             *  2.使用动态规划的方式,做顺序的统计
             *  3.状态 dp[n,2] 表示走到当前索引位置,有多少种方案
             *      3.1 dp[n,1] = dp[n-1,0] + dp[n,0] + dp[n+1,0];
             *
             * 关键点：
             *
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(1)
             */

            var modNum = (int)(1e9 + 7);
            var lenTemp = Math.Min(steps / 2 + 1, arrLen);
            var dp = new int[lenTemp, 2];
            dp[0, 0] = 1;

            for (int step = 1; step < steps; step++)
            {
                for (int len = 0; len < Math.Min(step + 1, lenTemp); len++)
                {
                    var numArray = new int[3];

                    var preNum = 0;
                    if (len - 1 >= 0) preNum = dp[len - 1, 0];
                    numArray[0] = preNum;

                    var curNum = dp[len, 0];
                    numArray[1] = curNum;

                    var nextNum = 0;
                    if (len + 1 <= arrLen - 1) nextNum = dp[len + 1, 0];
                    numArray[2] = nextNum;

                    var finNum = 0;
                    for (int n = 0; n < numArray.Length; n++)
                    {
                        finNum += numArray[n];
                        finNum %= modNum;
                    }

                    dp[len, 1] = finNum;
                }

                for (int t = 0; t < lenTemp; t++)
                    dp[t, 0] = dp[t, 1];
            }

            return (dp[0, 1] + dp[1, 1]) % modNum;
        }
    }
}
