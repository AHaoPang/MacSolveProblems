using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem223 : IProblem
    {
        public void RunProblem()
        {
            var temp = ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2);
            if (temp != 45) throw new Exception();
        }

        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            /*
             * 计算二维平面上，两个矩形的总面积，两个矩形有可能重叠
             * 思路：
             *  1.由对角线的两个点，可以确定矩形的边长，进而得到面积
             *  2.重叠的矩形，其实可以看做是，两个矩形长和宽的相交线段
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            var area1 = GetOneArea(A, B, C, D);
            var area2 = GetOneArea(E, F, G, H);

            var interChang = GetInterSectLength(A, C, E, G);
            var interKuan = GetInterSectLength(B, D, F, H);

            return area1 + area2 - interChang * interKuan;
        }

        /// <summary>
        /// 用于计算一个矩形的面积
        /// </summary>
        private int GetOneArea(int a, int b, int c, int d) => Math.Abs(c - a) * Math.Abs(d - b);

        /// <summary>
        /// 用户计算线段相交部分的长度
        /// </summary>
        private int GetInterSectLength(int a, int c, int e, int g)
        {
            var leftRight1 = GetLeftRight(a, c);
            var leftRight2 = GetLeftRight(e, g);

            if (leftRight1.Item1 <= leftRight2.Item2 && leftRight1.Item2 >= leftRight2.Item1)
            {
                int leftResult = leftRight1.Item1 > leftRight2.Item1 ? leftRight1.Item1 : leftRight2.Item1;
                int rightResult = leftRight1.Item2 < leftRight2.Item2 ? leftRight1.Item2 : leftRight2.Item2;

                return Math.Abs(leftResult - rightResult);
            }

            return 0;
        }

        /// <summary>
        /// 返回线段的小端和大端
        /// </summary>
        private (int, int) GetLeftRight(int a, int c) => a < c ? (a, c) : (c, a);
    }
}
