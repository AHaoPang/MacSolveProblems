using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem189 : IProblem
    {
        public void RunProblem()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;

            Rotate(nums, k);

            nums = new int[] { -1, -100, 3, 99 };
            k = 2;
            Rotate(nums, k);
        }

        public void Rotate2(int[] nums, int k)
        {
            /*
             * 数组旋转
             * 思路：
             *  1.这个过程，其实可以看成是两次反转的过程
             *  2.第一次，把后面的K个元素反转
             *  3.第二次，把整个数组反转
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int arrLength = nums.Length;

            int adjustK = k % arrLength;

            ExchangeElementPos(nums, 0, arrLength - adjustK - 1);
            ExchangeElementPos(nums, arrLength - adjustK, arrLength - 1);
            ExchangeElementPos(nums, 0, arrLength - 1);
        }

        private void ExchangeElementPos(int[] nums,int leftIndex,int rightIndex)
        {
            while(leftIndex < rightIndex)
            {
                var tempValue = nums[leftIndex];
                nums[leftIndex] = nums[rightIndex];
                nums[rightIndex] = tempValue;

                leftIndex++;
                rightIndex--;
            }
        }

        public void Rotate(int[] nums, int k)
        {
            /*
             * 数组旋转
             * 思路：
             *  1.相当于把数组的头换成了第 n - k + 1 的位置
             *  2.那么知道的头，在新的空间建立新的数组即可
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //1.确定数组头的位置
            int arrLength = nums.Length;

            int[] forReturn = new int[arrLength];

            //2.逐一拷贝到新的数组
            for(int i = 0; i < arrLength; i++)
                forReturn[(i + k) % arrLength] = nums[i];

            //3.返回所需的结果
            for (int i = 0; i < arrLength; i++)
                nums[i] = forReturn[i];
        }
    }
}
