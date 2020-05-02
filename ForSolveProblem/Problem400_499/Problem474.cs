using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem474 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindMaxForm(new string[] { "10", "0001", "111001", "1", "0" }, 5, 3);
            if (temp != 4) throw new Exception();

            temp = FindMaxForm(new string[] { "10", "0", "1" }, 1, 1);
            if (temp != 2) throw new Exception();
        }

        public int FindMaxForm(string[] strs, int m, int n)
        {
            var nStrs = strs.Select(i => AnalyzedStr(i)).ToArray();
            var dp = new int[m + 1, n + 1];
            foreach (var (mCount, nCount) in nStrs)
                for (var i = m; i >= mCount; i--)
                    for (var j = n; j >= nCount; j--)
                        dp[i, j] = Math.Max(dp[i, j], dp[i - mCount, j - nCount] + 1);

            return dp[m, n];
        }

        private (int mCount, int nCount) AnalyzedStr(string str)
        {
            var m = 0;
            var n = 0;
            foreach (var strItem in str)
            {
                if (strItem == '0') m++;
                else n++;
            }

            return (m, n);
        }

        public int FindMaxForm3(string[] strs, int m, int n)
        {
            return BackTrace(strs, 0, m, n, new Dictionary<string, int>());
        }

        private int BackTrace(string[] strs, int strIndex, int restM, int restN, IDictionary<string, int> dic)
        {
            if (strIndex == strs.Length) return 0;

            var strTemp = $"{strIndex}_{restN}_{restM}";
            if (dic.ContainsKey(strTemp)) return dic[strTemp];

            var strItem = strs[strIndex];
            var zeroCount = strItem.Length - strItem.Replace("0", "").Length;
            var oneCount = strItem.Length - zeroCount;

            var noIn = BackTrace(strs, strIndex + 1, restM, restN, dic);

            var yesIn = 0;
            if (restM >= zeroCount && restN >= oneCount)
                yesIn = BackTrace(strs, strIndex + 1, restM - zeroCount, restN - oneCount, dic) + 1;

            var forReturn = Math.Max(noIn, yesIn);
            dic[strTemp] = forReturn;
            return forReturn;
        }

        public int FindMaxForm1(string[] strs, int m, int n)
        {
            /*
             * 题目概述：使用给定的原材料，尽可能多的构建指定物品
             * 
             * 思路：
             *  1. 是背包问题的简单变种，即一共有 2 种限制
             *  2. 背包状态：dp[i][n][m] = max( dp[i-1][n][m],1 + dp[i-1][n-i0][m-i1] )
             *
             * 关键点：
             *
             * 时间复杂度：O(mnk)
             * 空间复杂度：O(mnk)
             */

            var forReturn = 0;
            var dp = new int[strs.Length + 1, m + 1, n + 1];

            for (int i = 1; i <= strs.Length; i++)
            {
                var strItem = strs[i - 1];
                var zeroCount = strItem.Length - strItem.Replace("0", "").Length;
                var oneCount = strItem.Length - zeroCount;

                for (int zero = 0; zero <= m; zero++)
                {
                    for (int one = 0; one <= n; one++)
                    {
                        dp[i, zero, one] = dp[i - 1, zero, one];

                        if (zero - zeroCount >= 0 && one - oneCount >= 0)
                            dp[i, zero, one] = Math.Max(dp[i, zero, one], 1 + dp[i - 1, zero - zeroCount, one - oneCount]);

                        if (dp[i, zero, one] > forReturn) forReturn = dp[i, zero, one];
                    }
                }
            }

            return forReturn;
        }
    }
}
