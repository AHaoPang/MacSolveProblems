using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem167 : IProblem
    {
        public void RunProblem()
        {
            var temp = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            if (!IsEqual(temp, new int[] { 1, 2 })) throw new Exception();
        }

        private bool IsEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;

            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != arr2[i]) return false;

            return true;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            /*
             * 在有序数组中，找到两个数，两数之和等于目标数
             * 思路：
             *  1.数是自小到大排序的，但是对数本身是不可推测的，所以把所有数看一遍也无可厚非，因此复杂度会维持在O(n)
             *  2.因此思考的重点转为，如何减少空间复杂度
             *  3.考虑使用双指针的方式
             *  
             * 职责思考：
             *  1.左指针移动，是因为两数和小于了目标
             *  2.右指针移动，是因为两数和大于了目标
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int leftIndex = 0;
            int rightIndex = numbers.Length - 1;
            while (leftIndex < rightIndex)
            {
                var sumTemp = numbers[leftIndex] + numbers[rightIndex];

                if (sumTemp == target) return new int[] { leftIndex + 1, rightIndex + 1 };
                else if (sumTemp < target) leftIndex++;
                else rightIndex--;
            }

            throw new Exception();
        }
    }
}
