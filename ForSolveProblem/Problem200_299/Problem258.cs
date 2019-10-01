using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem258 : IProblem
    {
        public void RunProblem()
        {
            var temp = AddDigits(38);
            if (temp != 2) throw new Exception();

            temp = AddDigits(888);
            if (temp != 6) throw new Exception();

            temp = AddDigits(19);
            if (temp != 1) throw new Exception();
        }

        public int AddDigits(int num)
        {
            /*
             * 使用特殊的规则来累加数字
             * 思路：
             *  1.依据规则，这个相当于一种特殊的进位方式了
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            //得到位的数组
            var posList = new List<int>();
            while (num > 0)
            {
                posList.Add(num % 10);
                num /= 10;
            }

            //依次合并位
            var forReturn = 0;
            foreach (var posItem in posList)
            {
                forReturn += posItem;
                if (forReturn >= 10) forReturn = forReturn % 10 + 1;
            }

            return forReturn;
        }
    }
}
