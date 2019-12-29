using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5137 : IProblem
    {
        public void RunProblem()
        {
            var temp = PathsWithMaxScore(new List<string> { "E23", "2X2", "12S" });

            temp = PathsWithMaxScore(new List<string> { "E12", "1X1", "21S" });

            temp = PathsWithMaxScore(new List<string> { "E11", "XXX", "11S" });
        }

        class ElementEntity
        {
            public ElementEntity(int toNum, int c)
            {
                TotalNum = toNum;
                Count = c;
            }

            public int TotalNum { get; set; }

            public int Count { get; set; }
        }

        public int[] PathsWithMaxScore(IList<string> board)
        {
            var constNum = (int)1e9 + 7;
            var rows = board.Count;
            var cols = board.First().Length;

            var dp = new ElementEntity[rows, cols];
            dp[rows - 1, cols - 1] = new ElementEntity(0, 1);

            for (int colIndex = cols - 2; colIndex >= 0; colIndex--)
            {
                if (board[rows - 1][colIndex] == 'X') continue;

                var intTemp = int.Parse(board[rows - 1][colIndex].ToString());

                if (dp[rows - 1, colIndex + 1] != null)
                    dp[rows - 1, colIndex] = new ElementEntity(dp[rows - 1, colIndex + 1].TotalNum + intTemp, 1);
            }

            for (int rowIndex = rows - 2; rowIndex >= 0; rowIndex--)
            {
                if (board[rowIndex][cols - 1] == 'X') continue;

                var intTemp = int.Parse(board[rowIndex][cols - 1].ToString());

                if (dp[rowIndex + 1, cols - 1] != null)
                    dp[rowIndex, cols - 1] = new ElementEntity(dp[rowIndex + 1, cols - 1].TotalNum + intTemp, 1);
            }

            for (int rowIndex = rows - 2; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = cols - 2; colIndex >= 0; colIndex--)
                {
                    if (board[rowIndex][colIndex] == 'X') continue;

                    var maxNum = 0;

                    var right = dp[rowIndex, colIndex + 1];
                    if (right != null) maxNum = Math.Max(maxNum, right.TotalNum);

                    var down = dp[rowIndex + 1, colIndex];
                    if (down != null) maxNum = Math.Max(maxNum, down.TotalNum);

                    var rd = dp[rowIndex + 1, colIndex + 1];
                    if (rd != null) maxNum = Math.Max(maxNum, rd.TotalNum);

                    if (right == null && down == null && rd == null) continue;

                    var totalPath = 0;
                    if (right != null && maxNum == right.TotalNum)
                    {
                        totalPath += right.Count;
                        totalPath %= constNum;
                    }

                    if (down != null && maxNum == down.TotalNum)
                    {
                        totalPath += down.Count;
                        totalPath %= constNum;
                    }

                    if (rd != null && maxNum == rd.TotalNum)
                    {
                        totalPath += rd.Count;
                        totalPath %= constNum;
                    }

                    var curValue = 0;
                    if (rowIndex != 0 || colIndex != 0)
                        curValue = int.Parse(board[rowIndex][colIndex].ToString());

                    if (totalPath == 0)
                        dp[rowIndex, colIndex] = new ElementEntity(curValue, 1);
                    else
                        dp[rowIndex, colIndex] = new ElementEntity(curValue + maxNum, totalPath);
                }
            }

            if (dp[0, 0] == null) return new int[] { 0, 0 };
            return new int[] { dp[0, 0].TotalNum, dp[0, 0].Count };
        }
    }
}
