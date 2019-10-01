using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem507 : IProblem
    {
        public void RunProblem()
        {
            var temp = CheckPerfectNumber(28);
            if (temp != true) throw new Exception();

            temp = CheckPerfectNumber(6);
            if (temp != true) throw new Exception();
        }

        public bool CheckPerfectNumber(int num)
        {
            /*
             * 检测当前数字是否是“完美数”
             * 思路：
             *  1.依据完美数的定义，只需要依次遍历2~开根号num范围内的数字即可
             *  2.对于1要特殊处理，依据定义，它不能成为完美数
             *  
             * 时间复杂度：O(根号 num)
             * 空间复杂度：O(1)
             */

            if (num == 1) return false;

            var maxNum = Math.Sqrt(num);
            var sumTemp = 1;
            var i = 2;
            for (; i < maxNum; i++)
            {
                if (num % i != 0) continue;

                sumTemp += i + num / i;

                if (sumTemp > num) return false;
            }

            if (i * i == num) sumTemp += i;

            return sumTemp == num;
        }
    }
}
