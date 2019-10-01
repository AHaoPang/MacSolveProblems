using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem054 : IProblem
    {
        public void RunProblem()
        {
            int[][] matrix = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            };

            var temp = SpiralOrder(matrix);
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            /*
             * 按照特定的方式遍历二维数组，即按照螺旋的方式来遍历
             * 思路：
             *  1.按照层的顺序来遍历二维数组好了，一层一层的遍历
             *  2.每一层分成4个部分，即上下左右四条边
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var forReturn = new List<int>();
            if (matrix.Length == 0) return forReturn;

            int totalRows = matrix.GetLength(0);
            int totalCols = matrix[0].Length;

            int rMin = 0, rMax = totalRows - 1;
            int cMin = 0, cMax = totalCols - 1;

            while (rMin <= rMax && cMin <= cMax)
            {
                for (int one = cMin; one <= cMax; one++) forReturn.Add(matrix[rMin][one]);
                for (int two = rMin + 1; two <= rMax; two++) forReturn.Add(matrix[two][cMax]);
                if(rMin < rMax && cMin < cMax)
                {
                    for (int three = cMax - 1; three >= cMin; three--) forReturn.Add(matrix[rMax][three]);
                    for (int four = rMax - 1; four > rMin; four--) forReturn.Add(matrix[four][cMin]);
                }

                rMin++;
                rMax--;
                cMin++;
                cMax--;
            }

            return forReturn;
        }


    }
}
