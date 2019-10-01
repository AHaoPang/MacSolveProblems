using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem215 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindKthLargest(new int[] { 3, 2, 1, 5, 6, 4 }, 2);
            if (temp != 5) throw new Exception();

            temp = FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4);
            if (temp != 4) throw new Exception();

            temp = FindKthLargest(new int[] { 1 }, 1);
            if (temp != 1) throw new Exception();
        }

        public int FindKthLargest(int[] nums, int k)
        {
            /*
             * 查找数组中的第K大元素
             * 思路：
             *  1.可以考虑使用快速排序的思想，快速排序，总是会定位一个数字为中点，来重排两边的元素，若定位的点，刚好就是要求解的点，问题则可解
             *  2.算是对排序问题的间接问题
             *  
             * 时间复杂度：O(nlogn)，每次选择的都是最左边的点，最坏情况是，数组本身是有小到大有序排列的
             * 空间复杂度：O(1)，不打算使用额外的存储空间
             * 
             * 考察点
             *  1.双指针的应用
             */

            return RecurSiveForKLargest(nums, 0, nums.Length - 1, k);
        }

        private int RecurSiveForKLargest(int[] nums, int leftIndex, int rightIndex, int k)
        {
            int leftPos = leftIndex;
            int rightPos = rightIndex;
            while (leftPos < rightPos)
            {
                //负责定位比中值小的位置
                while (leftPos < rightIndex && nums[leftPos] >= nums[leftIndex]) leftPos++;
                //负责定位比中值大的位置
                while (rightPos > leftIndex && nums[rightPos] < nums[leftIndex]) rightPos--;

                if (leftPos < rightPos)
                {
                    var temp = nums[leftPos];
                    nums[leftPos] = nums[rightPos];
                    nums[rightPos] = temp;
                }
            }

            var temp2 = nums[rightPos];
            nums[rightPos] = nums[leftIndex];
            nums[leftIndex] = temp2;

            if (rightPos == k - 1)
                return nums[rightPos];
            else if (rightPos < k - 1)
                return RecurSiveForKLargest(nums, rightPos + 1, rightIndex, k);
            else
                return RecurSiveForKLargest(nums, leftIndex, rightPos - 1, k);
        }
    }
}
