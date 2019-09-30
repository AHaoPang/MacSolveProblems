using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem035 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int SearchInsert(int[] nums, int target)
        {
            /*
             * 在一个有序数组中做检索，若存在则返回位置，不存在则返回要插入的位置
             * 思路：
             * 1.肯定是要定位目标值的，所以最好的方法是“二分法”；
             * 2.找到了，那么就返回目标值，这是二分法的本来用途
             * 3.那如果找不到呢？二分法的遗留场景是不是还有用？
             *      3.1 如果找不到，那一定是不满足循环的条件了，即左值和右值交叉了，那么位置一定就是左值的位置了！
             *      
             * 若未找到目标值，那么二分法的特性：
             * 1.左值，最后的归属是：大于等于目标值
             * 2.右值，最后的归属是：小于等于目标值
             * 因为题目要求在没有目标值的时候，找到目标值的插入点，因此就应该返回“左值”
             *      
             * 考察知识点：
             * 1.二分法的正常书写
             * 2.二分法的一些有趣特性
             */

            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            while (leftIndex <= rightIndex)
            {
                int mid = leftIndex + (rightIndex - leftIndex) / 2;

                if (nums[mid] == target) return mid;

                if (nums[mid] < target)
                    leftIndex = mid + 1;
                else
                    rightIndex = mid - 1;
            }

            return leftIndex;
        }
    }
}
