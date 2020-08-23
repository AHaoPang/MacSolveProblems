using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem233 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountDigitOne(13);
            if (temp != 6) throw new Exception();

            temp = CountDigitOne(300);
        }

        public int CountDigitOne(int n)
        {
            m_posArr = GetPosArr(n);
            m_dp = new int[m_posArr.Length, 15];

            return CountDfs(m_posArr.Length - 1, true, 0);
        }

        private int[] m_posArr;
        private int[,] m_dp;

        private int CountDfs(int curPos, bool isLimit, int count1)
        {
            if (curPos == 0)
                return count1;

            if (!isLimit && m_dp[curPos, count1] != 0)
                return m_dp[curPos, count1];

            var res = 0;
            var max = isLimit ? m_posArr[curPos] : 9;
            for (var i = 0; i <= max; i++)
                res += CountDfs(curPos - 1, isLimit && i == m_posArr[curPos], count1 + (i == 1 ? 1 : 0));

            if (!isLimit)
                m_dp[curPos, count1] = res;

            return res;
        }

        private int[] GetPosArr(int n)
        {
            var res = new List<int>() { 0 };
            while (n > 0)
            {
                res.Add(n % 10);
                n /= 10;
            }

            return res.ToArray();
        }



        public int CountDigitOne2(int n)
        {
            var posArr = GetPosArr(n);

            return Dfs(posArr, posArr.Length - 1, new int[posArr.Length], true, false);
        }

        private int Dfs(int[] posArr, int curPos, int[] dp, bool isLimit, bool isOne)
        {
            if (!isLimit && !isOne && dp[curPos] != 0)
                return dp[curPos];

            var res = 0;
            if (!isLimit && isOne)
                res += (int)Math.Pow(10, curPos);

            var max = isLimit ? posArr[curPos] : 9;
            for (var i = 0; i <= max; i++)
            {
                if (curPos == 1)
                {
                    if (i == 1 || isOne)
                        res += 1;

                    continue;
                }

                if (i == 1)
                    res += 1;
                res += Dfs(posArr, curPos - 1, dp, isLimit && i == posArr[curPos], i == 1);
            }

            if (!isLimit && !isOne)
                dp[curPos] = res;

            return res;
        }

        public int CountDigitOne1(int n)
        {
            var length = n.ToString().Length;
            var res = 0L;
            var i = 1L;
            for (var c = 0; c < length; c++)
            {
                res += n / (10 * i) * i + Math.Min(Math.Max(n % (10 * i) - i + 1, 0), i);
                i *= 10;
            }

            return (int)res;
        }
    }
}
