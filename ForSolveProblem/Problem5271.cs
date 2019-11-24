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
            var forReturn = 0;

            for (int i = 0; i < points.Length - 1; i++)
                forReturn += GetTwoPointTime(points[i], points[i + 1]);

            return forReturn;
        }

        private int GetTwoPointTime(int[] point1, int[] point2) => Math.Max(Math.Abs(point1[0] - point2[0]), Math.Abs(point1[1] - point2[1]));
    }
}
