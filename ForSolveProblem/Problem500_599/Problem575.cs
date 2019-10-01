using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem575 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int DistributeCandies(int[] candies)
        {
            /*
             * 分糖果
             * 思路：
             *  1.数组一定是偶数个，为的就是弟弟妹妹可以平分
             *  2.然而妹妹期望拿到最多的糖果种类数
             *  3.因此结论比较简单了：
             *      3.1 糖果总数的一半，是妹妹可以拿到的糖果数量，也可以看做是妹妹可得最大“糖果种类”的上限
             *      3.2 糖果一共有多少种，是“糖果种类”的实际值
             *      3.3 糖果种类的实际值 VS 糖果种类的上限，取二者中的较小者
             *      
             * 时间复杂度：O(n) 所有糖果都是要遍历一遍的
             * 空间复杂度：O(n) 存储不同类型的糖果
             */

            var candyTypeSet = new HashSet<int>(candies);
            return Math.Min(candies.Length / 2, candyTypeSet.Count);
        }
    }
}
