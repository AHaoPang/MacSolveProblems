using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5387 : IProblem
    {
        public void RunProblem()
        {
            var list = new List<IList<int>>();
            list.Add(new List<int>() { 3, 4 });
            list.Add(new List<int>() { 4, 5 });
            list.Add(new List<int>() { 5 });
            var t = NumberWays(list);
        }

        public int NumberWays(IList<IList<int>> hats)
        {
            var constNum = (int)1e9 + 7;

            var n = hats.Count;
            var dp = new long[1 << n, 41];
            for (var k = 0; k < 41; k++)
                dp[0, k] = 1;

            var dic = new Dictionary<int, ISet<int>>(40);
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < hats[i].Count; j++)
                {
                    var hat = hats[i][j];

                    if (!dic.ContainsKey(hat))
                        dic[hat] = new HashSet<int>();

                    dic[hat].Add(i);
                }
            }

            for (var i = 1; i <= 40; i++)
            {
                for (var j = (1 << n) - 1; j >= 0; j--)
                {
                    if (!dic.ContainsKey(i))
                    {
                        dp[j, i] = dp[j, i - 1];
                        continue;
                    }

                    foreach (var dicItem in dic[i])
                    {
                        if ((j & (1 << dicItem)) != 0)
                        {
                            dp[j, i] = dp[j, i - 1];
                            continue;
                        }

                        dp[j + (1 << dicItem), i] += dp[j, i - 1];
                        dp[j + (1 << dicItem), i] %= constNum;
                    }
                }
            }

            return (int)dp[(1 << n) - 1, 40];
        }
    }
}
