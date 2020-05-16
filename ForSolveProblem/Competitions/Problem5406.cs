using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5406 : IProblem
    {
        public void RunProblem()
        {
            var arr = new int[][]
            {
                new[]{0, 1 },
                new[]{0, 2},
                new[]{1, 4},
                new[]{1, 5},
                new[]{2, 3},
                new[]{2, 6}
            };
            var temp = MinTime(7, arr, new[] { false, false, true, false, true, true, false });
        }

        public int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            var fromToDic = new Dictionary<int, List<int>>();
            for (var i = 0; i < edges.Length; i++)
            {
                var f = edges[i][0];
                var t = edges[i][1];

                if (!fromToDic.ContainsKey(f))
                    fromToDic[f] = new List<int>();

                fromToDic[f].Add(t);
            }

            var r = Dfs(fromToDic, 0, hasApple);
            if (r == 0)
                return 0;

            return (r - 1) * 2;
        }

        private int Dfs(Dictionary<int, List<int>> dic, int curIndex, IList<bool> hasApple)
        {
            if (!dic.ContainsKey(curIndex))
            {
                if (hasApple[curIndex])
                    return 1;
                return 0;
            }

            var sum = 0;
            foreach (var nextIndex in dic[curIndex])
                sum += Dfs(dic, nextIndex, hasApple);

            if (sum == 0 && hasApple[curIndex])
                return 1;

            return sum != 0 ? sum + 1 : 0;
        }
    }
}
