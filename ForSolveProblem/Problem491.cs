using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem491 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindSubsequences(new int[] { 4, 6, 7, 7 });

            temp = FindSubsequences(new int[] { 4, 3, 2, 1 });
        }

        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            /*
             * 穷举序列的递增子序列
             * 思路：
             *  1.可以看成是一个回溯的问题
             *  2.可以先对原序列做排序，依据题意，序列最长15个元素，因此排序的复杂度可以忽略
             *  3.就每个元素而言，可以选择加入子序列，也可以选择不加入子序列
             *  
             * 时间复杂度：O(2^n)
             * 空间复杂度：O(2^n)
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            Recursive(nums, 0, forReturn, new List<int>());

            return forReturn;
        }

        private HashSet<string> m_addedSet = new HashSet<string>();

        private void Recursive(int[] nums, int numIndex, IList<IList<int>> forReturn, IList<int> curList)
        {
            //负责去重，依据是：列表中已有的值，与当前数组正打算处理的位置相同
            var subStr = $"[{curList.Count}-{numIndex}],{string.Join(",", curList)}";

            if (m_addedSet.Contains(subStr)) return;
            m_addedSet.Add(subStr);

            if (nums.Length == numIndex)
            {
                if (curList.Count > 1) forReturn.Add(curList.ToList());
                return;
            }

            //方案一：不把元素加入到序列中
            Recursive(nums, numIndex + 1, forReturn, curList);

            //方案二：尝试把元素加入到序列中
            bool isAdded = false;
            var curValue = nums[numIndex];
            if (curList.Any() && curList.Last() <= curValue) isAdded = true;
            else if (curList.Count == 0) isAdded = true;

            if (isAdded) curList.Add(curValue);

            Recursive(nums, numIndex + 1, forReturn, curList);

            if (isAdded) curList.RemoveAt(curList.Count - 1);
        }
    }
}
