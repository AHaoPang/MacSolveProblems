using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1252 : IProblem
    {
        public void RunProblem()
        {
            var temp = OddCells(2, 3, new int[][]
            {
                new int[]{0,1},
                new int[]{1,1},
            });
            if (temp != 6) throw new Exception();

            temp = OddCells(2, 2, new int[][]
            {
                new int[]{1,1},
                new int[]{0,0}
            });
            if (temp != 0) throw new Exception();
        }

        public int OddCells(int n, int m, int[][] indices)
        {
            /*
             * 问题:统计奇数单元格的数量
             * 思路:
             *  1.用两个数组分别统计行与列被累加的多少次
             *  2.再遍历所有的单元格,将行与列加起来,判断奇偶
             * 
             * 关键点:
             * 
             * 时间复杂度:O(m*n)
             * 空间复杂度:O(m+n)
             */

            var rows = new int[n];
            var cols = new int[m];

            for (int i = 0; i < indices.Length; i++)
            {
                var rowTemp = indices[i][0];
                var colTemp = indices[i][1];

                rows[rowTemp]++;
                cols[colTemp]++;
            }

            var forReturn = 0;
            for (int row = 0; row < rows.Length; row++)
                for (int col = 0; col < cols.Length; col++)
                    if ((rows[row] + cols[col] & 1) == 1) forReturn++;

            return forReturn;
        }
    }
}
