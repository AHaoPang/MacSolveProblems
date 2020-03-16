using System;
using System.Collections.Generic;
using System.Linq;
namespace ForSolveProblem
{
    public class Problem5359 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxPerformance(6, new int[] { 2, 10, 3, 1, 5, 8 }, new int[] { 5, 4, 3, 9, 7, 2 }, 2);
            if (temp != 60) throw new Exception();

            temp = MaxPerformance(6, new int[] { 2, 10, 3, 1, 5, 8 }, new int[] { 5, 4, 3, 9, 7, 2 }, 3);
            if (temp != 68) throw new Exception();

            temp = MaxPerformance(6, new int[] { 2, 10, 3, 1, 5, 8 }, new int[] { 5, 4, 3, 9, 7, 2 }, 4);
            if (temp != 72) throw new Exception();

            temp = MaxPerformance(3, new int[] { 2, 8, 2 }, new int[] { 2, 7, 1 }, 2);
            if (temp != 56) throw new Exception();
        }

        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            var constNum = (int)1e9 + 7;

            var list = new List<KeyValuePair<long, long>>(n);
            for (var i = 0; i < n; i++)
                list.Add(new KeyValuePair<long, long>(efficiency[i], speed[i]));

            var orderList = list.OrderByDescending(i => i.Key);

            var forReturn = 0L;
            var pQ = new PriorityQueue<long>(false, k);
            var sumTemp = 0L;
            foreach (var orderItem in orderList)
            {
                if (pQ.Count == k)
                {
                    if (orderItem.Value > pQ.PeekData())
                    {
                        sumTemp -= pQ.GetData();
                        sumTemp += orderItem.Value;
                        pQ.AddData(orderItem.Value);

                        forReturn = Math.Max(forReturn, orderItem.Key * sumTemp);
                    }
                }
                else
                {
                    sumTemp += orderItem.Value;
                    pQ.AddData(orderItem.Value);

                    forReturn = Math.Max(forReturn, orderItem.Key * sumTemp);
                }
            }

            return (int)(forReturn % constNum);
        }

        public int MaxPerformance1(int n, int[] speed, int[] efficiency, int k)
        {
            var constNum = (int)1e9 + 7;

            var dp = new Dictionary<long, long>[n + 1][];
            dp[0] = new Dictionary<long, long>[1];

            for (var i = 1; i <= n; i++)
            {
                var curEff = efficiency[i - 1];
                var curSpe = speed[i - 1];

                var minValue = Math.Min(i, k);
                dp[i] = new Dictionary<long, long>[minValue + 1];
                for (var j = 1; j <= minValue; j++)
                {
                    var newDic = new Dictionary<long, long>();
                    if (j == 1)
                        newDic[curEff] = curSpe;

                    //不参与
                    if (j <= i - 1)
                    {
                        foreach (var dicItem in dp[i - 1][j])
                            newDic[dicItem.Key] = dicItem.Value;
                    }

                    //参与
                    if (dp[i - 1][j - 1] != null)
                    {
                        foreach (var item in dp[i - 1][j - 1])
                        {
                            if (item.Key <= curEff)
                            {
                                if (!newDic.ContainsKey(item.Key))
                                    newDic[item.Key] = item.Value + curSpe;
                                else
                                    newDic[item.Key] = Math.Max(newDic[item.Key], item.Value + curSpe);
                            }
                            else
                            {
                                if (!newDic.ContainsKey(curEff))
                                    newDic[curEff] = curSpe;

                                if (newDic[curEff] < item.Value + curSpe)
                                    newDic[curEff] = item.Value + curSpe;
                            }
                        }
                    }

                    if (newDic.Any())
                        dp[i][j] = newDic;
                }
            }

            var list = dp[n][k];
            var maxNum = 0L;
            for (var i = 1; i <= k; i++)
                maxNum = Math.Max(maxNum, dp[n][i].Max(i => i.Key * i.Value));

            return (int)(maxNum % constNum);
        }
    }
}
