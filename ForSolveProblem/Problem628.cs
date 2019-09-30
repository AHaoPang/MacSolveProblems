using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem628 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaximumProduct(new int[] { 1, 2, 3 });
            if (temp != 6) throw new Exception();

            temp = MaximumProduct(new int[] { 1, 2, 3, 4 });
            if (temp != 24) throw new Exception();
        }

        public int MaximumProduct(int[] nums)
        {
            /*
             * 寻找数组中，乘积最大的3个数字
             * 思路：
             *  1. 数组中的数字，可以有正数，也可以有负数，那就分析一下好了
             *  2. 全部是正数，那么就拿3个最大的正数乘积就好了
             *  3. 2个正数，其它是负数，那么就拿1个正数，以及最小的两个数好了
             *  4. 1个正数，其它是负数，那么就拿1个正数，以及最小的两个数好了
             *  5. 全是负数，那么就拿3个最大的负数乘积就好了
             *  6. 归纳以上的4种情况，可得结论，最大的数，一定在这两种情况之中
             *      6.1 3个最大的数字的乘积
             *      6.2 1个最大的数，2个最小的数的乘积
             *      
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var maxThreeArray = Enumerable.Repeat(int.MinValue, 3).ToList();
            var minTwoArray = Enumerable.Repeat(int.MaxValue, 2).ToList();

            foreach (var numItem in nums)
            {
                if (numItem > maxThreeArray.Last())
                {
                    for (int i = 0; i < maxThreeArray.Count; i++)
                    {
                        if (numItem > maxThreeArray[i])
                        {
                            maxThreeArray.Insert(i, numItem);
                            maxThreeArray.RemoveAt(maxThreeArray.Count - 1);
                            break;
                        }
                    }
                }

                if (numItem < minTwoArray.Last())
                {
                    for (int i = 0; i < minTwoArray.Count; i++)
                    {
                        if (numItem < minTwoArray[i])
                        {
                            minTwoArray.Insert(i, numItem);
                            minTwoArray.RemoveAt(minTwoArray.Count - 1);
                            break;
                        }
                    }
                }
            }

            return Math.Max(maxThreeArray[0] * maxThreeArray[1] * maxThreeArray[2], maxThreeArray[0] * minTwoArray[0] * minTwoArray[1]);
        }
    }
}
