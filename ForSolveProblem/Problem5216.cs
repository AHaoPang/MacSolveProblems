using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5216 : IProblem
    {
        public int CountVowelPermutation(int n)
        {
            /*
             * 题目概述：统计按照指定规则生成的指定长度的字符串的种类数
             * 
             * 思路：
             *  1. 这是一个不断递推变大的过程，变大的过程中，要注意取余控制增长规模
             *  2. 分别使用两个数组表示表示 n 个长度时的情况，以及 n-1 个长度时的情况
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var maxConst = unchecked((int)(1E9 + 7));
            var arrayPre = Enumerable.Repeat(1, 5).ToArray();
            var arrayCur = new int[5];

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < 5; j++) arrayCur[j] = 0;

                arrayCur[0] = (arrayPre[1] + arrayPre[2]) % maxConst;
                arrayCur[0] += arrayPre[4];//a

                arrayCur[1] = arrayPre[0] + arrayPre[2];//e
                arrayCur[2] = arrayPre[1] + arrayPre[3];//i
                arrayCur[3] = arrayPre[2];//o
                arrayCur[4] = arrayPre[2] + arrayPre[3];//u

                for (int j = 0; j < 5; j++) arrayPre[j] = arrayCur[j] % maxConst;
            }

            var forReturn = 0;
            for (int i = 0; i < arrayPre.Length; i++)
            {
                forReturn += arrayPre[i];
                forReturn %= maxConst;
            }

            return forReturn;
        }

        public void RunProblem()
        {
            var temp = CountVowelPermutation(1);
            if (temp != 5) throw new Exception();

            temp = CountVowelPermutation(2);
            if (temp != 10) throw new Exception();

            temp = CountVowelPermutation(158);
            if (temp != 237753473) throw new Exception();


        }
    }
}
