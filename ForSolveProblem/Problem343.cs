using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem343 : IProblem
    {
        public void RunProblem()
        {
            var temp = IntegerBreak(2);
            if (temp != 1) throw new Exception();

            temp = IntegerBreak(10);
            if (temp != 36) throw new Exception();
        }

        public int IntegerBreak(int n)
        {
            /*
             * 整数拆分，期望得到的拆分乘积最大
             * 思路：
             *  1.无论一个整数拆分成了多少个部分，最后一定是两数的乘积，两数的情况分为：
             *      1.1 实实在在拆分成两个数，然后乘积
             *      1.2 拆分的两个数都是已经合并过的了
             *      1.3 1个数字是拆分出来的，另一个数是合并过了的
             *  2.所以只要知道以上3种情况下的最大值即可，这么看来，其实也算是一个递归求解的问题了
             *  3.但是使用动态规划效率会更高，它可以合并重复的子问题
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            var dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                var res = int.MinValue;
                for (int j = 1; j < i; j++)
                {
                    var v1 = j * (i - j);
                    var v2 = dp[j] * dp[i - j];
                    var v3 = j * dp[i - j];

                    res = Math.Max(res, Math.Max(v3, Math.Max(v1, v2)));
                }

                dp[i] = res;
            }

            return dp[n];
        }
    }
}
