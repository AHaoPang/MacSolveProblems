using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem048 : IProblem
    {
        public void RunProblem()
        {
            int[][] matrix = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };

            Rotate(matrix);

            matrix = new int[][]
            {
                new int[]{5, 1, 9,11 },
                new int[]{2, 4, 8,10 },
                new int[]{13, 3, 6, 7 },
                new int[]{ 15, 14, 12, 16 }
            };

            Rotate(matrix);
        }

        public void Rotate(int[][] matrix)
        {
            /*
             * 二维矩阵，顺时针旋转90度
             * 思路：
             *  1.这种旋转显然是有规律的，初步总结为，以左上角为起始点旋转，左上角-->右上角-->右下角-->左下角-->左上角
             *  2.矩阵的宽度为n，那么外层有多少圈要旋转呢？--> n/2
             *  3.各个角的坐标之间是有规律的，只要依次赋值就可以了
             *  
             * 时间复杂度：O(n*n)，因为二维数组的每个位置都是要遍历一遍的
             * 空间复杂度：O(1)，使用了固定大小的额外空间
             * 
             * 考察点：
             *  1.数组操作，规律性的思考
             */


            int n = matrix.GetLength(0);

            for (int i = 0; i < n / 2; i++)
                for (int j = i; j < n - 1 - i; j++)
                    RoteteOpera(matrix, j, i);
        }

        private void RoteteOpera(int[][] matrix, int startx, int row)
        {
            int n = matrix.GetLength(0);

            var temp = matrix[row][startx];
            matrix[row][startx] = matrix[n - 1 - startx][row];
            matrix[n - 1 - startx][row] = matrix[n - 1 - row][n - 1 - startx];
            matrix[n - 1 - row][n - 1 - startx] = matrix[startx][n - 1 - row];
            matrix[startx][n - 1 - row] = temp;
        }
    }
}
