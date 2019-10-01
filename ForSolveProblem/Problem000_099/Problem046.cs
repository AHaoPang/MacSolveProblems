using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem046 : IProblem
    {
        public void RunProblem()
        {
            var temp = Permute(new int[] { 1, 2, 3 });
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            /*
             * 给特定的序列排序
             * 思路：
             *  1.思考不使用额外空间的方法；
             *  2.全排列，就是一个个选择数字的过程，即，第1个位置放啥，第2个位置放啥，直到最后一个位置也放完了，那么一次排列也就结束了
             *  3.此种排列思路，不管给定序列是否有重复数字，都是可以使用的
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            BackTrace(nums, 0, forReturn);

            return forReturn;
        }

        private void BackTrace(int[] nums, int level, IList<IList<int>> forReturn)
        {
            if (level == nums.Length)
            {
                forReturn.Add(nums.ToList());
                return;
            }

            for (int i = level; i < nums.Length; i++)
            {
                Swap(nums, level, i);
                BackTrace(nums, level + 1, forReturn);
                Swap(nums, level, i);
            }
        }

        private void Swap(int[] nums, int num1, int num2)
        {
            int temp = nums[num1];
            nums[num1] = nums[num2];
            nums[num2] = temp;
        }

        public IList<IList<int>> Permute2(int[] nums)
        {
            /*
             * 给出特定序列的全排列
             * 思路：
             *  1.典型的递归求解；
             *  2.每一次都要从n个可选数里面挑选一个，一共要选n次，而且n次的选择不能重复
             *  3.一共的可能性有 N! 种！
             *  4.题目中说，给出的序列是不重复的，因此可以想到使用 HashTable 来解决问题
             *  
             * 时间复杂度：O(n!)
             * 空间复杂度：O(n!)
             * 
             * 考察点：
             *  1.递归、回溯
             *  2.HashTable
             *  3.关于全排列的数学知识
             *  
             * 递归的关键点在于，每一个步骤，思考的角度、判断的方式都是一样的
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            Recursive(nums, 0, new HashSet<int>(), forReturn);

            return forReturn;
        }

        private void Recursive(int[] nums, int level, HashSet<int> numsSet, IList<IList<int>> forReturn)
        {
            if (level == nums.Length)
            {
                forReturn.Add(numsSet.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (numsSet.Contains(nums[i])) continue;

                numsSet.Add(nums[i]);
                Recursive(nums, level + 1, numsSet, forReturn);
                numsSet.Remove(nums[i]);
            }
        }
    }
}
