using System;
namespace ForSolveProblem
{
    public class Problem547 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindCircleNum(int[][] isConnected)
        {
            var pointCount = isConnected.GetLength(0);
            visited = new bool[pointCount];

            var res = 0;
            for (var i = 0; i < pointCount; i++)
            {
                if (visited[i]) continue;
                visited[i] = true;

                res++;
                Dfs(isConnected, i);
            }

            return res;
        }

        private bool[] visited;

        private void Dfs(int[][] isConnected, int pos)
        {
            var count = isConnected.GetLength(0);
            for (var i = 0; i < count; i++)
            {
                if (visited[i]) continue;

                if (isConnected[pos][i] == 1)
                {
                    visited[i] = true;
                    Dfs(isConnected, i);
                }
            }
        }
    }
}
