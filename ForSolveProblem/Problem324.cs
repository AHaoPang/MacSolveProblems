using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem324 : IProblem
    {
        public void RunProblem()
        {
            int[] nums = File.ReadAllText(@"C:\MSCode\txt.txt").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray();
            WiggleSort(nums);
        }

        public void WiggleSort(int[] nums)
        {
            /*
             * 思路：
             * 1.先将数组排序；
             * 2.将排序数组从中间截断，然后前后段部分，交叉排列；
             * 3.因为后段一定比前端大，因此交叉排列后，一定一个保证这种摆动的效果
             * 
             * 时间复杂度：O(nlogn)，主要是快速排序的耗时
             * 空间复杂度：O(n)，需要做数组交叉合并
             */

            int[] forReturn = new int[nums.Length];

            //借用双指针的方法，来合并出新的数组
            var orderedNums = nums.OrderBy(i => i).ToArray();

            int midPos = orderedNums.Length / 2;
            int maxPos = 0;
            if (orderedNums.Length % 2 == 0) maxPos = midPos;
            else maxPos = midPos + 1;

            int minPos = 0;
            for (int i = 0; i < midPos; i++)
            {
                forReturn[2 * i] = orderedNums[minPos++];
                forReturn[2 * i + 1] = orderedNums[maxPos++];
            }

            for (int j = 0; j < nums.Length; j++) nums[j] = forReturn[j];
        }
    }
}
