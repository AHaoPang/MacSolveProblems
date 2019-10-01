using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem066 : IProblem
    {
        public void RunProblem()
        {
            var digits = new int[] { 1, 2, 3 };

            var temp = PlusOne(digits);

            digits = new int[] { 9, 9, 9 };
            temp = PlusOne(digits);
        }

        public int[] PlusOne(int[] digits)
        {
            /*
             * 为使用数组表示的整数加1
             * 思路：
             *  1.做正常的加1就好了，每一位，满10进1好了
             *  2.如果最高位需要进1，那就插入元素好了
             *  
             * 时间复杂度：O(n)，大部分情况，只要遍历一次数据就可以了，在临界情况才会需要进位，那么就再遍历一次好了，所以依然是线性复杂度
             * 空间复杂度：O(1)
             */
            int arrayLength = digits.Length;

            digits[arrayLength - 1] += 1;

            int carryOver = 0;
            for (int i = arrayLength - 1; i >= 0; i--)
            {
                digits[i] += carryOver;

                carryOver = digits[i] / 10;
                digits[i] %= 10;

                if (carryOver == 0) break;
            }

            if (carryOver != 0)
            {
                var listTemp = new List<int>(digits);
                listTemp.Insert(0, 1);

                return listTemp.ToArray();
            }

            return digits;
        }
    }
}
