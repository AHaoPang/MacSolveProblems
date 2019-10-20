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
