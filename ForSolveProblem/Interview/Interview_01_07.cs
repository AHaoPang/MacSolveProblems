using System;
namespace ForSolveProblem
{
    public class Interview_01_07 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;
            if (n == 0) return;

            var loopCount = n / 2;
            for (var nr = 0; nr < loopCount; nr++)
            {
                for (var nc = nr; nc < n - 1 - nr; nc++)
                {
                    var tr = nr;
                    var tc = nc;
                    var curValue = matrix[tr][tc];
                    for (var i = 0; i < 4; i++)
                    {
                        var nextR = tc;
                        var nextC = n - 1 - tr;

                        var lastValue = matrix[nextR][nextC];
                        matrix[nextR][nextC] = curValue;
                        curValue = lastValue;

                        tr = nextR;
                        tc = nextC;
                    }
                }
            }
        }

        public void Rotate1(int[][] matrix)
        {
            var n = matrix.Length;
            if (n == 0) return;

            var another = new int[n][];
            for (var i = 0; i < n; i++)
                another[i] = new int[n];

            var nr = 0;
            var nc = n - 1;
            for (int rIndex = 0; rIndex < n; rIndex++)
            {
                for (int cIndex = 0; cIndex < n; cIndex++)
                {
                    another[nr][nc] = matrix[rIndex][cIndex];
                    nr++;

                    if (nr == n)
                    {
                        nr = 0;
                        nc--;
                    }
                }
            }

            for (int rIndex = 0; rIndex < n; rIndex++)
                for (int cIndex = 0; cIndex < n; cIndex++)
                    matrix[rIndex][cIndex] = another[rIndex][cIndex];
        }
    }
}
