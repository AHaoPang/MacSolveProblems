using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem038 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountAndSay(5);
            if (temp != "111221") throw new Exception();

            var temp1 = CountAndSay(10);
            if (temp1 != "13211311123113112211") throw new Exception();

            var temp2 = CountAndSay(1);
            if (temp2 != "1") throw new Exception();
        }

        public string CountAndSay(int n)
        {
            /*
             * 本次使用递归的方法来求解
             * 思路：
             *  1.第n个结果，一定是来源于第n-1个结果的
             *  2.所以是个，先深入底层，再从底层返回的过程
             */

            if (n == 1) return "1";

            var strForN = CountAndSay(n - 1);
            StringBuilder forReturn = new StringBuilder();
            for (int i = 0; i < strForN.Length; i++)
            {
                int countTemp = 1;
                while (i < strForN.Length - 1 && strForN[i] == strForN[i + 1])
                {
                    countTemp++;
                    i++;
                }

                forReturn.Append($"{countTemp}{strForN[i]}");
            }

            return forReturn.ToString();
        }

        public string CountAndSay2(int n)
        {
            /*
             * 一种很有趣的数列~也算是一种规律，即依据规律推理接下来的数
             * 思路：
             *  1.每个序列，都是依据前一个序列得到的，-->因此这可以看做是一个循环
             *  2.序列的规律是：统计 + 数字本身
             *  3.输入的是多少，那么就循环多少次好了
             *  
             * 时间复杂度：O(2^n)，即可以认为每轮循环都会导致长度增加一倍
             * 空间复杂度：O(2^n)
             */

            string firstStr = "1";
            StringBuilder nextStr = new StringBuilder();

            for (int i = 2; i <= n; i++)
            {
                nextStr.Clear();

                for (int j = 0; j < firstStr.Length; j++)
                {
                    int countTemp = 1;
                    while (j < firstStr.Length - 1 && firstStr[j] == firstStr[j + 1])
                    {
                        countTemp++;
                        j++;
                    }

                    nextStr.Append($"{countTemp}{firstStr[j]}");
                }

                firstStr = nextStr.ToString();
            }

            return firstStr;
        }
    }
}
