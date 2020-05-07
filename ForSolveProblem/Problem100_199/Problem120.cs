using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem120 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var dp = triangle.Last();
            for (var i = triangle.Count - 2; i >= 0; i--)
                for (var j = 0; j < triangle[i].Count; j++)
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];

            return dp[0];
        }

        public int MinimumTotal3(IList<IList<int>> triangle)
        {
            /*
             * 动态规划复杂度分析：
             * 1.时间复杂度，遍历二维数组的每个元素1次，所以是O(m*n)；
             * 2.空间复杂度，一维数组一个，O(n)；
             * 是一种逆向稳步向前的一种思维方式
             */

            IList<int> arr = new List<int>(triangle[triangle.Count - 1]);

            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    arr[j] = Math.Min(arr[j], arr[j + 1]) + triangle[i][j];
                }
            }

            return arr[0];
        }

        #region 回溯法
        public int MinimumTotalV2(IList<IList<int>> triangle)
        {
            /*
             * 使用回溯穷举加缓存的方式，复杂度分析
             * 1.时间复杂度：最好情况是每个点都遍历一遍，最坏情况，则是指数级别的复杂度；
             * 2.空间复杂度：额外申请二维数组大小的空间，也就是O(m*n);
             */

            //二维数组的初始化
            SaveNums = new List<IList<int>>();
            for (int i = 0; i < triangle.Count; i++)
            {
                SaveNums.Add(new List<int>());

                for (int j = 0; j < triangle[i].Count; j++)
                    SaveNums[i].Add(int.MaxValue);
            }

            Recursive(triangle[0][0], 0, 0, triangle.Count, triangle);

            return MinSum;
        }

        private int MinSum = int.MaxValue;

        private IList<IList<int>> SaveNums;

        private void Recursive(int curSum, int i, int j, int maxRow, IList<IList<int>> triangle)
        {
            //Ending Point
            if (i == maxRow - 1)
            {
                if (MinSum > curSum) MinSum = curSum;
                return;
            }

            /*左值，右值二维数组的更新，若发现是最小的，那么就继续下去，否则直接返回*/

            int leftValue = triangle[i + 1][j];
            if (leftValue + curSum < SaveNums[i + 1][j])
            {
                SaveNums[i + 1][j] = leftValue + curSum;
                Recursive(leftValue + curSum, i + 1, j, maxRow, triangle);
            }

            int rightValue = triangle[i + 1][j + 1];
            if (rightValue + curSum < SaveNums[i + 1][j + 1])
            {
                SaveNums[i + 1][j + 1] = rightValue + curSum;
                Recursive(rightValue + curSum, i + 1, j + 1, maxRow, triangle);
            }
        }
        #endregion
    }
}
