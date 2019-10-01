using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem503 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] NextGreaterElements(int[] nums)
        {
            /*
             * 思路：
             * 1.为了让所有元素都能遍历它后面所有的元素，数组至少需要被遍历2次
             * 2.用栈来记录，目前未能找到下一个更大元素的索引位置，栈中最多存储N个元素的索引
             * 
             * 时间复杂度：入栈遍历一次，寻找结果的过程中，又遍历一次，所以是：O(n)
             * 空间复杂度：栈占用空间，O(n)
             */

            int arrLength = nums.Length;
            int[] forReturn = new int[arrLength];
            for (int j = 0; j < arrLength; j++) forReturn[j] = -1;

            Stack<int> needSearchItems = new Stack<int>();
            for (int i = 0; i < 2 * arrLength - 1; i++)
            {
                while (needSearchItems.Any() && nums[i % arrLength] > nums[needSearchItems.Peek()])
                {
                    forReturn[needSearchItems.Peek()] = nums[i % arrLength];
                    needSearchItems.Pop();
                }

                if (i < arrLength) needSearchItems.Push(i);
            }

            return forReturn;
        }
    }
}
