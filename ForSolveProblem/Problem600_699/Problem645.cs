using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem645 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindErrorNums(new int[] { 1, 2, 2, 4 });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 2, 3 })) throw new Exception();
        }

        public int[] FindErrorNums(int[] nums)
        {
            /*
             * 找到数组中重复的数字和丢失的数字
             * 思路：
             *  1.数组包含1~n，每个数字只出现1次
             *  2.可以考虑非比较的排序方法，让数组变的有序
             *  3.然后再巡检一次就知道谁重复了，谁丢失了
             *  4.甚至于重复多次，丢失多个也是支持找回来的
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var orderArray = new byte[nums.Length + 1];
            foreach (var numItem in nums) orderArray[numItem]++;

            var forReturn = new int[2];
            for(int i = 1;i < orderArray.Length; i++)
            {
                switch (orderArray[i])
                {
                    case 0:
                        forReturn[1] = i;
                        break;
                    case 2:
                        forReturn[0] = i;
                        break;
                }
            }

            return forReturn;
        }
    }
}
