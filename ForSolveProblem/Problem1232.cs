using System;
namespace ForSolveProblem
{
    public class Problem1232 : IProblem
    {
        public void RunProblem()
        {
        }

        public bool CheckStraightLine(int[][] coordinates)
        {
            for (var i = 2; i < coordinates.Length; i++)
            {
                var p1 = coordinates[i - 2];
                var p2 = coordinates[i - 1];
                var p3 = coordinates[i];

                if ((p2[1] - p1[1]) * (p3[0] - p2[0]) != (p2[0] - p1[0]) * (p3[1] - p2[1]))
                    return false;
            }

            return true;
        }
    }
}
