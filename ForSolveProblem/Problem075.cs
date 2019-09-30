using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem075 : IProblem
    {
        public void RunProblem()
        {
            var nums = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColors(nums);

            nums = new int[] { 0, 0, 0, 0, 0, 0 };
            SortColors(nums);

            nums = new int[] { 2, 2, 2, 2 };
            SortColors(nums);

            nums = new int[] { };
            SortColors(nums);
        }

        public void SortColors(int[] nums)
        {
            /*
             * 思路：采用1次遍历的方法，即，若值为0，丢左边，值为1，前进，值为2，丢右边
             * 
             * 时间复杂度：O(n)，只需要扫描一遍即可
             * 空间复杂度：O(1)，准确的说，只是使用了1个额外的空间
             * 
             * 3个指针，及其职责
             *  1.p0，指向的是0的右边界
             *  2.p2，指向的是2的左边界
             *  3.cur，指向待扫描的元素
             */

            int p0 = 0;
            int p2 = nums.Length - 1;
            int cur = 0;

            while (cur <= p2)
            {
                if (nums[cur] == 0)
                {
                    var temp = nums[cur];
                    nums[cur] = nums[p0];
                    nums[p0] = temp;

                    cur++;
                    p0++;
                }
                else if (nums[cur] == 1)
                {
                    cur++;
                }
                else
                {
                    var temp = nums[cur];
                    nums[cur] = nums[p2];
                    nums[p2] = temp;

                    p2--;
                }
            }
        }

        public void SortColors3(int[] nums)
        {
            /*
             * 思路：
             *  1.使用计数排序，先统计各个元素的数量，然后再去按照要求做构造
             *  2.其实这个分类的问题，本质上也是个排序的问题
             *  
             * 时间复杂度：O(n)，先扫描一遍做统计，然后再扫描一遍，做输出
             * 空间复杂度：O(1)，使用的额外的空间可以认为是大小固定的
             */

            int[] typeCount = new int[3];
            for (int i = 0; i < nums.Length; i++)
                typeCount[nums[i]]++;

            int startIndex = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < typeCount[i]; j++)
                    nums[startIndex++] = i;
        }

        public void SortColors2(int[] nums)
        {
            /*
             * 将数组中的元素，按照类别聚集到一起
             * 思路：
             *  1.还是使用双指针交换的思路来解决这个问题
             *  2.指针的职责可以这样划分：指向特定数字的指针 和 不指向特定数字的指针
             *  3.分成几组，大概就需要遍历几次的样子
             *  
             * 时间复杂度：O(n)，最坏情况就是只有一个类型，那么整个数组其实就是被遍历了3次的
             * 空间复杂度：O(1)，使用固定大小的额外空间
             */

            int endIndex = 0;
            for (int i = 2; i > 0; i--)
            {
                if (i == 2) endIndex = nums.Length - 1;

                endIndex = swapArray(nums, 0, endIndex, i);
            }
        }

        private int swapArray(int[] nums, int startIndex, int endIndex, int targetColor)
        {
            /*
             * 使用 双指针的方法 将指定范围的元素，按照目标值来归类
             */

            while (startIndex < endIndex)
            {
                while (startIndex < nums.Length && nums[startIndex] != targetColor)
                    startIndex++;

                while (endIndex >= 0 && nums[endIndex] == targetColor)
                    endIndex--;

                if (startIndex < endIndex)
                {
                    var temp = nums[startIndex];
                    nums[startIndex] = nums[endIndex];
                    nums[endIndex] = temp;
                }
            }

            return endIndex;
        }
    }
}
