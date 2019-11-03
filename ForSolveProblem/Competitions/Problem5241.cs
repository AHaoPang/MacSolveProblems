using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5241 : IProblem
    {
        public void RunProblem()
        {
            var temp = TilingRectangle(2, 3);
            if (temp != 3) throw new Exception();

            temp = TilingRectangle(5, 8);
            if (temp != 5) throw new Exception();

            temp = TilingRectangle(11, 13);
            if (temp != 6) throw new Exception();
        }

        public int TilingRectangle(int n, int m)
        {
            /*
             * 问题:在给定的矩形里填充最少的正方形
             * 思路:
             *  1.将大问题转换为小问题的过程
             *  2.大的矩形,可能有3种来源
             *      2.1 来源1,纵向切割而来的两个子矩形组成
             *      2.2 来源2,横向切割而来的两个子矩形组成
             *      2.3 来源3,螺旋结构的4个部分组成
             *  3.可定义状态 dp[n,m] 表示n*m矩形最少由几块儿正方形组成
             *  4.dp[n,m] 是3种来源的最小值
             *      4.1 dp[n,m-k] + dp[n][k]
             *      4.2 dp[k,m]+dp[n-k,m]
             *      4.3 dp[k,k]+dp[z,z]+dp[k-z,m-k]+dp[n-k+z,m-k-z]+dp[n-k,k+z]
             * 
             * 关键点:
             * 
             * 时间复杂度:O(n*m*(min(n,m)))
             * 空间复杂度:O(n*m)
             */

            var dp = new int[n + 1, m + 1];
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    dp[i, j] = int.MaxValue;

            for (int fn = 1; fn <= n; fn++)
            {
                for (int fm = 1; fm <= m; fm++)
                {
                    if (fm == fn)
                    {
                        dp[fn, fm] = 1;
                        continue;
                    }

                    int t = int.MaxValue;
                    for (int k = 1; k <= Math.Min(fn, fm); k++)
                    {
                        t = Math.Min(t, dp[fn, fm - k] + dp[fn, k]);
                        t = Math.Min(t, dp[k, fm] + dp[fn - k, fm]);

                        for (int z = 1; z <= Math.Min(k - 1, fm - k - 1); z++)
                            t = Math.Min(t, 2 + dp[k - z, fm - k] + dp[fn - k + z, fm - k - z] + dp[fn - k, k + z]);
                    }
                    dp[fn, fm] = t;
                }
            }

            return dp[n, m];
        }
    }
}
