using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem088 : IProblem
    {
        public void RunProblem()
        {
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            /*
             * 合并两个有序数组到一个有序数组中去
             * 思路：
             *  1.按照通常的思维，肯定是从前往后排序，但是数组就意味着，往后推一个，就需要把后面的都移动了
             *  2.那么反向思考一下好了，从前往后排是不行了，那从后往前排呢，是不是就刚刚好了，哈哈
             *  
             * 时间复杂度：O(m+n)，因为要把两个数组中的元素都遍历一遍的
             * 空间复杂度：O(1)，并没有引入额外的存储空间
             */

            int array1LastIndex = m - 1;
            int array2LastIndex = n - 1;
            for (int i = m + n - 1; i >= 0; i--)
            {
                if (array1LastIndex >= 0 && array2LastIndex >= 0)
                {
                    if (nums1[array1LastIndex] >= nums2[array2LastIndex])
                        nums1[i] = nums1[array1LastIndex--];
                    else
                        nums1[i] = nums2[array2LastIndex--];
                }
                else if (array1LastIndex >= 0)
                    nums1[i] = nums1[array1LastIndex--];
                else if (array2LastIndex >= 0)
                    nums1[i] = nums2[array2LastIndex--];
            }
        }
    }
}
