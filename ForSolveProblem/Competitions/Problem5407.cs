using System;
namespace ForSolveProblem
{
    public class Problem5407 : IProblem
    {
        public void RunProblem()
        {
            var temp = Ways(new[] { "A..", "AAA", "..." }, 3);
            if (temp != 3) throw new Exception();

            temp = Ways(new[] { "A..", "AA.", "..." }, 3);
            if (temp != 1) throw new Exception();

            temp = Ways(new[] { "A..", "A..", "..." }, 1);
            if (temp != 1) throw new Exception();

            temp = Ways(new[] { ".A..A", "A.A..", "A.AA.", "AAAA.", "A.AA." }, 5);
            if (temp != 153) throw new Exception();
        }

        public int Ways(string[] pizza, int k)
        {
            var constNum = (int)1e9 + 7;
            var numArr = new int[pizza.Length, pizza[0].Length];
            for (var r = pizza.Length - 1; r >= 0; r--)
            {
                var s = 0;
                for (var c = pizza[r].Length - 1; c >= 0; c--)
                {
                    if (pizza[r][c] == 'A')
                        s += 1;

                    numArr[r, c] = s;
                    if (r != pizza.Length - 1)
                        numArr[r, c] += numArr[r + 1, c];
                }
            }

            var dp = new long[pizza.Length, pizza[0].Length, k + 1];

            for (var l = 1; l <= k; l++)
            {
                for (var r = 0; r < pizza.Length; r++)
                {
                    for (var c = 0; c < pizza[r].Length; c++)
                    {
                        if (l == 1)
                        {
                            if (numArr[r, c] >= l)
                                dp[r, c, l] = 1;

                            continue;
                        }

                        var sum = 0L;
                        for (var rt = r + 1; rt < pizza.Length; rt++)
                        {
                            var sub = numArr[r, c] - numArr[rt, c];
                            if (sub == 0 || numArr[rt, c] == 0) continue;

                            sum += dp[rt, c, l - 1];
                        }

                        for (var ct = c + 1; ct < pizza[r].Length; ct++)
                        {
                            var sub = numArr[r, c] - numArr[r, ct];
                            if (sub == 0 || numArr[r, ct] == 0) continue;

                            sum += dp[r, ct, l - 1];
                        }

                        sum %= constNum;
                        dp[r, c, l] = sum;
                    }
                }
            }

            return (int)dp[0, 0, k];
        }

        public int Ways2(string[] pizza, int k)
        {
            var constNum = (int)1e9 + 7;
            var rows = pizza.Length;
            var cols = pizza[0].Length;

            var dp = new int[rows, cols];
            for (var r = 0; r < pizza.Length; r++)
            {
                var s = 0;
                for (var c = 0; c < pizza[r].Length; c++)
                {
                    if (pizza[r][c] == 'A')
                        s++;

                    dp[r, c] = s;
                    if (r > 0)
                        dp[r, c] = dp[r - 1, c] + s;
                }
            }

            var res = new long[rows, cols, k + 1];
            for (var l = 1; l <= k; l++)
            {
                for (var r = 0; r < rows; r++)
                {
                    for (var c = 0; c < cols; c++)
                    {
                        if (dp[r, c] < l)
                            continue;

                        if (l == 1 && dp[r, c] >= 1)
                        {
                            res[r, c, l] = 1;
                            continue;
                        }

                        var sum = 0L;
                        for (var ct = 0; ct < c; ct++)
                        {
                            var sub = dp[r, c] - dp[r, ct];
                            if (sub == 0 || dp[r, ct] == 0) continue;

                            sum += res[r, ct, l - 1];
                        }

                        for (var rt = 0; rt < r; rt++)
                        {
                            var sub = dp[r, c] - dp[rt, c];
                            if (sub == 0 || dp[rt, c] == 0) continue;

                            sum += res[rt, c, l - 1];
                        }

                        sum %= constNum;
                        res[r, c, l] = sum;
                    }
                }
            }

            return (int)res[rows - 1, cols - 1, k];
        }
    }
}
