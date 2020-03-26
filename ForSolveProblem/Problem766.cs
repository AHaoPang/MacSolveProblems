using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem766 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsToeplitzMatrix(int[][] matrix)
        {
            for (var r = 0; r < matrix.Length; r++)
                for (var c = 0; c < matrix[r].Length; c++)
                    if (r != 0 && c != 0 && matrix[r][c] != matrix[r - 1][c - 1])
                        return false;

            return true;
        }

        public bool IsToeplitzMatrix3(int[][] matrix)
        {
            var dic = new Dictionary<int, int>();
            for (var r = 0; r < matrix.Length; r++)
            {
                for (var c = 0; c < matrix[r].Length; c++)
                {
                    if (!dic.ContainsKey(r - c))
                        dic[r - c] = matrix[r][c];
                    else if (dic[r - c] != matrix[r][c])
                        return false;
                }
            }

            return true;
        }

        public bool IsToeplitzMatrix2(int[][] matrix)
        {
            var link = new LinkedList<int>();
            for (var c = 0; c < matrix[0].Length; c++)
                link.AddLast(matrix[0][c]);

            for (var r = 1; r < matrix.Length; r++)
            {
                link.RemoveLast();

                var f = link.First;
                for (var c = 1; c < matrix[r].Length; c++)
                {
                    if (f.Value != matrix[r][c])
                        return false;

                    f = f.Next;
                }

                link.AddFirst(matrix[r][0]);
            }

            return true;
        }

        public bool IsToeplitzMatrix1(int[][] matrix)
        {
            for (var c = 0; c < matrix[0].Length; c++)
                if (!IsSame(matrix, 0, c))
                    return false;

            for (var r = 0; r < matrix.Length; r++)
                if (!IsSame(matrix, r, 0))
                    return false;

            return true;
        }

        private bool IsSame(int[][] matrix, int r, int c)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            var curValue = matrix[r][c];
            while (r < rows && c < cols)
                if (matrix[r++][c++] != curValue)
                    return false;

            return true;
        }
    }
}
