using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem122 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 });
        }

        public int MaxProfit(int[] prices)
        {
            return DynamicProgram1(prices);
        }

        private static int DynamicProgram1(int[] prices)
        {
            if (prices.Length == 0) return 0;

            int[,] arr = new int[prices.Length, 2];

            arr[0, 0] = 0;
            arr[0, 1] = -prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int temp = prices[i];

                for (int j = 0; j < 2; j++)
                {
                    arr[i, 0] = arr[i - 1, 0];
                    arr[i, 1] = arr[i - 1, 1];
                }

                if (arr[i, 0] - temp > arr[i, 1])
                    arr[i, 1] = arr[i, 0] - temp;

                if (arr[i, 1] + temp > arr[i, 0])
                    arr[i, 0] = arr[i, 1] + temp;
            }

            return arr[prices.Length - 1, 0] > arr[prices.Length - 1, 1] ?
                arr[prices.Length - 1, 0] :
                arr[prices.Length - 1, 1];
        }

        private int DeepthFirstSearch(int[] prices, int index, bool hasStock, int total, int max)
        {
            if (index > prices.Length - 1) return max;

            if (hasStock)
            {
                //卖掉
                max = max < total + prices[index] ? total + prices[index] : max;
                max = DeepthFirstSearch(prices, index + 1, false, total + prices[index], max);
            }
            else
                //买进
                max = DeepthFirstSearch(prices, index + 1, true, total - prices[index], max);

            //无操作
            max = DeepthFirstSearch(prices, index + 1, hasStock, total, max);

            return max;
        }

        private static int Way1(int[] prices)
        {
            int maxReturn = 0;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i] < prices[i + 1])
                    maxReturn += prices[i + 1] - prices[i];
            }

            return maxReturn;
        }
    }
}
