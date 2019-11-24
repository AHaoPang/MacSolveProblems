using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    class Problem5271 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinTimeToVisitAllPoints(new int[][]
            {
                new int[]{1,1},
                new int[]{3,4},
                new int[]{-1,0},
            });
            if (temp != 7) throw new Exception();

            temp = MinTimeToVisitAllPoints(new int[][]
            {
                new int[]{3,2},
                new int[]{-2,2},
            });
            if (temp != 5) throw new Exception();
        }

        public int MinTimeToVisitAllPoints(int[][] points)
        {
            /*
             * 题目概述：将所有点遍历一遍,所需的时间是多少
             * 
             * 思路：
             *  1.主要还是在找规律了
             *  2.从 1 个点到另 1 个点,可以水平 垂直 斜向移动,每个移动耗时 1 秒
             *  3.其实就是一个点与另一个点,水平位置和垂直位置,谁的边长,就是多少的耗时了
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var forReturn = 0;

            for (int i = 0; i < points.Length - 1; i++)
                forReturn += GetTwoPointTime(points[i], points[i + 1]);

            return forReturn;
        }

        private int GetTwoPointTime(int[] point1, int[] point2) => Math.Max(Math.Abs(point1[0] - point2[0]), Math.Abs(point1[1] - point2[1]));
    }
}
