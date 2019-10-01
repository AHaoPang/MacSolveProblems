using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem153 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 });
        }

        public int FindMin(int[] nums)
        {
            /*
             * 假设：数据组至少有一个值，不然无法找最小值
             * 
             * 数组原来的趋势就是“上升”，那么旋转后的数组，依然满足这个趋势
             * 1.中间左面的，一定比中点小；
             * 2.中间右面的，一定比中点大；
             * 若不满足上面的情况，那么就说明要去那个地方找；
             * 其实，旋转的分隔点，就是最小值所在的位置；
             * 还是二分的一种变体
             * 时间复杂度：O(n)；
             * 空间复杂度：O(1)；
             */

            int leftPoint = 0;
            int rightPoint = nums.Length - 1;
            int midPoint = 0;

            //应对元数据是有序的情况
            if (nums.Length > 1 && nums[leftPoint] < nums[rightPoint]) return nums[leftPoint];

            while(leftPoint < rightPoint)
            {
                midPoint = leftPoint + (rightPoint - leftPoint) / 2;

                if (nums[leftPoint] < nums[midPoint])//问题区域在右边
                    leftPoint = midPoint;
                else if (leftPoint == midPoint || rightPoint == midPoint)
                    return nums[leftPoint] < nums[rightPoint] ? nums[leftPoint] : nums[rightPoint];
                else//问题区域在左边
                    rightPoint = midPoint;
            }

            //跳出循环应该是有两种情况：
            //1.就没进入过while；（应该不存在这种情况，因为此情况说明数组里面就没有元素；）
            //2.leftPoint == rightPoint；
            return nums[leftPoint];
        }
    }
}
