using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem496 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            /*
             * 下一个更大元素问题求解思路：
             * 1.nums1是nums2的子数组，但是顺序并不确定，或者说是乱序的；
             * 2.那么就不如把nums2中所有元素的下一个更大元素拿出来，存储到HashTable中，那么nums1中是啥元素就都OK了；
             * 
             * 可以借用Stack来操作，所有元素都是要入栈的，但是当发现目标时，就要实时的出栈了，栈中存储的都是未找到目标值的元素，最后就是-1了；
             * 
             * 注意：就是因为提供中说，nums1和nums2中数组元素唯一，因此才可以用字典，否则若元素重复，那么不同位置的下一个更大值是不同的了；
             * 
             * 时间复杂度：遍历nums2构造HashTable，耗时O(n)，然后遍历nums1，借助HashTable得到结果，耗时O(m+1)，所有最后的结果就是：O(m+n)
             * 空间复杂度：一共需要两个存储结构，HashTable和Stack,都是nums2的长度，所以最后的结果是：O(2*n)，即O(n)
             */

            int[] forReturn = new int[nums1.Length];

            Dictionary<int, int> elementMapNextGreater = new Dictionary<int, int>();
            Stack<int> readySearchElement = new Stack<int>();
            for (int j = 0; j < nums2.Length; j++)
            {
                while (readySearchElement.Any() && nums2[j] > readySearchElement.Peek())
                    elementMapNextGreater[readySearchElement.Pop()] = nums2[j];

                readySearchElement.Push(nums2[j]);
            }

            for (int k = 0; k < nums1.Length; k++)
            {
                if (elementMapNextGreater.ContainsKey(nums1[k]))
                    forReturn[k] = elementMapNextGreater[nums1[k]];
                else
                    forReturn[k] = -1;
            }

            return forReturn;
        }
    }
}
