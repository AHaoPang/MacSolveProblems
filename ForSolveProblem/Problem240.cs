using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem240 : IProblem
    {
        public void RunProblem()
        {
            int[,] matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22 },
                {10, 13, 14, 17, 24 },
                {18, 21, 23, 26, 30 },
            };

            int target = 5;

            var temp = SearchMatrix(matrix, target);
            if (temp != true) throw new Exception();

            target = 20;
            temp = SearchMatrix(matrix, target);
            if (temp != false) throw new Exception();

            target = 44;
            temp = SearchMatrix(matrix, target);
            if (temp != false) throw new Exception();
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            /*
             * 在一个有规律的二维矩阵中，快速搜索目标值
             * 思路：
             *  1.左上角-->右上角-->右下角，这个方向上的序列，是递增的，而右上角的值，可以认为是“中点”；
             *  2.目标值与“中点”一定只存在3种关系：
             *      2.1 等于， 那么目的达到；
             *      2.2 小于，那么目标值在下面，把当前所在行排除掉
             *      2.3 大于，那么目标值在左面，把当前所在列排除掉
             *  3.极端情况下，一直移动到了边界外，还是没有找到，那么就是真的没有了
             *  
             * 时间复杂度：O(m+n)，有点儿像从地图上的一点，移动到另一点的过程
             * 空间复杂度：O(1)，不使用额外的存储空间
             */

            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;

            int startRow = 0;
            while (startRow <= row && col >= 0)
            {
                if (matrix[startRow, col] == target) return true;
                else if (matrix[startRow, col] > target) col--;
                else startRow++;
            }

            return false;
        }
    }
}
