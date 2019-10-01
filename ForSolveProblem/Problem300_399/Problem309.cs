using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem309 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxProfit(new int[] { 1, 2, 3, 0, 2 });
        }

        public int MaxProfit(int[] prices)
        {
            /*
             * 关键点：对状态的准确定义和理解，稍有不慎就会导致状态推演的失败
             * 时间复杂度：O(n*2*2)-->O(n)
             * 空间复杂度：O(n*2*2)-->O(n)
             * 就是对一个三维矩阵的推演，是动态规划的一种，十分精彩了！
             */

            if (prices.Length < 1) return 0;

            //1.第几天的财富状态
            //2.是否处于冷冻期
            //3.是否持有股票
            int[,,] everyDayStatus = new int[prices.Length, 2, 2];

            everyDayStatus[0, 0, 0] = 0;
            everyDayStatus[0, 0, 1] = -prices[0];
            everyDayStatus[0, 1, 0] = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                //非冷冻期且不持有股票，那么肯定没有卖股票，来源就是冷冻和非冷冻期了
                everyDayStatus[i, 0, 0] = Math.Max(everyDayStatus[i - 1, 0, 0], everyDayStatus[i - 1, 1, 0]);

                //非冷冻期，且持有股票，那么是否冷冻都行，也可能是冷冻了一天，刚买了股票
                everyDayStatus[i, 0, 1] = Math.Max(everyDayStatus[i - 1, 0, 1], everyDayStatus[i - 1, 0, 0] - prices[i]);

                //处于冷冻期，且不持有股票，很显然，就是上一天卖掉了
                everyDayStatus[i, 1, 0] = everyDayStatus[i - 1, 0, 1] + prices[i];
            }

            return Math.Max(everyDayStatus[prices.Length - 1, 0, 0], everyDayStatus[prices.Length - 1, 1, 0]);
        }
    }
}
