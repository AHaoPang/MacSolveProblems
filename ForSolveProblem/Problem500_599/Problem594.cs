using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem594 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindLHS(new int[] { 1, 3, 2, 2, 5, 2, 3, 7 });
            if (temp != 5) throw new Exception();
        }

        public int FindLHS(int[] nums)
        {
            /*
             * 在给定的数组里面，找到可以构成最长和谐的序列
             * 思路：
             *  1.和谐序列，要求最大最小差为1
             *  2.如果把给定数组中的数字种类和个数做统计，那么和谐就意味着“相邻”种类的最大值
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var numTypeCountDic = new Dictionary<int, int>();
            foreach (var numItem in nums)
            {
                if (!numTypeCountDic.ContainsKey(numItem)) numTypeCountDic[numItem] = 0;
                numTypeCountDic[numItem]++;
            }

            var forReturn = 0;
            foreach (var dicItem in numTypeCountDic)
            {
                var anotherKey = dicItem.Key - 1;

                if (!numTypeCountDic.ContainsKey(anotherKey)) continue;

                forReturn = Math.Max(forReturn, dicItem.Value + numTypeCountDic[anotherKey]);
            }

            return forReturn;
        }
    }
}
