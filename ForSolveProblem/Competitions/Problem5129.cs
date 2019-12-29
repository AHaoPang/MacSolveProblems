using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5129 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinFallingPathSum(new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            });
            if (temp != 13) throw new Exception();
        }

        public int MinFallingPathSum(int[][] arr)
        {
            var rows = arr.Length;
            var cols = arr[0].Length;

            var dp = new int[rows, cols];

            var orderList = new List<int>();
            for (int r = 0; r < rows; r++)
            {
                var newList = new List<int>();
                for (int c = 0; c < cols; c++)
                {
                    if (r == 0)
                    {
                        dp[r, c] = arr[r][c];
                        newList.Add(dp[r, c]);
                    }
                    else
                    {
                        var lastNum = dp[r - 1, c];
                        var curNum = orderList.First(i => i <= lastNum);
                        if (curNum == lastNum)
                        {
                            var cTemp = orderList.Count(i => i == lastNum);
                            if (cTemp == 1) curNum = orderList.First(i => i > lastNum);
                        }

                        dp[r, c] = arr[r][c] + curNum;
                        newList.Add(dp[r, c]);
                    }
                }

                orderList = newList.OrderBy(i => i).ToList();
            }

            var forReturn = int.MaxValue;
            for (int c = 0; c < cols; c++)
                forReturn = Math.Min(dp[rows - 1, c], forReturn);

            return forReturn;
        }
    }
}
