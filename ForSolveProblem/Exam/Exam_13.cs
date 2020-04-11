using System;
namespace ForSolveProblem
{
    public class Exam_13 : IProblem
    {
        public Exam_13()
        {
        }

        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MovingCount(int m, int n, int k)
        {
            var visited = new bool[m, n];
            var arr = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };

            m_res = 0;
            Recursive(arr, m, n, 0, 0, k, visited);
            return m_res;
        }

        private int m_res;
        private void Recursive(int[][] arr, int m, int n, int r, int c, int k, bool[,] visited)
        {
            if (r >= m || r < 0 || c >= n || c < 0 || visited[r, c] || GetPosSum(r, c) > k)
                return;

            visited[r, c] = true;
            m_res++;

            foreach (var arrItem in arr)
                Recursive(arr, m, n, r + arrItem[0], c + arrItem[1], k, visited);
        }

        private int GetPosSum(int r, int c)
        {
            int GetSum(int i)
            {
                var res = 0;
                while (i > 0)
                {
                    res += i % 10;
                    i /= 10;
                }

                return res;
            }

            return GetSum(r) + GetSum(c);
        }

        public int MovingCount1(int m, int n, int k)
        {
            var res = 0;
            for (var r = 0; r < m; r++)
                for (var c = 0; c < n; c++)
                    if (r + c <= k)
                        res++;

            return res;
        }
    }
}
