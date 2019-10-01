using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem073 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public void SetZeroes(int[][] matrix)
        {
            /*
             * 依据规则，修改矩阵
             * 思路：
             *  1.若检测到0，那么这行和这列，最终都会为0
             *  2.那么就遍历整个矩阵，若发现0，就收集行和列信息
             *  3.最后统一把行和列修改为0
             *  
             * 时间复杂度：O(m*n)
             * 空间复杂度：O(m+n)，需要额外的空间来记录，到底是哪些行和列要被清0了
             */

            int rowCount = matrix.GetLength(0);
            int colCount = matrix[0].Length;

            HashSet<int> rowNums = new HashSet<int>();
            HashSet<int> colNums = new HashSet<int>();

            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    if (matrix[r][c] == 0)
                    {
                        rowNums.Add(r);
                        colNums.Add(c);
                    }

            for (int r = 0; r < rowCount; r++)
                for (int c = 0; c < colCount; c++)
                    if (rowNums.Contains(r) || colNums.Contains(c)) matrix[r][c] = 0;
        }
    }
}
