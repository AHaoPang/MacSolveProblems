using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace ForSolveProblem
{
    public class Problem764 : IProblem
    {
        public int OrderOfLargestPlusSign(int N, int[][] mines)
        {
            /*
             * 题目概述：在网格中寻找由1 构成的最大的加号
             * 
             * 思路：
             *  1. 最大的加号是多大,完全看中间的 1 能向外扩展多少个 1
             *  2. 而一个 1 上下左右扩展的最长的 1 是可以累积的
             *  3. 比方说,自己是 1,左边统计的最大值+1,就是自己向左边扩展的最大长度,同理上下右
             *  4. 最后遍历中心位置向外最大的扩展长度,即可知最大的阶是多少
             *
             * 关键点：
             *
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n^2)
             */

            var grid = new int[N, N];
            for (int i = 0; i < mines.Length; i++)
            {
                int x = mines[i][0];
                int y = mines[i][1];

                grid[x, y] = 1;
            }

            var dp = new int[N, N, 4];
            var up = 0;
            var down = 1;
            var left = 2;
            var right = 3;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //left->right
                    if (grid[i, j] == 1) dp[i, j, left] = 0;
                    else if (j == 0) dp[i, j, left] = 1;
                    else dp[i, j, left] = dp[i, j - 1, left] + 1;
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = N - 1; j >= 0; j--)
                {
                    //right->left
                    if (grid[i, j] == 1) dp[i, j, right] = 0;
                    else if (j == N - 1) dp[i, j, right] = 1;
                    else dp[i, j, right] = dp[i, j + 1, right] + 1;
                }
            }

            for (int j = N - 1; j >= 0; j--)
            {
                for (int i = 0; i < N; i++)
                {
                    //up-->down
                    if (grid[i, j] == 1) dp[i, j, up] = 0;
                    else if (i == 0) dp[i, j, up] = 1;
                    else dp[i, j, up] = dp[i - 1, j, up] + 1;
                }
            }

            for (int j = N - 1; j >= 0; j--)
            {
                for (int i = N - 1; i >= 0; i--)
                {
                    //down->up
                    if (grid[i, j] == 1) dp[i, j, down] = 0;
                    else if (i == N - 1) dp[i, j, down] = 1;
                    else dp[i, j, down] = dp[i + 1, j, down] + 1;
                }
            }

            var forReturn = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    var numArray = new int[] { dp[i, j, up], dp[i, j, down], dp[i, j, left], dp[i, j, right] };
                    forReturn = Math.Max(forReturn, numArray.Min());
                }
            }
            return forReturn;
        }

        public void RunProblem()
        {
            var temp = OrderOfLargestPlusSign(5, new int[][] { new int[] { 4, 2 } });
            if (temp != 2) throw new Exception();

            temp = OrderOfLargestPlusSign(2, new int[][] { });
            if (temp != 1) throw new Exception();

            temp = OrderOfLargestPlusSign(1, new int[][] { new int[] { 0, 0 } });
            if (temp != 0) throw new Exception();

            temp = OrderOfLargestPlusSign(2, new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 } });
            if (temp != 1) throw new Exception();
        }
    }
}
