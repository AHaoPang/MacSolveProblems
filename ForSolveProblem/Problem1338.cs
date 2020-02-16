using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1338 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinSetSize(int[] arr)
        {
            /*
             * 题目概述：数组大小减半
             * 
             * 思路：
             *  1.把问题抽象为 种群,灭绝最少的物种,就可以让种群总量减半
             *  2.首先要做一轮统计,摸清各个物种的数量
             *  3.然后贪婪的从数量最多的物种开始灭绝,那么什么时候到达种群的一半时,就可暂停了
             *  4.此时已然灭绝物种的数量,就是结果了
             *
             * 关键点：
             *
             * 时间复杂度：O(nlogn)
             * 空间复杂度：O(n) 
             */

            var numCountDic = new Dictionary<int, int>();
            foreach (var arrItem in arr)
            {
                if (!numCountDic.ContainsKey(arrItem))
                    numCountDic[arrItem] = 0;

                numCountDic[arrItem]++;
            }

            var forReturn = 0;
            var orderDic = numCountDic.OrderByDescending(i => i.Value).ToList();
            var delCount = 0;
            while (delCount < arr.Length / 2)
                delCount += orderDic[forReturn++].Value;

            return forReturn;
        }
    }
}
