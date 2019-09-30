using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem171 : IProblem
    {
        public void RunProblem()
        {
            var temp = TitleToNumber("A");
            if (temp != 1) throw new Exception();

            temp = TitleToNumber("AB");
            if (temp != 28) throw new Exception();

            temp = TitleToNumber("ZY");
            if (temp != 701) throw new Exception();
        }

        public int TitleToNumber(string s)
        {
            /*
             * 将26进制的数字，转换成10进制数字
             * 思路：
             *  1. 就十进制而言，每个位的权重之和，就是数字本身
             *  2. 同理对于十六进制，每个位置的权重，都是26的次方
             *  
             * 时间复杂度：O(n)，遍历一下字符串的过程
             * 空间复杂度：O(1)，没有使用额外的可变存储空间
             */

            int forReturn = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var curVal = s[i] - 'A' + 1;
                forReturn = forReturn * 26 + curVal;
            }

            return forReturn;
        }
    }
}
