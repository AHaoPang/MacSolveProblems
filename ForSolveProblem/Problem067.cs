using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem067 : IProblem
    {
        public void RunProblem()
        {
            var temp = AddBinary("11", "1");
            if (temp != "100") throw new Exception();

            temp = AddBinary("1010", "1011");
            if (temp != "10101") throw new Exception();
        }

        public string AddBinary(string a, string b)
        {
            /*
             * 用字符串表示的二进制，求和
             * 思路：
             *  1.二进制求和 与 十进制求和 思路一致，即按照从低位到高位的顺序依次相加，需要进位的时候进位即可
             * 
             * 关键点：
             *  1.两个指针各自倒序遍历自己的字符串
             *  2.每个位的值相加，若大于1，则需要向上进位
             *  
             * 时间复杂度：O(max(m,n))
             * 空间复杂度：除了要输出的结果外，其实我使用的额外空间是固定大小的
             */

            int aIndex = a.Length - 1;
            int bIndex = b.Length - 1;

            StringBuilder forReturnBuilder = new StringBuilder();
            int increasePos = 0;
            while (aIndex >= 0 || bIndex >= 0)
            {
                var aChar = 0;
                if (aIndex >= 0 && a[aIndex] == '1') aChar = 1;

                var bChar = 0;
                if (bIndex >= 0 && b[bIndex] == '1') bChar = 1;

                var sumTemp = increasePos + aChar + bChar;

                increasePos = sumTemp / 2;
                forReturnBuilder.Append((sumTemp % 2).ToString());

                aIndex--;
                bIndex--;
            }

            if (increasePos == 1) forReturnBuilder.Append("1");

            return new string(forReturnBuilder.ToString().Reverse().ToArray());
        }

        public string AddBinary2(string a, string b)
        {
            /*
             * 用字符串表示的二进制，求和
             * 思路：
             *  1.二进制求和 与 十进制求和 思路一致，即按照从低位到高位的顺序依次相加，需要进位的时候进位即可
             * 
             * 关键点：
             *  1.两个指针各自倒序遍历自己的字符串
             *  2.每个位的值相加，若大于1，则需要向上进位
             *  
             * 时间复杂度：O(max(m,n))
             * 空间复杂度：除了要输出的结果外，其实我使用的额外空间是固定大小的
             */

            int aIndex = a.Length - 1;
            int bIndex = b.Length - 1;

            StringBuilder forReturnBuilder = new StringBuilder();
            char increasePos = '0';
            while (aIndex >= 0 || bIndex >= 0)
            {
                var aChar = '0';
                if (aIndex >= 0) aChar = a[aIndex];

                var bChar = '0';
                if (bIndex >= 0) bChar = b[bIndex];

                if (increasePos == '0')
                {
                    if (aChar == '1' && bChar == '1')
                    {
                        forReturnBuilder.Append('0');
                        increasePos = '1';
                    }
                    else if (aChar == '1' || bChar == '1')
                        forReturnBuilder.Append('1');
                    else
                        forReturnBuilder.Append('0');
                }
                else
                {
                    if (aChar == '1' && bChar == '1')
                        forReturnBuilder.Append('1');
                    else if (aChar == '1' || bChar == '1')
                        forReturnBuilder.Append('0');
                    else
                    {
                        forReturnBuilder.Append('1');
                        increasePos = '0';
                    }
                }

                aIndex--;
                bIndex--;
            }

            if (increasePos == '1')
                forReturnBuilder.Append('1');

            return new string(forReturnBuilder.ToString().Reverse().ToArray());
        }
    }
}
