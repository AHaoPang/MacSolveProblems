using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem304 : IProblem
    {
        public void RunProblem()
        {
            var t = new NumMatrix(new int[][]
            {
                new int[] { 3, 0, 1, 4, 2 },
                new int[] { 5, 6, 3, 2, 1 },
                new int[] { 1, 2, 0, 1, 5 },
                new int[] { 4, 1, 0, 1, 7 },
                new int[] { 1, 0, 3, 0, 5 }
            });

            var temp = t.SumRegion(2, 1, 4, 3);
            if (temp != 8) throw new Exception();

            temp = t.SumRegion(1, 1, 2, 2);
            if (temp != 11) throw new Exception();

            temp = t.SumRegion(1, 2, 2, 4);
            if (temp != 12) throw new Exception();

            t = new NumMatrix(new int[][] { });
        }

        public class NumMatrix
        {
            private int[,] m_innerMatrix;

            public NumMatrix(int[][] matrix)
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.FirstOrDefault()?.Length ?? 0;

                m_innerMatrix = new int[rows, cols];

                var sumOneRow = 0;
                for (int i = 0; i < rows; i++)
                {
                    sumOneRow += matrix[i][0];
                    m_innerMatrix[i, 0] = sumOneRow;
                }

                var sumOneCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    sumOneCol += matrix[0][j];
                    m_innerMatrix[0, j] = sumOneCol;
                }

                for (int i = 1; i < rows; i++)
                    for (int j = 1; j < cols; j++)
                        m_innerMatrix[i, j] = m_innerMatrix[i - 1, j] + m_innerMatrix[i, j - 1] - m_innerMatrix[i - 1, j - 1] + matrix[i][j];
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                /*
                 * 题目概述：计算二维区域范围内元素的和
                 * 
                 * 思路：
                 *  1. 依然是 2 种计算方式，实时计算 和 预先准备好的计算
                 *  2. 本题使用已经准备好的计算
                 *  3. 提前准备的是，各个位置点，到左上角 00 位置的和
                 *  4. 那么题解就是，右下角的和 - 上面部分的和 - 左侧部分的和 + 左上角部分的和
                 *
                 * 关键点：
                 *
                 * 时间复杂度： O(n*m)
                 * 空间复杂度： O(n*m)
                 */

                var forReturn = m_innerMatrix[row2, col2];

                if (row1 > 0) forReturn -= m_innerMatrix[row1 - 1, col2];
                if (col1 > 0) forReturn -= m_innerMatrix[row2, col1 - 1];
                if (row1 > 0 && col1 > 0) forReturn += m_innerMatrix[row1 - 1, col1 - 1];

                return forReturn;
            }
        }
    }
}
