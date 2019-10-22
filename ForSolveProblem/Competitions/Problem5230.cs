using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5230 : IProblem
    {
        public void RunProblem()
        {
            //var temp = CheckStraightLine(new int[][] 
            //{
            //new int[]{},
            //})
        }

        public bool CheckStraightLine(int[][] coordinates)
        {
            /*
            * 问题:判断给定的点,是否在一条直线上
            * 思路:
            *  1.判断依据是:相邻点构成的线段,斜率相同时,就是在一条实现上了
            *  2.例如连续的3个点,构成线段1和线段2,线段1的斜率为 X1/Y1 线段2的斜率为 X2/Y2 
            *  3.如果 X1/Y1 = X2/Y2, 即X1*Y2 = X2*Y1时,这3个点就是在1条直线上的
            * 
            * 关键点:
            * 
            * 时间复杂度:O(n)
            * 空间复杂度:O(1)
            */

            var firstPoint = coordinates[0];
            var secondPoint = coordinates[1];

            var x = Math.Abs(secondPoint[0] - firstPoint[0]);
            var y = Math.Abs(secondPoint[1] - firstPoint[1]);

            for (int i = 1; i < coordinates.Length - 1; i++)
            {
                var firstTemp = coordinates[i];
                var secondTemp = coordinates[i + 1];

                var xTemp = Math.Abs(secondTemp[0] - firstTemp[0]);
                var yTemp = Math.Abs(secondTemp[1] - firstTemp[1]);

                if (x * yTemp != y * xTemp) return false;
            }

            return true;
        }
    }
}
