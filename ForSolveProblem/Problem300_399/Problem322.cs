using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem322 : IProblem
    {
        public void RunProblem()
        {
            var temp = CoinChange(new int[] { 2 }, 3);
        }

        public int CoinChange(int[] coins, int amount)
        {
            /*
             * ##### 1. 题目概述：零钱兑换
             * 
             * ##### 2. 思路：
             *    - 特征：类似背包问题,总容量固定,装够总量以后,怎么装,物品个数最少
             *    - 方案：使用 DP,定义状态 dp[amount][coin] 表示使用完当前硬币,达到目标值所需的最少硬币数;
             *    - 结果：每种硬币状态下,达到目标值的货币数的最小值,即为解
             *
             * ##### 3. 知识点：动态规划
             * 
             * ##### 4. 复杂度分析: n 表示目标值 m 表示不同硬币个数 
             *    - 时间复杂度：O(n*m)
             *    - 空间复杂度：O(n)
             */

            var dp = Enumerable.Repeat(-1, amount + 1).ToArray();
            dp[0] = 0;

            var forReturn = -1;
            foreach (var coinItem in coins)
            {
                for (var i = 1; i <= amount; i++)
                    if (i - coinItem >= 0 && dp[i - coinItem] != -1)
                        dp[i] = dp[i] == -1 ? dp[i - coinItem] + 1 : Math.Min(dp[i - coinItem] + 1, dp[i]);

                if (dp[amount] != -1)
                    forReturn = forReturn == -1 ? dp[amount] : Math.Min(forReturn, dp[amount]);
            }

            return forReturn;
        }

        public int CoinChange4(int[] coins, int amount)
        {
            /*
             * 动态规范法分析：
             * 状态定义：一个一维数组，总长度是amount+1，数组中的值表示凑成这个数字，最少需要多少coins
             * 状态推演：当前数字一定是上一步凑成数字+coin后得到的 minChangeArr[y] = min(minChangeArr[0~x])+1
             * 记住特殊情况的处理：若这个数字是无法达成的，那么就加个特殊标识好了，此处使用的是 int.MaxValue
             * 时间复杂度：数组的两层循环 O(amount * conins.length)
             * 空间复杂度：一个一维数组 O(amount)
             */

            int[] minChangeArr = new int[amount + 1];

            for (int i = 1; i < amount + 1; i++)
            {
                int minTemp = int.MaxValue;
                foreach (var coin in coins)
                    if (i - coin >= 0 && minChangeArr[i - coin] < minTemp)
                        minTemp = minChangeArr[i - coin];

                if (minTemp == int.MaxValue)
                    minChangeArr[i] = minTemp;
                else
                    minChangeArr[i] = minTemp + 1;
            }

            return minChangeArr[amount] == int.MaxValue ? -1 : minChangeArr[amount];
        }

        public int CoinChange2(int[] coins, int amount)
        {
            if (amount == 0) return 0;

            foreach (var item in coins) if (item <= amount)
                    Recursive(coins, 0, item, 1, amount);

            return minChange == int.MaxValue ? -1 : minChange;
        }

        #region 回溯法
        /*
         * 回溯法分析
         * 为了到达目标值，每次都可以做很多种尝试，每种尝试的机会是平等的
         * 时间复杂度：是指数级的复杂度
         * 空间复杂度：同样是指数级的复杂度
         */

        private int minChange = int.MaxValue;

        public Problem322()
        {
        }

        /// <summary>
        /// 回溯求解
        /// </summary>
        /// <param name="coins">所有可用硬币</param>
        /// <param name="readyAmount">已经汇总得到的数量</param>
        /// <param name="curCoin">准备放入的硬币</param>
        /// <param name="curCount">当前硬币的总数</param>
        /// <param name="amount">汇总的目标数量</param>
        private void Recursive(int[] coins, int readyAmount, int curCoin, int curCount, int amount)
        {
            //end point
            if (amount == 0)
            {
                if (minChange > curCount - 1) minChange = curCount - 1;
                return;
            }

            if (amount < 0) return;

            foreach (var item in coins) if (item <= amount)
                    Recursive(coins, readyAmount, item, curCount + 1, amount - curCoin);
        }

        #endregion
    }
}
