using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem787 : IProblem
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            /*
             * 题目概述：n 个城市 m 个航班 k 次中转从一座城市到达另一座城市,最便宜的价格是多少
             * 
             * 思路：
             *  1. 定义状态:dp[i][n] 表示第K 次中转时,目前可达所有城市的最小价格
             *  2. 结果状态:dp[i][dst]
             *  3. 状态转移:dp[i][city] = min(dp[i][cityOthers]+prices) (cityOthers 是到达其他城市以后,再飞到 city 城市的航班)
             *
             * 关键点：
             *
             * 时间复杂度：O(flights) flights 即航班的数量
             * 空间复杂度：O(n)
             */

            //维护从一座城市可以到达哪些城市的字典
            var srcDstsDic = new Dictionary<int, IDictionary<int, int>>();
            for (int i = 0; i < flights.Length; i++)
            {
                var srcTemp = flights[i][0];
                var dstTemp = flights[i][1];
                var pricesTemp = flights[i][2];

                if (!srcDstsDic.ContainsKey(srcTemp)) srcDstsDic[srcTemp] = new Dictionary<int, int>();
                srcDstsDic[srcTemp].Add(dstTemp, pricesTemp);
            }

            //维护多轮换班以后的状态
            var dp = new Dictionary<int, int>();
            dp[src] = 0;

            //维护当前所在城市
            var srcCitysHash = new HashSet<int>();
            srcCitysHash.Add(src);

            var limitK = 0;
            while (limitK <= K)
            {
                limitK++;

                var newHashSet = new HashSet<int>();
                var newDp = dp.ToDictionary(i => i.Key, j => j.Value);
                foreach (var curSrcCity in srcCitysHash)
                {
                    if (!srcDstsDic.ContainsKey(curSrcCity)) continue;

                    var dstsPrices = srcDstsDic[curSrcCity];
                    foreach (var dstPriceItem in dstsPrices)
                    {
                        if (!dp.ContainsKey(dstPriceItem.Key))
                            newDp[dstPriceItem.Key] = dp[curSrcCity] + dstPriceItem.Value;
                        else
                            newDp[dstPriceItem.Key] = Math.Min(newDp[dstPriceItem.Key], dp[curSrcCity] + dstPriceItem.Value);

                        newHashSet.Add(dstPriceItem.Key);
                    }
                }
                dp = newDp;

                srcCitysHash = newHashSet;
            }

            return dp.ContainsKey(dst) ? dp[dst] : -1;
        }

        public void RunProblem()
        {
            var temp = FindCheapestPrice(3, new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 } }, 0, 2, 1);
            if (temp != 200) throw new Exception();

            temp = FindCheapestPrice(3, new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 } }, 0, 2, 0);
            if (temp != 500) throw new Exception();

            temp = FindCheapestPrice(4, new int[][]
            {
                new int[]{0,1,1},
                new int[]{0,2,5},
                new int[]{1,2,1},
                new int[]{2,3,1},
            }, 0, 3, 1);
            if (temp != 6) throw new Exception();

            temp = FindCheapestPrice(5, new int[][]
            {
                new int[]{0,1,5},
                new int[]{1,2,5},
                new int[]{0,3,2},
                new int[]{3,1,2},
                new int[]{1,4,1},
                new int[]{4,2,1},
            }, 0, 2, 2);
            if (temp != 7) throw new Exception();
        }
    }
}
