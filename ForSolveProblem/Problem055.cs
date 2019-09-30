using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem055 : IProblem
    {
        public void RunProblem()
        {
            int[] nums = new int[] { 2, 3, 1, 1, 4 };
            var temp = CanJump(nums);
            if (temp != true) throw new Exception();

            nums = new int[] { 3, 2, 1, 0, 4 };
            temp = CanJump(nums);
            if (temp != false) throw new Exception();

        }

        public bool CanJump(int[] nums)
        {
            /*
             * 跳跃游戏，按照数组元素中存储的值，来确定最多能前进多少步，那么最后是否可以到达终点呢？
             * 思路：
             *  1.从前往后遍历元素
             *  2.看下每个元素最多能往后跳多少步
             *  3.最后看下上限是否到了数组的末尾即可
             *  
             * 时间复杂度：O(n)，基本上是要遍历数组一遍的
             * 空间复杂度：O(1)
             */

            int maxIndexPos = 0;
            for (int i = 0; i <= maxIndexPos; i++)
            {
                var maxTemp = i + nums[i];

                if (maxIndexPos < maxTemp) maxIndexPos = maxTemp;

                if (maxIndexPos >= nums.Length - 1) return true;
            }

            return false;
        }
    }
}
