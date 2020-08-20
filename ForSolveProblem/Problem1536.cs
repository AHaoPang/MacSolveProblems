using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1536 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinSwaps(int[][] grid)
        {
            var rows = grid.GetLength(0);
            var listNum = new List<int>(rows);
            foreach (var gridItem in grid)
                listNum.Add(GetZeroCount(gridItem));

            var res = 0;
            var curRow = 0;
            var targetLength = rows - 1;
            while (targetLength > 0)
            {
                var i = curRow;
                for (; i < listNum.Count; i++)
                    if (listNum[i] >= targetLength)
                        break;

                if (i == listNum.Count)
                    return -1;

                res += i - curRow;
                for (var j = i; j > curRow; j--)
                {
                    var temp = listNum[j];
                    listNum[j] = listNum[j - 1];
                    listNum[j - 1] = temp;
                }

                curRow++;
                targetLength--;
            }

            return res;
        }

        private int GetZeroCount(int[] arr)
        {
            var res = 0;
            for (var j = arr.Length - 1; j >= 0; j--)
            {
                if (arr[j] == 0)
                    res++;
                else
                    break;
            }

            return res;
        }
    }
}
