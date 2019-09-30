using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem405 : IProblem
    {
        public void RunProblem()
        {
            var temp = ToHex(26);

            temp = ToHex(-1);
        }

        public string ToHex(int num)
        {
            /*
             * 将十进制数字转换为十六进制数字
             * 思路：
             *  1.对于一个32二进制位的整数，转换成十六进制数，最多只会有8个位
             *  2.每4个位取一次，把结果翻译成十六进制数即可
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            string charArr = "0123456789abcdef";

            StringBuilder forReturn = new StringBuilder();
            int countTemp = 0;
            while(num != 0 && countTemp < 8)
            {
                forReturn.Insert(0, charArr[num & 0xf]);
                num = num >> 4;
                countTemp++;
            }

            var forReturnStr = forReturn.ToString().TrimStart('0');

            return forReturnStr == "" ? "0" : forReturnStr;
        }
    }
}
