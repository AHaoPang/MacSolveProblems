using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem033 : IProblem
    {
        public void RunProblem()
        {
            var temp = Search(new int[] { 3, 1 }, 1);
        }

        public int Search(int[] nums, int target)
        {
            /*
             * 二分查找指定值的问题，算是变体问题，但是二分的思路是不变的
             * 时间复杂度：O(logn)
             * 空间复杂度: O(1)
             */

            int leftPoint = 0;
            int rightPoint = nums.Length - 1;
            int midPoint = 0;

            while(leftPoint < rightPoint)
            {
                midPoint = leftPoint + (rightPoint - leftPoint) / 2;
                if (nums[midPoint] == target) return midPoint;

                if (nums[leftPoint] < nums[midPoint])//左边有序
                {
                    if (nums[midPoint] > target && nums[leftPoint] <= target) rightPoint = midPoint - 1;
                    else leftPoint = midPoint + 1;
                }
                else if (leftPoint == midPoint) leftPoint = midPoint + 1;
                else //右边有序
                {
                    if (nums[midPoint] < target && nums[rightPoint] >= target) leftPoint = midPoint + 1;
                    else rightPoint = midPoint - 1;
                }
            }

            //跳出循环的两种情况：
            //1.就没进入过while，count == 0 或者 1;
            //2.进入过了 leftPoint == rightPoint

            if (nums.Length == 0) return -1;
            else
                return nums[leftPoint] == target ? leftPoint : -1;
        }
    }
}
