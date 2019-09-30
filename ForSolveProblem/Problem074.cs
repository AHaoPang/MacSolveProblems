using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem074 : IProblem
    {
        public void RunProblem()
        {
            int[][] matrix = new int[][]
            {
                new int[]{1,   3,  5,  7},
                new int[]{10, 11, 16, 20},
                new int[]{23, 30, 34, 50}
            };

            int target = 3;

            var temp = SearchMatrix(matrix, target);
            if (temp != true) throw new Exception();

            target = 13;
            temp = SearchMatrix(matrix, target);
            if (temp != false) throw new Exception();

            matrix = new int[][]
            {
                new int[]{1,1}
            };
            target = 2;

            temp = SearchMatrix(matrix, target);
            if (temp != false) throw new Exception();

            matrix = new int[][]
            {
                new int[]{1,3}
            };
            target = 3;

            temp = SearchMatrix(matrix, target);
            if (temp != true) throw new Exception();
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            /*
             * 在特殊的二维矩阵中查找目标值
             * 思路：
             *  1.矩阵本身，很显然，就是一个已排好的序列
             *  2.那么问题的本质就是：二分查找了
             *  
             * 时间复杂度：O(logn)，即，标准的二分查找时间复杂度
             * 空间复杂度：O(1)，即，使用的额外空间是固定的
             */

            int raw = matrix.GetLength(0);
            if (raw == 0) return false;

            int col = matrix[0].Length;

            int totalCount = raw * col;

            int leftIndex = 0;
            int rigthIndex = totalCount - 1;

            while (leftIndex <= rigthIndex)
            {
                int middleTemp = leftIndex + (rigthIndex - leftIndex) / 2;

                int rawTemp = middleTemp / col;
                int colTemp = middleTemp % col;

                if (matrix[rawTemp][colTemp] == target) return true;

                else if (matrix[rawTemp][colTemp] < target) leftIndex = middleTemp + 1;

                else rigthIndex = middleTemp - 1;
            }

            return false;
        }
    }
}
