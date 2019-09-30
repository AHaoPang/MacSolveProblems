using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem349 : IProblem
    {
        public void RunProblem()
        {
            var temp = Intersection(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });

            temp = Intersection(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            /*
             * 取得两个无需数组的交集
             * 思路：
             *  1.采用双指针的解法
             *  2.两个指针分别指向各自的数组元素
             *  3.两个指针所指向的数组，谁的小就移动谁，若一样，那么就是我们要找的了
             *  
             * 时间复杂度：O(nlogn)，因为这种方法需要先对原数组做排序，那么最快基本上就是O(nlogn)，然后就是遍历两个数组一遍了
             * 空间复杂度：O(n)，使用的额外空间，也就是为了返回结果了
             * 
             * 这种接法实际上是用时间换空间的一种思路
             */

            var order1Array = nums1.OrderBy(i => i).ToArray();
            var order2Array = nums2.OrderBy(i => i).ToArray();

            HashSet<int> forReturn = new HashSet<int>();
            int array1Index = 0;
            int array2Index = 0;
            while(array1Index < nums1.Length && array2Index < nums2.Length)
            {
                if(order1Array[array1Index] == order2Array[array2Index])
                {
                    forReturn.Add(order1Array[array1Index]);
                    array1Index++;
                    array2Index++;
                }
                else if(order1Array[array1Index] < order2Array[array2Index])
                    array1Index++;
                else
                    array2Index++;
            }

            return forReturn.ToArray();
        }

        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            /*
             * 取得两个无序数组的交集
             * 思路：
             *  1.要知道数组1有什么，数组2有什么，然后做比较才能知道
             *  2.这种场景比较适合于HashTable，即先做统计，然后再做比较，属于用空间换时间的思路
             *  
             * 时间复杂度：O(n+m)，字符串还是要全部都遍历一遍的
             * 空间复杂度：O(n+m)，所有的数字都是要存储一遍的
             */

            HashSet<int> nums1Set = new HashSet<int>(nums1);
            HashSet<int> nums2Set = new HashSet<int>(nums2);

            List<int> forReturn = new List<int>(nums1.Length + nums2.Length);
            if (nums1Set.Count <= nums2Set.Count)
            {
                foreach (var item in nums1Set)
                    if (nums2Set.Contains(item)) forReturn.Add(item);
            }
            else
            {
                foreach (var item in nums2Set)
                    if (nums1Set.Contains(item)) forReturn.Add(item);
            }

            return forReturn.ToArray();
        }
    }
}
