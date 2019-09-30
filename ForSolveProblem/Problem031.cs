using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem031 : IProblem
    {
        public void RunProblem()
        {
            var temp = new int[] { 1, 1, 5 };
            NextPermutation(temp);
        }

        public void NextPermutation(int[] nums)
        {
            /*
             * 思路：依据题目特性来针对处理方式
             * 1.要找到下一个更大排列--->所以要逆序遍历
             * 2.逆序寻找的是一种趋势，即数字变小的趋势，
             *      2.1 若存在这种情况，那么就说明“存在下一个更大排列”；
             *      2.2 若不存在这种情况，那么就找最小排列好了
             * 
             * 时间复杂度：O(n)是要遍历一遍，然后还要排序，O(nlogn)，所以是O(nlogn)
             * 空间复杂度：O(1) 使用固定大小的额外空间
             * 
             * 考察点：
             * 1.数组，指针，能够熟练的操作数组，以及使用指针
             * 2.数组元素的逆序
             */

            if (nums.Length <= 1) return;

            //逆序遍历
            int exchangeIndex = -1;
            int maxNum = nums[nums.Length - 1];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] >= maxNum)
                    maxNum = nums[i];
                else
                {
                    exchangeIndex = i;
                    break;
                }
            }

            //是哪种可能性
            if (exchangeIndex == -1)
            {
                //说明数组是逆序增长的，那么返回最小的排列
                ReverseArray(nums, 0, nums.Length - 1);
                return;
            }

            //说明存在下一个更大的排列
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] > nums[exchangeIndex])
                {
                    int temp = nums[i];
                    nums[i] = nums[exchangeIndex];
                    nums[exchangeIndex] = temp;

                    break;
                }
            }

            ReverseArray(nums, exchangeIndex + 1, nums.Length - 1);
            return;
        }

        private void ReverseArray(int[] nums,int startIndex,int stopIndex)
        {
            while(startIndex < stopIndex)
            {
                int temp = nums[startIndex];
                nums[startIndex] = nums[stopIndex];
                nums[stopIndex] = temp;

                startIndex++;
                stopIndex--;
            }
        }
    }
}
