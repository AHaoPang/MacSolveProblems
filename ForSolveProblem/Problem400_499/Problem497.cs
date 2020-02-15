using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem497 : IProblem
    {
        /// <summary>
        /// 实现思路:
        /// 1. 随机的话,所有矩形中的点,被选中的概率应该是一样的
        /// 2. 总点数最大是: 2000*2000*100,再整数的表示范围内
        /// 3. 用随机函数从这么多点中随机选择一个
        /// 4. 确认是来自于那个矩形中的点
        /// 5. 再去这个矩形的范围内,随机X和Y即可
        /// </summary>
        public class Solution
        {
            /// <summary>
            /// 按照矩形索引来汇总大小之和
            /// </summary>
            private int[] m_InnerTotalSizeArray;

            /// <summary>
            /// 随机数生成
            /// </summary>
            private Random m_R;

            /// <summary>
            /// 内部存储的矩形数组
            /// </summary>
            private int[][] m_Rects;

            public Solution(int[][] rects)
            {
                m_Rects = rects;
                m_R = new Random();
                m_InnerTotalSizeArray = new int[rects.Length];

                for (int i = 0; i < rects.Length; i++)
                {
                    var curRectTemp = rects[i];
                    var sizeTemp = (curRectTemp[2] - curRectTemp[0] + 1) * (curRectTemp[3] - curRectTemp[1] + 1);
                    if (i == 0) m_InnerTotalSizeArray[i] = sizeTemp;
                    else m_InnerTotalSizeArray[i] = m_InnerTotalSizeArray[i - 1] + sizeTemp;
                }
            }

            public int[] Pick()
            {
                //随机选择一个数字
                var maxTemp = m_InnerTotalSizeArray.Last();
                var randomNum = m_R.Next(0, maxTemp) + 1;

                //判断是在哪个矩形里面
                var leftIndex = 0;
                var rightIndex = m_InnerTotalSizeArray.Length - 1;
                while (leftIndex < rightIndex)
                {
                    var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                    if (m_InnerTotalSizeArray[middleIndex] == randomNum)
                    {
                        leftIndex = middleIndex;
                        break;
                    }
                    else if (m_InnerTotalSizeArray[middleIndex] < randomNum)
                        leftIndex = middleIndex + 1;
                    else
                        rightIndex = middleIndex - 1;
                }

                var curRect = m_Rects[leftIndex];
                //再随机行和列的坐标
                var randomX = m_R.Next(curRect[0] - 1, curRect[2]);
                var randomY = m_R.Next(curRect[1] - 1, curRect[3]);

                return new int[] { randomX + 1, randomY + 1 };
            }
        }

        public void RunProblem()
        {
            var s = new Solution(new int[][] { new int[] { 1, 1, 5, 5 } });
            var t = s.Pick();

            var temp = new int[][]
            {
                new int[]{82918473, -57180867, 82918476, -57180863 },
                new int[]{83793579, 18088559, 83793580, 18088560},
                new int[]{66574245, 26243152, 66574246, 26243153},
                new int[] { 72983930, 11921716, 72983934, 11921720 }
            };
            s = new Solution(temp);

            int i = 0;
            for (; i < 100000; i++)
            {
                t = s.Pick();
                if (!IsRight(temp, t))
                    break;
            }


        }

        private bool IsRight(int[][] rects, int[] point)
        {
            foreach (var rectItem in rects)
                if (rectItem[0] <= point[0] && point[0] <= rectItem[2] && rectItem[1] <= point[1] && point[1] <= rectItem[3]) return true;

            return false;
        }
    }
}
