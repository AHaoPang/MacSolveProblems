using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem357 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountNumbersWithUniqueDigits(2);
            if (temp != 91) throw new Exception();

            temp = CountNumbersWithUniqueDigits(1);
            if (temp != 10) throw new Exception();

            temp = CountNumbersWithUniqueDigits(3);
            if (temp != 739) throw new Exception();
        }

        public int CountNumbersWithUniqueDigits(int n)
        {
            /*
             * 10进制数，10个数字取n个的排列组合问题
             * 思路：
             *  1.这是个典型的排列组合问题
             *  2.一共有n个位置
             *  3.第1个位置有10种情况，第2个位置有9种情况，有多个位，然后依次递减
             *  4.从这里也可以看出，受限于数字的上限（10个），n大于10时，不可能存在满足条件的数字，所以结果是0
             *  5.有种最特殊的情况，就是0，可以认为是n个位置都是0，因此这种特例是要加上的
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            if (n > 10) return 0;

            var numArray = new int[n + 1];
            for (int i = 0; i <= n; i++)
                numArray[i] = GetNumthCount(i);

            if (n == 0) return numArray[0];
            else return numArray.Sum();
        }

        private int GetNumthCount(int n)
        {
            var sum = 1;
            var totalType = 9;
            for (int i = 0; i < n; i++)
            {
                if (i == 0) sum *= totalType;
                else sum *= totalType--;
            }

            return sum;
        }
    }
}
