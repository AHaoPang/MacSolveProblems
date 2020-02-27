using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1137 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        private IDictionary<int, int> m_innerDic;

        public int Tribonacci(int n)
        {
            if (m_innerDic == null)
                m_innerDic = new Dictionary<int, int>(n);

            if (m_innerDic.ContainsKey(n))
                return m_innerDic[n];

            var forReturn = 0;
            try
            {
                if (n == 0)
                {
                    forReturn = n;
                    return forReturn;
                }

                if (n == 1 || n == 2)
                {
                    forReturn = 1;
                    return forReturn;
                }

                forReturn = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
                return forReturn;
            }
            finally
            {
                m_innerDic[n] = forReturn;
            }
        }

        public int Tribonacci2(int n)
        {
            /*
             * 题目概述：按照规则生成第 N 个数字
             * 
             * 思路：
             *  1.数字序列的生成是有规律的
             *  2.当前数字,是前 3 个数字的和
             *  3.基于此规律,如果有 3 个初始的数字,其余数字则可依次计算得到
             *  4.题目给出的最开始的 3 个数字:0 1 1
             *  5.基于掌握的值,依次计算出期望的值,这种自底向上的计算方式,也是动态规划思维的展现
             *  6.也可以基于递归的方式来思考
             *      6.1 递归的思维是一个自上而下的方式,是一种刨根问底解决问题的方式
             *      6.2 也即,对规则的实现,当前数,前 3 个数字知道了,就自然知道了
             *
             * 关键点：
             *
             * 时间复杂度： O(n) --> 依次去计算每一个数字
             * 空间复杂度： O(n) --> 每个数字都存储了起来,其实也可以不存的
             */

            var numArray = new int[3];

            for (var i = 0; i <= n; i++)
            {
                switch (i)
                {
                    case 0:
                        numArray[i] = 0;
                        break;

                    case 1:
                    case 2:
                        numArray[i] = 1;
                        break;

                    default:
                        var temp = numArray[0] + numArray[1] + numArray[2];
                        numArray[0] = numArray[1];
                        numArray[1] = numArray[2];
                        numArray[2] = temp;
                        break;
                }
            }

            return n < 2 ? numArray[n] : numArray[2];
        }

        public int Tribonacci1(int n)
        {
            /*
             * 题目概述：按照规则生成第 N 个数字
             * 
             * 思路：
             *  1.数字序列的生成是有规律的
             *  2.当前数字,是前 3 个数字的和
             *  3.基于此规律,如果有 3 个初始的数字,其余数字则可依次计算得到
             *  4.题目给出的最开始的 3 个数字:0 1 1
             *  5.基于掌握的值,依次计算出期望的值,这种自底向上的计算方式,也是动态规划思维的展现
             *  6.也可以基于递归的方式来思考
             *      6.1 递归的思维是一个自上而下的方式,是一种刨根问底解决问题的方式
             *      6.2 也即,对规则的实现,当前数,前 3 个数字知道了,就自然知道了
             *
             * 关键点：
             *
             * 时间复杂度： O(n) --> 依次去计算每一个数字
             * 空间复杂度： O(n) --> 每个数字都存储了起来,其实也可以不存的
             */

            var numArray = new int[n + 1];

            for (var i = 0; i < numArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        numArray[i] = 0;
                        break;

                    case 1:
                    case 2:
                        numArray[i] = 1;
                        break;

                    default:
                        numArray[i] = numArray[i - 1] + numArray[i - 2] + numArray[i - 3];
                        break;
                }
            }

            return numArray[n];
        }
    }
}
