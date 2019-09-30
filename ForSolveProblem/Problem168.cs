using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem168 : IProblem
    {
        public void RunProblem()
        {
            var temp = ConvertToTitle(1);
            if (temp != "A") throw new Exception();

            temp = ConvertToTitle(28);
            if (temp != "AB") throw new Exception();

            temp = ConvertToTitle(701);
            if (temp != "ZY") throw new Exception();
        }

        public string ConvertToTitle(int n)
        {
            /*
             * 将十进制的整数，转换成26进制的数
             * 思路：
             *  1.不断的将整数与26取余，将其挨个转换为26进制的表示
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(logn)
             */

            Stack<char> forReturn = new Stack<char>();

            while(n != 0)
            {
                n--;

                var vChar = n % 26 + 'A';

                forReturn.Push((char)vChar);

                n /= 26;
            }

            return new string(forReturn.ToArray());
        }
    }
}
