using System;
namespace ForSolveProblem
{
    public class Problem526 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountArrangement(2);
            if (temp != 2) throw new Exception();
        }

        public int CountArrangement(int N)
        {
            var dp = new int[1 << N];
            dp[0] = 1;

            for (var i = 0; i < (1 << N); i++)
            {
                var index = 1;
                var it = i;
                while (it != 0)
                {
                    index++;
                    it &= it - 1;
                }

                for (var j = 0; j < N; j++)
                {
                    if ((i & (1 << j)) != 0)
                        continue;

                    if (index % (j + 1) == 0 || (j + 1) % index == 0)
                        dp[i | (1 << j)] += dp[i];
                }
            }

            return dp[(1 << N) - 1];
        }

        public int CountArrangement1(int N)
        {
            m_res = 0;
            Dfs(N, 1, new bool[N + 1]);
            return m_res;
        }

        private int m_res;

        private void Dfs(int N, int curLevel, bool[] visited)
        {
            if (curLevel > N)
            {
                m_res++;
                return;
            }

            for (var i = 1; i <= N; i++)
            {
                if (visited[i])
                    continue;

                if (i % curLevel == 0 || curLevel % i == 0)
                {
                    visited[i] = true;
                    Dfs(N, curLevel + 1, visited);
                    visited[i] = false;
                }
            }
        }
    }
}
