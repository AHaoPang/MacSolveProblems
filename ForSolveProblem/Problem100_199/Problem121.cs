using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem121 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxProfit(int[] prices)
        {
            /*
             * ##### 1. 题目概述：买卖股票的最佳时机
             * 
             * ##### 2. 思路：
             *    - 特征：股票每日的价格构成了一个折线图;若想获得最大的利润,那么就应该是很低的价格买入,然后在以后以很高的价格卖出;
             *    - 方案：站在结果的角度来看,有一天卖出了,那么一定是当天之前最低价格入手的,然后以当天价格卖出的;截止当天最低价格是可知的,当天价格也是明确的;
             *    - 结果：只要找到每天卖出的最大利润,就得到了解
             *
             * ##### 3. 知识点：数组 DP
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(1)
             */

            var forReturn = 0;
            if (prices.Length == 0) return forReturn;

            var minValue = prices.First();
            foreach (var priceItem in prices)
            {
                minValue = Math.Min(priceItem, minValue);

                if (priceItem > minValue && priceItem - minValue > forReturn)
                    forReturn = priceItem - minValue;
            }

            return forReturn;
        }

        public int MaxProfit2(int[] prices)
        {
            /*
             * 遍历一次的方法：
             * 假设了自己在每个地位都买过，并在每个高位都买过，最后的目标是比较并获取最大利润
             * 1.时间复杂度：循环了一次，O(n)；
             * 2.空间复杂度：占用空间数是固定的，所以O(1)；
             */

            int minPrices = int.MaxValue;
            int maxProfix = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrices)
                    minPrices = prices[i];
                else if (prices[i] - minPrices > maxProfix)
                    maxProfix = prices[i] - minPrices;
            }

            return maxProfix;
        }

        public int MaxProfit3(int[] prices)
        {
            /*
             * 穷举法（找出所有的配对组合），复杂度分析：
             * 1.时间复杂度，是一个循环嵌套，因此复杂度是O(n^2)；-->随着数据规模的增加，会逐渐变大！
             * 2.空间复杂度，使用的空间大小是有限的，因此复杂度是O(1)
             */

            int maxProfix = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    var temp = prices[j] - prices[i];
                    if (temp > maxProfix) maxProfix = temp;
                }
            }

            return maxProfix;
        }
    }
}
