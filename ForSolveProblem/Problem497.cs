using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem497 : IProblem
    {
        public class Solution
        {
            private int m_xRangeMin;
            private int m_xRangeMax;
            private int m_yRangeMin;
            private int m_yRangeMax;

            private Random m_r;
            private int[][] m_rects;

            public Solution(int[][] rects)
            {
                /*
                 * 大致思路是,分析矩形的可能性,然后去随机的尽量准
                 * 1. 确定 x 和 y的取值范围
                 * 2. 随机得到x和y,判断是否在矩形范围内
                 */
                m_r = new Random();
                m_rects = rects;

                m_xRangeMin = int.MaxValue;
                m_xRangeMax = int.MinValue;
                m_yRangeMin = int.MaxValue;
                m_yRangeMax = int.MinValue;
                foreach (var rectItem in rects)
                {
                    m_xRangeMin = Math.Min(rectItem[0], m_xRangeMin);
                    m_xRangeMax = Math.Max(rectItem[2], m_xRangeMax);
                    m_yRangeMin = Math.Min(rectItem[1], m_yRangeMin);
                    m_yRangeMax = Math.Max(rectItem[3], m_yRangeMax);
                }
            }

            private bool IsBeloneRects(int x, int y)
            {
                foreach (var rectItem in m_rects)
                    if (rectItem[0] <= x && x <= rectItem[2] && rectItem[1] <= y && y <= rectItem[3]) return true;

                return false;
            }

            public int[] Pick()
            {
                while (true)
                {
                    int rx = m_r.Next(m_xRangeMin, m_xRangeMax + 1);
                    int ry = m_r.Next(m_yRangeMin, m_yRangeMax + 1);

                    if (IsBeloneRects(rx, ry)) return new int[] { rx, ry };
                }
            }
        }

        public void RunProblem()
        {
            var s = new Solution(new int[][] { new int[] { 1, 1, 5, 5 } });
            var t = s.Pick();
        }
    }
}
