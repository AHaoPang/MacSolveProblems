using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem287 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindDuplicate(int[] nums)
        {
            /*
             * 寻找数组中重复的元素
             * 思路：
             *  1.在n+1长的数组中，存放了1~n范围内的元素，因此一定是有一个元素重复了！
             *  2.题目说，有且只有一个数字重复了，且重复的次数可能不止一次！
             *  3.不能更改原数组、空间复杂度O(1)，说明了不让通过排序的方式来查找；
             *  4.时间复杂度小于O(n^2)，说明不让暴力比较破解；
             *  5.重复的数字可能重复不止1次，那么就不能求和求差了；~
             *  6.设想这样的一种情况，n个位置，放n个元素，即使不按照既有顺序来排列，也可以通过逐一归位的方式来重新有序
             *      6.1 操作的过程，有点儿像“值与索引的关系”，必须保证值和索引是一致的
             *  7.再来看题目，n+1个位置，放0~n个元素，那么一个数字是重复的，就说明操作过程中，发现了“索引与值已经一致了，但是自己又发现了一个相同的值”
             *  8.题目不让修改原数组，那么这个问题其实可以转换为“链表环检测”的问题，不光要检测到环，还要知道环的起始位置
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int slowIndex = nums[0];
            int fastIndex = nums[0];
            do
            {
                slowIndex = nums[slowIndex];
                fastIndex = nums[nums[fastIndex]];
            }
            while (slowIndex != fastIndex);

            int ptr1 = nums[0];
            int ptr2 = slowIndex;
            while(ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }

            return ptr1;
        }
    }
}
