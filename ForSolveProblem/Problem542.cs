using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem542 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[][] UpdateMatrix(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var visited = new bool[rows * cols];
            var queue = new Queue<(int ri, int ci)>();
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        visited[r * cols + c] = true;
                        queue.Enqueue((r, c));
                    }
                }
            }

            var arr = new int[][] { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
            while (queue.Any())
            {
                (var r1, var c1) = queue.Dequeue();
                foreach (var arrItem in arr)
                {
                    var nr = r1 + arrItem[0];
                    var nc = c1 + arrItem[1];
                    if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || visited[nr * cols + nc]) continue;

                    visited[nr * cols + nc] = true;
                    matrix[nr][nc] = matrix[r1][c1] + 1;
                    queue.Enqueue((nr, nc));
                }
            }

            return matrix;
        }
    }
}
