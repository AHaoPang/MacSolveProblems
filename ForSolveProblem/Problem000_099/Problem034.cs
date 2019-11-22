using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem034 : IProblem
    {
        public void RunProblem()
        {
            var result1 = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            if (result1[0] != -1 || result1[1] != -1)
                throw new Exception("wrong");

            var result2 = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            if (result2[0] != 3 || result2[1] != 4)
                throw new Exception("wrong");

            var result3 = SearchRange(new int[] { 1 }, 1);
            if (result3[0] != 0 || result3[1] != 0)
                throw new Exception("wrong");

            var result4 = SearchRange(new int[] { 2, 2 }, 2);
            if (result4[0] != 0 || result4[1] != 1)
                throw new Exception("wrong");

            var result5 = SearchRange(new int[] { 1, 2, 3 }, 2);
            if (result5[0] != 1 || result5[1] != 1)
                throw new Exception("wrong");
        }

        public int[] SearchRange(int[] nums, int target)
        {
            /*
             * 查找目标值在一个有序数组中的存在范围
             * 思路：
             * 1.用正常的二分法确定是否存在目标值；
             * 2.再使用特殊的二分法寻找数据的范围边界；
             * 
             * 时间复杂度：O(logn)
             * 空间复杂度：O(1)
             * 
             * 知识点：
             * 1.二分法的多种综合应用
             */

            int[] forReturn = new int[] { -1, -1 };

            int left = 0;
            int rigth = nums.Length - 1;
            while (left <= rigth)
            {
                int mid = left + (rigth - left) / 2;

                if (nums[mid] == target)
                {
                    //此处开展另一个逻辑
                    int leftValue = FindLeftValue(nums, left, mid);
                    int rightValue = FindRightValue(nums, mid, rigth);
                    return new int[] { leftValue, rightValue };
                }
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    rigth = mid - 1;
            }

            return forReturn;
        }

        private int FindLeftValue(int[] nums, int left, int rigth)
        {
            int target = nums[rigth];
            while (left <= rigth)
            {
                int mid = left + (rigth - left) / 2;

                if (nums[mid] >= target)
                    rigth = mid - 1;
                else
                    left = mid + 1;
            }

            if (left < nums.Length && nums[left] == target) return left;

            return -1;
        }

        private int FindRightValue(int[] nums, int left, int rigth)
        {
            int target = nums[left];
            while (left <= rigth)
            {
                int mid = left + (rigth - left) / 2;

                if (nums[mid] <= target)
                    left = mid + 1;
                else
                    rigth = mid - 1;
            }

            if (rigth >= 0 && nums[rigth] == target) return rigth;

            return -1;
        }
    }
}
