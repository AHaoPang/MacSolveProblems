using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem470 : IProblem
    {
        public void RunProblem()
        {
            var s = new Solution();

            s.Rand10();
        }

        public class Solution : SolBase
        {
            public int Rand10()
            {
                /*
                 * 问题:将随机生成的7个数字,适配为随机生成的10个数字
                 * 思路:
                 *  1.第1次使用Random7()得到1~7,第二次使用Random7()得到1~7
                 *  2.两次调用的排列组合一共有49种情况
                 *  3.将前40种情况,均匀的分在10个桶里面,其余9种情况丢弃
                 *  4.10个桶分别表示1~10
                 *  
                 *  5.看题解大致有两种思路:
                 *      5.1 考虑49种情况,将40种情况映射为10种数字,其余9个丢弃,成功生成的概率是 40/49
                 *      5.2 先用随机数决定是1~5还是6~10,然后再去确定是具体哪个数字
                 *          5.2.1 第一轮丢弃概率是 1/7
                 *          5.2.2 第二轮丢弃概率是 2/7
                 *          5.2.3 总的丢弃概率是 1/7 + 6/7 * 2/7 = 19/49,成功生成的概率是 30/49
                 *      5.3 从成功生成的概率来看,前一种方法要好一些
                 * 
                 * 关键点:
                 * 
                 * 时间复杂度:O(1)
                 * 空间复杂度:O(1)
                 */

                var forReturn = -1;

                while (forReturn == -1)
                    forReturn = m_innerArray[Rand7(), Rand7()];

                return forReturn;
            }

            private int[,] m_innerArray;

            public Solution()
            {
                m_innerArray = new int[8, 8];

                var initNum = 0;
                for (int i = 1; i <= 7; i++)
                {
                    for (int j = 1; j <= 7; j++)
                    {
                        if (initNum > 39)
                            m_innerArray[i, j] = -1;
                        else
                            m_innerArray[i, j] = initNum / 4 + 1;

                        initNum++;
                    }
                }
            }
        }

        public class SolBase
        {
            private static Random r = new Random();

            public int Rand7() => r.Next(1, 8);
        }
    }


}
