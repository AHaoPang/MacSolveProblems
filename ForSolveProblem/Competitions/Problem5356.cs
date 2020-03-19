using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5356 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> LuckyNumbers(int[][] matrix)
        {
            var minSet = new HashSet<int>();
            for (var r = 0; r < matrix.Length; r++)
                minSet.Add(matrix[r].Min());

            var maxSet = new HashSet<int>();
            for (var c = 0; c < matrix[0].Length; c++)
            {
                var maxNum = matrix[0][c];
                for (var r = 1; r < matrix.Length; r++)
                    maxNum = Math.Max(maxNum, matrix[r][c]);

                maxSet.Add(maxNum);
            }

            return minSet.Intersect(maxSet).ToList();
        }
    }
}
