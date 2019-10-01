using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem123 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxProfit(int[] prices)
        {
            /*
             * 使用动态规划的方式来解决
             * 
             * 状态的定义：
             * 1.最后一天能获取到的最大利润，最优子集显然就是每一天，所以天是一个维度；
             * 2.每一天交易前后，要记着自己已经交易过多少次了，所以已经交易次数是一个维度；
             * 3.每一天自己是否可以买卖股票，依据是自己是否持有股票，所以是否持有股票是一个维度；
             * 
             * 状态转移方程的推演：每一天都会有各种状态，这种状态一定来源于上一天的某几种状态，所以是能够逐渐推演得来的
             * 
             * 因为是否持有股票是常数，买卖股票次数也是常数
             * 时间复杂度分析：O(n)
             * 空间复杂度分析：O(n)
             */

            if (prices.Length < 1) return 0;

            /* 0:第几天 1:第几次交易 2:是否持有股票 */
            int[,,] arrTemp = new int[prices.Length, 3, 2];

            arrTemp[0, 0, 0] = 0;

            arrTemp[0, 1, 1] = -prices[0];
            arrTemp[0, 1, 0] = 0;

            arrTemp[0, 2, 1] = -prices[0];
            arrTemp[0, 2, 0] = 0;

            for(int j = 1; j < prices.Length; j++)
            {
                //当前没有交易过，也没持有股票，则上一天一定没有交易过，且不持有股票
                arrTemp[j, 0, 0] = arrTemp[j - 1, 0, 0];

                //当前交易过一次，且不持有股票，则
                //1.上一天交易过，且不持有股票；
                //2.上一天交易过，即卖掉一股；
                arrTemp[j, 1, 0] = Math.Max(arrTemp[j - 1, 1, 0], arrTemp[j - 1, 1, 1] + prices[j]);
                //当前交易过一次，且持有一股，则
                //1.上一天交易过，买过一股；
                //2.上一天没交易过，持有一股；
                arrTemp[j, 1, 1] = Math.Max(arrTemp[j - 1, 0, 0] - prices[j], arrTemp[j - 1, 1, 1]);

                arrTemp[j, 2, 0] = Math.Max(arrTemp[j - 1, 2, 0], arrTemp[j - 1, 2, 1] + prices[j]);
                arrTemp[j, 2, 1] = Math.Max(arrTemp[j - 1, 1, 0] - prices[j], arrTemp[j - 1, 2, 1]);
            }

            int maxProfix = 0;
            for (int i = 0; i < 3; i++) if (arrTemp[prices.Length - 1, i, 0] > maxProfix)
                    maxProfix = arrTemp[prices.Length - 1, i, 0];

            return maxProfix;
        }
    }
}
