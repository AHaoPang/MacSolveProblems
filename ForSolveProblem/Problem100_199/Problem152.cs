using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem152 : IProblem
    {
        public void RunProblem()
        {
            MaxProduct(new int[] { 2, 3, -2, 4 });
        }

        public int MaxProduct(int[] nums)
        {
            var res = nums[0];
            var max = nums[0];
            var min = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                var list = new int[] { nums[i], min * nums[i], max * nums[i] };
                max = list.Max();
                min = list.Min();
                res = Math.Max(res, max);
            }

            return res;
        }

        public int MaxProduct4(int[] nums)
        {
            if (!nums.Any()) return 0;

            /*
             * 动态规划求解法,复杂度分析：
             * 1.时间复杂度：O(n)，每个序列元素遍历一次，所以是线性复杂度；
             * 2.空间复杂度：O(n),即和序列的长度一致，或者O(1),固定大小的空间就行；
             */
            int[,] posArray = new int[nums.Length, 2];

            posArray[0, 0] = nums[0];
            posArray[0, 1] = nums[0];

            //具体的规划步骤
            for (int i = 1; i < nums.Length; i++)
            {
                int v1 = nums[i];
                int v2 = posArray[i - 1, 0] * v1;
                int v3 = posArray[i - 1, 1] * v1;

                posArray[i, 0] = Math.Min(Math.Min(v1, v2), v3);
                posArray[i, 1] = Math.Max(Math.Max(v1, v2), v3);
            }

            //得到目标值
            int maxTemp = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
                if (maxTemp < posArray[i, 1]) maxTemp = posArray[i, 1];

            return maxTemp;
        }


        #region 回溯求解法
        public int MaxProduct1(int[] nums)
        {
            /*
             * 复杂度分析：
             * 1.时间复杂度，O(n^2);每个起始位置进入一次递归，每个递归内部做了一次遍历，所以是平方级别的复杂度；
             * 2.空间复杂度，O(n^2);递归函数需要存储中间生成的变量
             */

            for (int i = 0; i < nums.Length; i++)
                Recursive(1, i, nums);

            return MaxProductStore;
        }

        private int MaxProductStore = int.MinValue;

        /// <summary>
        /// 递归遍历法
        /// </summary>
        /// <param name="curValue">当前的乘积</param>
        /// <param name="nextPos">下一个数字的位置</param>
        /// <param name="nums">数字序列</param>
        private void Recursive(int curValue, int nextPos, int[] nums)
        {
            //end point
            if (nextPos == nums.Length) return;

            int cValue = curValue * nums[nextPos];
            if (MaxProductStore < cValue) MaxProductStore = cValue;

            //go on
            Recursive(cValue, nextPos + 1, nums);
        }
        #endregion
    }
}
