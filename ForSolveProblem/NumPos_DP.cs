using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class NumPos_DP : IProblem
    {
        public void RunProblem()
        {
            var temp = CountContain49Nums(1);
            if (temp != 0) throw new Exception();

            temp = CountContain49Nums(50);
            if (temp != 1) throw new Exception();

            temp = CountContain49Nums(500);
            if (temp != 15) throw new Exception();
        }

        /// <summary>
        /// 统计 1~maxNum 的数字中,包含 49 的数字的个数
        /// </summary>
        private long CountContain49Nums(long maxNum)
        {
            var posNumArr = CountPosNumLimit(maxNum);

            return maxNum + 1 - Dfs(posNumArr, posNumArr.Length - 1, false, true, new long[posNumArr.Length, 2]);
        }

        private int[] CountPosNumLimit(long num)
        {
            var res = new List<int>() { 0 };
            while (num > 0)
            {
                var lastPos = num % 10;
                res.Add((int)lastPos);

                num /= 10;
            }

            return res.ToArray();
        }

        private long Dfs(int[] posNumArr, int curPos, bool is4, bool isLimit, long[,] dp)
        {
            if (curPos == 0)
                return 1;

            var flag = is4 ? 1 : 0;

            if (!isLimit && dp[curPos, flag] != 0)
                return dp[curPos, flag];

            var maxPosNum = isLimit ? posNumArr[curPos] : 9;

            var res = 0L;
            for (var i = 0; i <= maxPosNum; i++)
            {
                if (is4 && i == 9)
                    continue;

                res += Dfs(posNumArr, curPos - 1, i == 4, isLimit && i == posNumArr[curPos], dp);
            }

            if (!isLimit)
                dp[curPos, flag] = res;
            return res;
        }
    }
}
