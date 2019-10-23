using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem528 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 实现原则
        /// 1. 将权重摊平了,即做累计和,权重越大面积就会越大
        /// 2. 将整个面积摆在随机数面前供其选择
        /// 3. 使用二分法判断选择的单个部分属于哪个索引
        /// </summary>
        public class Solution
        {
            /// <summary>
            /// 存储权重累计和
            /// </summary>
            private int[] m_sumArray;

            /// <summary>
            /// 随机数选择
            /// </summary>
            private Random m_r;

            public Solution(int[] w)
            {
                m_r = new Random();
                m_sumArray = new int[w.Length];

                m_sumArray[0] = w[0];
                for (int i = 1; i < w.Length; i++)
                    m_sumArray[i] = m_sumArray[i - 1] + w[i];
            }

            public int PickIndex()
            {
                var randomNum = m_r.Next(0, m_sumArray.Last()) + 1;

                var leftIndex = 0;
                var rightIndex = m_sumArray.Length - 1;
                while (leftIndex < rightIndex)
                {
                    var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                    if (m_sumArray[middleIndex] == randomNum) return middleIndex;

                    if (m_sumArray[middleIndex] < randomNum) leftIndex = middleIndex + 1;
                    else rightIndex = middleIndex;
                }

                return leftIndex;
            }
        }
    }
}
