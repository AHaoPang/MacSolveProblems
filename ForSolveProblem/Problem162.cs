using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem162 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindPeakElement(new int[] { 1, 2, 3, 1 });
            if (temp != 2) throw new Exception();

            temp = FindPeakElement(new int[] { 1, 2, 1, 3, 5, 6, 4 });
            if (temp != 1 && temp != 5) throw new Exception();

            temp = FindPeakElement(new int[] { 1 });
            if (temp != 0) throw new Exception();
        }

        public int FindPeakElement(int[] nums)
        {
            int startIndex = 0;
            int stopIndex = nums.Length - 1;

            while(startIndex < stopIndex)
            {
                int midIndex = startIndex + (stopIndex - startIndex) / 2;

                if (nums[midIndex] > nums[midIndex + 1]) stopIndex = midIndex;
                else startIndex = midIndex + 1;
            }

            return startIndex;
        }

        public int FindPeakElement3(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
                if (nums[i] > nums[i + 1]) return i;

            return nums.Length - 1;
        }

        public int FindPeakElement2(int[] nums)
        {
            /*
             * 思路，二分
             *  1.利用相邻元素绝对不想等的理念
             *  2.中间的元素只有3种情况
             *      2.1 处在上斜坡，那么移动左边界
             *      2.2 处在下斜坡，那么移动右边界
             *      2.3 刚好是个峰，那么就返回
             *  3.特殊情况的处理，即，峰就在边界
             *  
             * 时间复杂度：O(logn)
             * 空间复杂度：O(1)
             */

            //依据题意可以断定，数组元素的个数一定是大于1的，不然是不可能有峰值的
            if (nums.Length == 1) return 0;
            if (nums.Length == 2) return nums[0] > nums[1] ? 0 : 1;

            int startIndex = 0;
            int stopIndex = nums.Length - 1;

            while (startIndex <= stopIndex)
            {
                //峰值是一定会出现在这个循环里面的
                int midIndex = startIndex + (stopIndex - startIndex) / 2;

                //左边界
                if (midIndex == 0)
                {
                    if (nums[midIndex] > nums[midIndex + 1]) return midIndex;

                    startIndex = midIndex + 1;
                    continue;
                }

                //右边界
                if (midIndex == nums.Length - 1)
                {
                    if (nums[midIndex] > nums[midIndex - 1]) return midIndex;

                    stopIndex = midIndex - 1;
                    continue;
                }

                //中间位置
                //坡峰
                if (nums[midIndex] > nums[midIndex - 1] && nums[midIndex] > nums[midIndex + 1]) return midIndex;

                //左右斜坡
                if (nums[midIndex] > nums[midIndex - 1]) startIndex = midIndex + 1;
                else stopIndex = midIndex - 1;
            }

            return -1;
        }

        public int FindPeakElement1(int[] nums)
        {
            /*
             * 寻找数组中的特定元素，本题中是，一个峰值元素
             * 题目梳理：
             *  1.峰值元素，大于左右相邻元素；
             *  2.相邻的两个元素，决定不相同；
             *  3.多个峰值，返回任意一个都是可以的
             * 
             * 思路
             *  1.使用O(n)的算法，遍历得到这样一个特殊的元素好了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            if (nums.Length == 1) return 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    if (nums[i] > nums[i + 1]) return i;

                    continue;
                }

                if (i == nums.Length - 1)
                {
                    if (nums[i] > nums[i - 1]) return i;

                    continue;
                }

                if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1]) return i;
            }

            return -1;
        }
    }
}
