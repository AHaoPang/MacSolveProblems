using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem260 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] SingleNumber(int[] nums)
        {
            /*
             * 数组中，有两个只出现了一次的数字，其余都出现了两次，找到这俩数字
             * 思路：
             *  1.若数组中，只有一个只出现了一次的数组，那么直接异或就好了
             *  2.那现在出现了两次，异或的结果是两个数的异或结果
             *  3.若能把数组分开，两个只出现一次的数字也能分开，那么问题就好解决了
             *  4.异或，本身表示的是“区别”
             *  5.基于上面的分析，可以依据区别来将数字分组，那么此种方式就一定能将两个数字分开
             *  
             * 时间复杂度：O(n)，对数字的有限遍历次数
             * 空间复杂度：O(1)，使用的额外空间稳定
             */

            //推导：依据题目的描述，数组的元素数量一定是大于2的

            //异或得到结果
            int r1 = 0;
            foreach (var numItem in nums)
                r1 ^= numItem;

            //得到要分组的位
            int p1 = 1;
            int sumTemp = p1 & r1;
            while (sumTemp != p1)
            {
                p1 = p1 << 1;
                sumTemp = p1 & r1;
            }

            //分组
            int forReturnNum1 = 0;
            int forReturnNum2 = 0;
            foreach (var numItem in nums)
            {
                if ((numItem & p1) == 0)
                    forReturnNum1 ^= numItem;
                else
                    forReturnNum2 ^= numItem;
            }

            //分别异或，得到结果值
            return new int[] { forReturnNum1, forReturnNum2 };
        }
    }
}
