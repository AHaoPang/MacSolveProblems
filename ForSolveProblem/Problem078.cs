using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem078 : IProblem
    {
        public void RunProblem()
        {
            var temp = Subsets(new int[] { 1, 2, 3 });

            temp = Subsets(new int[] { });

            temp = Subsets(new int[] { 1 });
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            /*
             * 求解包含不重复元素数组的所有子集
             * 思路：
             *  1.这种求解众多可能性的问题，一般都是“回溯法”的应用场景
             *  2.这个问题可以转化为“多步骤穷举”的问题
             *  3.数组中每个元素都有“参与”和“不参与”这两种可能性
             *  
             * 时间复杂度：O(2^n)，递归的效果是一个满二叉树
             * 空间复杂度：O(2^n)，所有的可能性，相当于是所有的叶子结果
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            RecurSive(forReturn, new List<int>(), 0, nums);

            return forReturn;
        }

        private void RecurSive(IList<IList<int>> forReturn, IList<int> curList, int curIndex, int[] nums)
        {
            if (curIndex == nums.Length)
            {
                forReturn.Add(curList.ToList());
                return;
            }

            RecurSive(forReturn, curList, curIndex + 1, nums);

            curList.Add(nums[curIndex]);
            RecurSive(forReturn, curList, curIndex + 1, nums);
            curList.RemoveAt(curList.Count - 1);
        }
    }
}
