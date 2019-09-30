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
             * 动态规范法分析：
             * 状态定义：一个一维数组，总长度是amount+1，数组中的值表示凑成这个数字，最少需要多少coins
             * 状态推演：当前数字一定是上一步凑成数字+coin后得到的 minChangeArr[y] = min(minChangeArr[0~x])+1
             * 记住特殊情况的处理：若这个数字是无法达成的，那么就加个特殊标识好了，此处使用的是 int.MaxValue
             * 时间复杂度：数组的两层循环 O(amount * conins.length)
             * 空间复杂度：一个一维数组 O(amount)
             */

            int[] minChangeArr = new int[amount + 1];

            for(int i = 1; i < amount + 1; i++)
            {
                int minTemp = int.MaxValue;
                foreach(var coin in coins) if (i - coin >= 0 && minChangeArr[i - coin] < minTemp) minTemp = minChangeArr[i - coin];

                if (minTemp == int.MaxValue) minChangeArr[i] = minTemp;
                else minChangeArr[i] = minTemp + 1;
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
