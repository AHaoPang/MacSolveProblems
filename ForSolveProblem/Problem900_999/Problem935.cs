using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem935 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int KnightDialer1(int N)
        {
            var arr = new int[][]
            {
                new[]{4,6 },
                new[]{6,8 },
                new[]{7,9},
                new[]{4,8},
                new[]{0,9,3},
                new int[]{},
                new[]{0,1,7},
                new[]{2,6},
                new[]{1,3},
                new[]{2,4}
            };
            var constNum = (int)1e9 + 7;
            var dp = Enumerable.Repeat(1L, 10).ToArray();
            for (var i = 1; i < N; i++)
            {
                var newDp = new long[10];
                for (var num = 0; num <= 9; num++)
                {
                    foreach (var numItem in arr[num])
                    {
                        newDp[num] += dp[numItem];
                        newDp[num] %= constNum;
                    }
                }

                dp = newDp;
            }

            var res = 0L;
            for (var i = 0; i < dp.Length; i++)
            {
                res += dp[i];
                res %= constNum;
            }

            return (int)res;
        }
    }
}
