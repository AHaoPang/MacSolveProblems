using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem081 : IProblem
    {
        public void RunProblem()
        {
            var temp = Search(new int[] { 1, 3, 1, 1, 1 }, 3);
        }

        public bool Search(int[] nums, int target)
        {
            /*
             * 最常见的二分法的变体，但是思路是一样的，同样是一次排除掉一半
             * 时间复杂度：O(n)；
             * 空间复杂度：O(1)；
             */

            int leftPoint = 0;
            int rigthPoint = nums.Length - 1;
            int midPoint = 0;
            while (leftPoint <= rigthPoint)
            {
                while (leftPoint < rigthPoint && nums[leftPoint + 1] == nums[leftPoint]) leftPoint++;
                while (leftPoint < rigthPoint && nums[rigthPoint - 1] == nums[rigthPoint]) rigthPoint--;

                //中点值
                midPoint = leftPoint + (rigthPoint - leftPoint) / 2;

                //找到的情况
                if (nums[midPoint] == target) return true;

                //没找到的情况
                if (nums[leftPoint] <= nums[midPoint])
                {
                    //左边是有序的
                    if (nums[midPoint] > target && nums[leftPoint] <= target) rigthPoint = midPoint - 1;
                    else leftPoint = midPoint + 1;
                }
                else
                {
                    //右边是有序的
                    if (nums[midPoint] < target && nums[rigthPoint] >= target) leftPoint = midPoint + 1;
                    else rigthPoint = midPoint - 1;
                }

            }

            return false;
        }
    }
}
